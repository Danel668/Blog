using Blog.Domain.Models.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Interfaces
{
    public interface ISubCommentManager
    {
        Task AddSubComment(SubComment subComment);
        Task<bool> DeleteSubComment(int id);
        SubComment GetSubCommentById(int id);
        Task UpdateSubComment(SubComment subComment);
        IEnumerable<SubComment> GetAllSubComments();
    }
}
