namespace PrimeHoldingInternshipExercise.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
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

        public ICollection<Task> Tasks { get; set; }
        public ICollection<EmployeeSkill> EmployeeSkills { get; set; }
    }
}
