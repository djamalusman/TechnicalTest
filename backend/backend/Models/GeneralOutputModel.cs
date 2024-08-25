namespace backend.Models
{
    public class GeneralOutputModel
    {
        public string Status { get; set; }
        public object Result { get; set; }
        public string Message { get; set; }
    }
    public class Bpkbstore
    {
        public string agreement_number { get; set; }

        public string branch_id { get; set; }

        public string bpkb_no { get; set; }

        public string bpkb_date_in { get; set; }

        public string bpkb_date { get; set; }

        public string faktur_no { get; set; }

        public string faktur_date { get; set; }

        public string police_no { get; set; }

        public int? location_id { get; set; }
        public string? location_name { get; set; }
        public string created_by { get; set; }

        public string? idupdate { get; set; }


    }
    public class byId
    {
        public string? id { get; set; }
    }
    public class location
    {
        public int? LocationId { get; set; }
        public string? LocationName { get; set; }
    }
    public class ouputBpkb
    {
        public string agreement_number { get; set; }

        public string branch_id { get; set; }

        public string bpkb_no { get; set; }

        public string bpkb_date_in { get; set; }

        public string bpkb_date { get; set; }

        public string faktur_no { get; set; }

        public string faktur_date { get; set; }

        public string police_no { get; set; }

        public int? location_id { get; set; }

        public string? location_name { get; set; }
        public string created_by { get; set; }

        public DateTime? created_on { get; set; }
    }
}
