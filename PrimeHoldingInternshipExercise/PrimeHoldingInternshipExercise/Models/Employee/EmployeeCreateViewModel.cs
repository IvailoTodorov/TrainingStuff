namespace PrimeHoldingInternshipExercise.Models.Employee
{
    using System.ComponentModel.DataAnnotations;

    public class EmployeeCreateViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The Full Name must be between 2 and 50 characters long.")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Adress")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Birthdate")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [Display(Name = "Monthly Salary")]
        public double MonthlySalary { get; set; }
    }
}
