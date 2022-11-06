using Blog.Data;
using Blog.Domain.Interfaces;
using Blog.Domain.Models.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services.AdminFunctionality
{
    [Service]
    public class GetCommentsByUserId
    {
        private ISubCommentManager _subCommentManager;
        private IMainCommentManager _mainCommentManager;

        public GetCommentsByUserId(IMainCommentManager mainCommentManager, ISubCommentManager subCommentManager)
        {
            _subCommentManager = subCommentManager;
            _mainCommentManager = mainCommentManager;
        }

        public GetCommentsByUserIdViewModel Do(string userId)
        {
            return new GetCommentsByUserIdViewModel
            {
                MainComments = _mainCommentManager.GetAllMainComments().Where(x => x.UserId == userId).ToList(),
                SubComments = _subCommentManager.GetAllSubComments().Where(x => x.UserId == userId).ToList(),
            };
        }

        public class GetCommentsByUserIdViewModel
        {
            public IEnumerable<MainComment> MainComments { get; set; }
            public IEnumerable<SubComment> SubComments { get; set; }
        }
    }
}
