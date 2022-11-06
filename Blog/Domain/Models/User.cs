using Blog.Domain.Models.Comments;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Models
{
    public class User : IdentityUser
    {
        public ICollection<Post> Posts { get; set; }
        public ICollection<MainComment> MainComments { get; set; }
        public ICollection<SubComment> SubComments { get; set; }
    }
}
