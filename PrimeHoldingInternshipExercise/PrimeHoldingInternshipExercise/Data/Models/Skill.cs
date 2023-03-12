namespace PrimeHoldingInternshipExercise.Data.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<EmployeeSkill> EmployeeSkills { get; set; }
    }
}
