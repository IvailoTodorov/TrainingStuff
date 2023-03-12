namespace PrimeHoldingInternshipExercise.Models.Task
{
    using System.ComponentModel.DataAnnotations;

    public class TaskCreateViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The Full Name must be between 2 and 50 characters long.")]
        public string Title { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "The Description must be between 5 and 500 characters long.")]
        public string Description { get; set; }

        [Required]
        public int AssigneeId { get; set; }

        [Required]
        [DataType(DataType.Date)]

        public DateTime DueDate { get; set; }
    }
}
