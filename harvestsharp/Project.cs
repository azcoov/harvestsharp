using System;

namespace harvestsharp
{
    //class for converting harvest projects json resources into strongly typed object
    public class HarvestProject
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool active { get; set; }
        public bool billable { get; set; }
        public string bill_by { get; set; }
        public decimal hourly_rate { get; set; }
        public int client_id { get; set; }
        public string code { get; set; }
        public string notes { get; set; }
        public string budget_by { get; set; }
        public decimal budget { get; set; }
        public DateTime? hint_latest_record_at { get; set; }
        public DateTime? hint_earliest_record_at { get; set; }
        public string fees { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? created_at { get; set; }
    }

    //class for posting a strongly type object as xml to the harvest api
    public class project
    {
        public string name { get; set; }
        public bool active { get; set; }
        public string bill_by { get; set; }
        public int client_id { get; set; }
        public string code { get; set; }
        public string notes { get; set; }
        public decimal budget { get; set; }
        public string budget_by { get; set; }
    }
}
