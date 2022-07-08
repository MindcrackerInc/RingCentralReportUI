using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RingCentralReport.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using ClosedXML.Excel;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Dapper;
using Microsoft.AspNetCore.Authorization;

namespace RingCentralReport.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private readonly RignCentral_ReportingContext _context;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        public ReportController(RignCentral_ReportingContext context
            , IConfiguration config)
        {
            _context = context;
            _config = config;
            _connectionString = _config.GetConnectionString("RingCentral");
        }

        // GET: ReportController
        public async Task<ActionResult> IndexAsync(string fromdate="",string todate="",int offSet = 0, int limit = 30)
        {
            //var identities = //await _context.Identities.ToListAsync();
            try
            {
                ReportModels reportModels = new ReportModels();
                if (string.IsNullOrEmpty(fromdate) && string.IsNullOrEmpty(todate))
                {
                    reportModels.fromDate = DateTime.Now.AddMonths(-1).ToString("dd/MM/yyyy");
                    reportModels.toDate = DateTime.Now.ToString("dd/MM/yyyy");
                    fromdate = DateTime.Now.AddMonths(-1).ToString("yyyyMMdd");
                    todate = DateTime.Now.ToString("yyyyMMdd");
                }
                else {
                   reportModels.fromDate = fromdate;
                    reportModels.toDate = todate;
                    fromdate = Convert.ToDateTime(fromdate).ToString("yyyyMMdd");
                    todate = Convert.ToDateTime(todate).ToString("yyyyMMdd");
                }
               // Int32 ajaxDraw = Convert.ToInt32(HttpContext.Request.Form["draw"]);
                using (var connection = new SqlConnection(_connectionString))
                {
                    
                    var sql = "exec [getData] @PageNo, @RecordsPerPage,@Startdate,@EndDate";
                    var values = new { PageNo = offSet, RecordsPerPage = limit, Startdate=fromdate, EndDate=todate };
                    var results = await connection.QueryAsync<ReportModel>(sql,values, commandTimeout: 1200);
                    //results = results.ToList();
                    reportModels.listReportmodel = results.ToList();
                    reportModels.recordsFiltered = 500000;
                    reportModels.recordsTotal = 500000;
                    reportModels.draw = 1;

                    return View(reportModels);
                }
            }
            catch(Exception ex)
            {

            }
                //var values = new { Beginning_Date = "2017.1.1", Ending_Date = "2017.12.31" };
                //var results = connection.Query(sql).ToList();
                return View();
            
            }
       
        // GET: ReportController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReportController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReportController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReportController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReportController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReportController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReportController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Export()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[5] { new DataColumn("CreatedAt"),
                                        new DataColumn("Id"),
                                        new DataColumn("IdentityGroupId"),
                                        new DataColumn("Firstname"),
                                        new DataColumn("Lastname") });

            var identities = from Identity in _context.Identities.Take(10)
                            select Identity;

            foreach (var identity in identities)
            {
                dt.Rows.Add(identity.CreatedAt, identity.Id, identity.IdentityGroupId, identity.Firstname, identity.Lastname);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");
                }
            }
        }
    }
}
