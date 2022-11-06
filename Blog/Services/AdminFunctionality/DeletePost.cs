using Blog.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services.AdminFunctionality
{
    [Service]
    public class DeletePost
    {
        private IPostManager _postManager;

        public DeletePost(IPostManager postManager)
        {
            _postManager = postManager;
        }

        public async Task<bool> Do(int id)
        {
            var post = _postManager.GetPostById(id);

            if (post == null)
                return false;

            await _postManager.DeletePost(post);

            return true;
        }
    }
}
