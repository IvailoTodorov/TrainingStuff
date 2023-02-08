namespace ChatForumApp.Models.Replies
{
    using System.ComponentModel.DataAnnotations;

    public class ReplyViewModel
    {
        [Required]
        public string Content { get; set; }

        public int CommentId { get; set; }

        public int UserId { get; set; }

    }
}
