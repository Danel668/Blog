using Blog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Interfaces
{
    public interface IPostManager
    {
        Task AddPost(Post post);

        IEnumerable<Post> GetAllPostsByUserId(string userId);
        List<Post> GetAllPosts();
        IEnumerable<Post> GetAllPostsWithComments();
        Post GetPostWithCommentsById(int id);
        Task<bool> DeleteYourPostById(int id, string userId);
        Task UpdatePost(Post post);
        Post GetPostById(int id);
        Task DeletePost(Post post);











    }
}
