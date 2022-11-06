using Blog.Data;
using Blog.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services.AdminFunctionality
{
    [Service]
    public class AdminDeleteComment
    {
        private ISubCommentManager _subCommentManager;
        private IMainCommentManager _mainCommentManager;

        public AdminDeleteComment(IMainCommentManager mainCommentManager, ISubCommentManager subCommentManager)
        {
            _subCommentManager = subCommentManager;
            _mainCommentManager = mainCommentManager;
        }

        public async Task<bool> Do(AdminDeleteCommentViewModel commentViewModel)
        {
            if (commentViewModel.IsMain)
            {
                return await _mainCommentManager.DeleteMainComment(commentViewModel.Id);
            }

            return await _subCommentManager.DeleteSubComment(commentViewModel.Id);
        }

        public class AdminDeleteCommentViewModel
        {
            public int Id { get; set; }
            public bool IsMain { get; set; }
        }
    }
}
