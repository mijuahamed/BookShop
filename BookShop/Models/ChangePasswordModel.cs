using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BookShop.Models
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "Please enter current password")]
        [Display(Name = "Enter your current password")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
        [Required(ErrorMessage = "Please enter new password")]
        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Please enter confirm password")]
        [Display(Name = "Confirm Password")]
        [Compare("NewPassword", ErrorMessage = "Password and confirm password does not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
