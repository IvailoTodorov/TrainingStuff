namespace PrimeHoldingInternshipExercise.Models.EmployeeSkill
{
    using PrimeHoldingInternshipExercise.Data.Models;

    public class EmployeeSkillsListingModel
    {
        public Employee Employee { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
