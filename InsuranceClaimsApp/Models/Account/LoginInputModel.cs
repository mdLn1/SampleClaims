using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InsuranceClaimsApp.Models.Account
{
    public class LoginInputModel
    {
        [Required]
        [DisplayName("User Name")]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}