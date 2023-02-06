namespace ChatForumApp.Controllers
{
    using ChatForumApp.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class ChatForumController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChatForumController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var comments = _context.Comments.Include(x => x.Replies).Include(x => x.User).ToList();

            return View(comments);
        }
    }
}
