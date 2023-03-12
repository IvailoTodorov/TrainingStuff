namespace PrimeHoldingInternshipExercise.Models.EmployeeSkill
{
    using PrimeHoldingInternshipExercise.Data.Models;

    public class EmployeeSkillViewModel
    {
        public int EmployeeId { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
