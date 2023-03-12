namespace PrimeHoldingInternshipExercise.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using PrimeHoldingInternshipExercise.Data;
    using PrimeHoldingInternshipExercise.Data.Models;
    using PrimeHoldingInternshipExercise.Models.Task;

    public class TaskController : Controller
    {
        private readonly ApplicationDbContext context;

        public TaskController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public ActionResult Index()
        {
            var tasks = context.Tasks.Include(x => x.Assignee).ToList();

            return View(tasks);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TaskCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                var task = new Task
                {
                    Title = model.Title,
                    Description = model.Description,
                    AssigneeId = model.AssigneeId,
                    DueDate = model.DueDate
                };

                context.Tasks.Add(task);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int id)
        {
            var task = context.Tasks.Find(id);

            if (task == null)
            {
                return NotFound();
            }

            var model = new TaskCreateViewModel
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                AssigneeId = task.AssigneeId,
                DueDate = task.DueDate
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(TaskCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                var task = context.Tasks.Find(model.Id);

                if (task == null)
                {
                    return NotFound();
                }

                task.Title = model.Title;
                task.Description = model.Description;
                task.AssigneeId = model.AssigneeId;
                task.DueDate = model.DueDate;

                context.Update(task);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            var tast = context.Tasks.Find(id);

            if (tast == null)
            {
                return NotFound();
            }

            context.Tasks.Remove(tast);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
