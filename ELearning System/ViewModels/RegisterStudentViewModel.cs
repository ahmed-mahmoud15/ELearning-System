using System;
using System.ComponentModel.DataAnnotations;

namespace ELearning_System.ViewModels
{
    public class RegisterStudentViewModel
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(20, ErrorMessage = "First name cannot be longer than 20 characters.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(20, ErrorMessage = "Last name cannot be longer than 20 characters.")]
        public string LastName { get; set; }

        [Display(Name = "Birth Date")]
        [Required(ErrorMessage = "Birth date is required.")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Profile Photo")]
        [DataType(DataType.Upload)]
        public string? PhotoPath { get; set; }

        [Display(Name = "Biography")]
        [StringLength(500, ErrorMessage = "Biography cannot be longer than 500 characters.")]
        public string? Bio { get; set; } = string.Empty;

        [Display(Name = "GitHub Account")]
        [Url(ErrorMessage = "Please enter a valid URL.")]
        public string? GitHubAccount { get; set; } = string.Empty;

    }
}
