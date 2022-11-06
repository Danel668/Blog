using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Models.Comments
{
    public class MainComment : Comment
    {
        public string UserId { get; set; }
        public User user { get; set; }
        public List<SubComment> SubComments { get; set; }
        public int PostId { get; set; }
        public Post post { get; set; }
    }
}
