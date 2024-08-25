namespace frontend.Models
{
    public class ApiResponse
    {
        public string status { get; set; }
        public ResultData result { get; set; }
        public string message { get; set; }
    }

    public class ResultData
    {
        public long user_id { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        public bool is_active { get; set; }
    }

    public class Bpkbstore
    {
        public string agreement_number { get; set; }

        public string branch_id { get; set; }

        public string bpkb_no { get; set;}

        public string bpkb_date_in { get; set; }

        public string bpkb_date { get; set; }

        public string faktur_no { get;set;}

        public string faktur_date { get;set;}

        public string police_no { get;set;}

        public int? location_id { get; set;}

        public string? location_name { get; set; }

        public string created_by { get; set; }
        public string? idupdate { get; set; }

    }

    public class byId
    {
        public string? id { get; set; }
    }

    public class LocationModel
    {
        public long location_id { get; set; }
        public string location_name { get; set; }
    }

    public class ApiResponseModel<T>
    {
        public string status { get; set; }
        public T result { get; set; }
        public string message { get; set; }
    }


}
