using Blog.Data;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services.AdminFunctionality
{
    [Service]
    public class GetAllPosts
    {
        private IPostManager _postManager;

        public GetAllPosts(IPostManager postManager)
        {
            _postManager = postManager;
        }

        public IEnumerable<Post> Do()
        {
            return _postManager.GetAllPosts();
        }
    }
}
