using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BlazorLearnApp.Models
{
    public class People
    {
        [Required(ErrorMessage = "Provide First Name")]
        [Display(Name = "First Name")]
        [StringLength(15, ErrorMessage = "Last Name is too long.")]
        [MinLength(2, ErrorMessage = "Last Name is too short.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Provide Last Name")]
        [StringLength(15, ErrorMessage = "Last Name is too long.")]
        [MinLength(2, ErrorMessage = "Last Name is too short.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Provide Email Address")]
        [Display(Name = "Email Address")]
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}
