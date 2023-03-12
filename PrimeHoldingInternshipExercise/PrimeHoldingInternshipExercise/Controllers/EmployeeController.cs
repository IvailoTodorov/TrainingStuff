namespace PrimeHoldingInternshipExercise.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using PrimeHoldingInternshipExercise.Data;
    using PrimeHoldingInternshipExercise.Data.Models;
    using PrimeHoldingInternshipExercise.Models.Employee;
    using PrimeHoldingInternshipExercise.Models.EmployeeSkill;

    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext context;

        public EmployeeController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public ActionResult Index()
        {
            var employees = context.Employees.Include(x => x.Tasks).ToList();

            return View(employees);
        }

        public ActionResult TopFiveEmployees()
        {
            var startDate = DateTime.Today.AddMonths(-1);

            var topEmployees = context.Employees
                .Where(e => e.Tasks.Any(t => t.DueDate >= startDate))
                .OrderByDescending(e => e.Tasks.Count(t => t.DueDate >= startDate))
                .Take(5)
                .ToList();

            return View(topEmployees);
        }

        public IActionResult AddSkill(int id)
        {
            var employee = context.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            var model = new EmployeeSkillViewModel
            {
                EmployeeId = id,
                Skills = context.Skills.ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AddSkill(int employeeId, int skillId)
        {
            var employee = context.Employees.Find(employeeId);
            var skill = context.Skills.Find(skillId);

            if (employee == null || skill == null)
            {
                return NotFound();
            }

            var employeeSkill = new EmployeeSkill
            {
                Employee = employee,
                Skill = skill
            };

            context.EmployeeSkills.Add(employeeSkill);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult ShowSkills(int id)
        {
            var employee = context.Employees.Include(e => e.EmployeeSkills)
                                              .ThenInclude(es => es.Skill)
                                              .FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            var model = new EmployeeSkillsListingModel
            {
                Employee = employee,
                Skills = employee.EmployeeSkills.Select(es => es.Skill).ToList()
            };

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                var employee = new Employee
                {
                    FullName = model.FullName,
                    Email = model.Email,
                    Phone = model.Phone,
                    DateOfBirth = model.DateOfBirth,
                    MonthlySalary = model.MonthlySalary
                };

                context.Employees.Add(employee);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int id)
        {
            var employee = context.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            var model = new EmployeeCreateViewModel
            {
                Id = employee.Id,
                FullName = employee.FullName,
                Email = employee.Email,
                Phone = employee.Phone,
                MonthlySalary = employee.MonthlySalary,
                DateOfBirth = employee.DateOfBirth
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                var employee = context.Employees.Find(model.Id);

                if (employee == null)
                {
                    return NotFound();
                }

                employee.FullName = model.FullName;
                employee.Email = model.Email;
                employee.Phone = model.Phone;
                employee.MonthlySalary = model.MonthlySalary;
                employee.DateOfBirth = model.DateOfBirth;


                // Update the employee in the database
                context.Update(employee);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            var employee = context.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            context.Employees.Remove(employee);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
