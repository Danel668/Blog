using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Models.Comments
{
    public class Comment
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public int CountOfLike { get; set; } = 0;
        public string Image { get; set; } = "";

    }
}
