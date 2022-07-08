using System.Collections.Generic;

namespace RingCentralReport.Models
{
    public class ReportModels
    {
        public int recordsTotal { get; set; }
        public int draw { get; set; }
        public int recordsFiltered { get; set; }
       public List<ReportModel> listReportmodel { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
    }
    public class ReportModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
        public string Category_ids { get; set; }
        public string IdentitiesId {get; set; }
        public string TranscriptId { get; set; }
        public string Source_id { get; set; }
        public string First_Content_Author_ID { get; set; }
        public string Interventions_Count { get; set; }
        public string intervention_user_ids { get; set; }
        public string source { get; set; }
        public string Created_at { get; set; }
        public string identity_group_id { get; set; }
        public string foreign_id { get; set; }
     
    }
}
