using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Models.Comments
{
    public class SubComment : Comment
    {
        public string UserId { get; set; }
        public User user { get; set; }
        public int MainCommentId { get; set; }
    }
}
