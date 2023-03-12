namespace PrimeHoldingInternshipExercise.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Task
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int AssigneeId { get; set; }
        public Employee Assignee { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }
    }
}
