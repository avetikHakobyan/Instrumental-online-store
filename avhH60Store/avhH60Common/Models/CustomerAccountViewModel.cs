using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace avhH60Common.Models
{
    public class CustomerAccountViewModel
    {
        [DisplayName("First Name")]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(20)]
        [RegularExpression("^[A-Za-z\\s'-]+$", ErrorMessage = "First name can only contain letters, \', - and space")]
        public string? FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(30)]
        [RegularExpression("^[A-Za-z\\s'-]+$", ErrorMessage = "Last name can only contain letters, \', - and space")]
        public string? LastName { get; set; }

        [EmailAddress]
        [Required]
        [StringLength(30)]
        public string? Email { get; set; }

        [DisplayName("Phone Number")]
        [Required]
        [Phone]
        [StringLength(10)]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please select a province")]
        [ProvinceValidation(ErrorMessage = "Please select a valid province")]
        public string? Province { get; set; }

        [DisplayName("Credit Card")]
        [Required]
        [CreditCard]
        [StringLength(16)]
        public string? CreditCard { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }
    }


}
