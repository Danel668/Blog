using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data
{
    public class PostManager : IPostManager
    {
        private ApplicationDbContext _ctx;

        public PostManager(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task AddPost(Post post)
        {
            _ctx.Posts.Add(post);
            await _ctx.SaveChangesAsync();
        }

        public List<Post> GetAllPosts()
        {
            return _ctx.Posts.ToList();
        }

        public IEnumerable<Post> GetAllPostsWithComments()
        {
            return _ctx.Posts.Include(x => x.MainComments).ThenInclude(y => y.SubComments).ToList();
        }

        public Post GetPostWithCommentsById(int id)
        {
            return _ctx.Posts.Where(x => x.Id == id).Include(y => y.MainComments).ThenInclude(z => z.SubComments).FirstOrDefault();
        }

        public IEnumerable<Post> GetAllPostsByUserId(string userId)
        {
            return _ctx.Posts.Where(x => x.UserId == userId).ToList();
        }
        public async Task<bool> DeleteYourPostById(int id, string userId)
        {
            var post = _ctx.Posts.FirstOrDefault(x => x.Id == id && x.UserId == userId);
            if (post == null)
                return false;

            _ctx.Posts.Remove(post);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task UpdatePost(Post post)
        {
            _ctx.Posts.Update(post);
            await _ctx.SaveChangesAsync();
        }

        public Post GetPostById(int id)
        {
            return _ctx.Posts.FirstOrDefault(x => x.Id == id);
        }

        public async Task DeletePost(Post post)
        {
            _ctx.Posts.Remove(post);
            await _ctx.SaveChangesAsync();
        }



       


    }
}
