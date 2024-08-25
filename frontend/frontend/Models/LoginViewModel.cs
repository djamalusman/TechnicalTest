using System.ComponentModel.DataAnnotations;

namespace frontend.Models
{
    public class LoginViewModel
    {

        public long? user_id { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string user_name { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        public bool? is_active { get; set; }


    }
}
