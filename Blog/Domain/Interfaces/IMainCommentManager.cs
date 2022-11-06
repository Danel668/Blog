using Blog.Domain.Models.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Interfaces
{
    public interface IMainCommentManager
    {
        Task AddMainComment(MainComment mainComment);
        Task<bool> DeleteMainComment(int id);
        MainComment GetMainCommentById(int id);
        Task UpdateMainComment(MainComment mainComment);
        IEnumerable<MainComment> GetAllMainComments();
    }
}
