using Blog.Domain.Interfaces;
using Blog.Domain.Models.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data
{
    public class SubCommentManager : ISubCommentManager
    {
        private ApplicationDbContext _ctx;

        public SubCommentManager(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task AddSubComment(SubComment subComment)
        {
            _ctx.SubComments.Add(subComment);
            await _ctx.SaveChangesAsync();
        }

        public async Task<bool> DeleteSubComment(int id)
        {
            var subComment = _ctx.SubComments.FirstOrDefault(x => x.Id == id);
            if (subComment == null)
                return false;

            _ctx.SubComments.Remove(subComment);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public SubComment GetSubCommentById(int id)
        {
            return _ctx.SubComments.FirstOrDefault(x => x.Id == id);
        }

        public async Task UpdateSubComment(SubComment subComment)
        {
            _ctx.SubComments.Update(subComment);
            await _ctx.SaveChangesAsync();
        }

        public IEnumerable<SubComment> GetAllSubComments()
        {
            return _ctx.SubComments.ToList();
        }
    }
}
