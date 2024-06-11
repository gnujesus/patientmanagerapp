using System.ComponentModel.DataAnnotations;

namespace PatientManagerApp.Core.Application.ViewModels.User
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "Please, introduce a valid username")]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please, provide a valid password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
