﻿namespace ChatForumApp.Controllers
{
    using ChatForumApp.Data;
    using ChatForumApp.Data.Models;
    using ChatForumApp.Models.Replies;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Security.Claims;

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

        [HttpPost]
        public IActionResult PostReply(ReplyViewModel model)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var reply = new Reply
            {
                Content = model.Content,
                CommentId = model.CommentId,
                UserId = userId,
                CreatedOn = DateTime.Now
            };

            _context.Replies.Add(reply);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
