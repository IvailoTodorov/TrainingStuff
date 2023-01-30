namespace ChatForumApp.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public string Nickname { get; set; }

        public string? ImageUrl { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
