using Blog.Domain.Models.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User user { get; set; }
        public string Title { get; set; } = "";
        public string Image { get; set; } = "";
        public string Body { get; set; } = "";
        public string Description { get; set; } = "";
        public string Tags { get; set; } = "";
        public string Category { get; set; } = "";
        public DateTime Created { get; set; } = DateTime.Now;
        public int CountOfLike { get; set; } = 0;
        public bool InFavorites { get; set; } = false;
        public int CountOfComments { get; set; } = 0;
        public List<MainComment> MainComments { get; set; }

    }
}
