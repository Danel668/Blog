using Blog.Domain.Interfaces;
using Blog.Domain.Models.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data
{
    public class MainCommentManager : IMainCommentManager
    {
        private ApplicationDbContext _ctx;

        public MainCommentManager(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task AddMainComment(MainComment mainComment)
        {
            _ctx.MainComments.Add(mainComment);
            await _ctx.SaveChangesAsync();
        }

        public async Task<bool> DeleteMainComment(int id)
        {
            var mainComment = _ctx.MainComments.FirstOrDefault(x => x.Id == id);
            if (mainComment == null)
                return false;

            _ctx.MainComments.Remove(mainComment);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public MainComment GetMainCommentById(int id)
        {
            return _ctx.MainComments.FirstOrDefault(x => x.Id == id);
        }

        public async Task UpdateMainComment(MainComment mainComment)
        {
            _ctx.MainComments.Update(mainComment);
            await _ctx.SaveChangesAsync();
        }

        public IEnumerable<MainComment> GetAllMainComments()
        {
            return _ctx.MainComments.ToList();
        }

    }
}
