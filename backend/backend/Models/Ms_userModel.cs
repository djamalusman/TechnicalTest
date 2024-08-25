namespace backend.Models
{
    public class Ms_userModel
    {
        public long? user_id { get; set; }
        public string? user_name { get; set; }

        public string? password { get; set; }
        public bool? is_active { get; set; }

    }
}
