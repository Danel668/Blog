using Blog.Services.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Blog.Services.Posts.GetPostWithCommentsById;

namespace Blog.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PostController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddPost([FromServices] AddPost addPost, [FromBody] AddPost.AddPostViewModel addPostViewModel)
        {
            if (await addPost.Do(addPostViewModel))
                return Ok(true);

            return BadRequest("AddPost Error");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllYourPosts([FromServices] GetAllYourPosts getAllYourPosts)
        {
            IEnumerable<GetAllYourPosts.GetAllYourPostsViewModel> posts = await getAllYourPosts.Do();
            if (posts == null)
                return BadRequest("GetAllYourPosts error");

            return Ok(posts);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllYourPostsWithComments([FromServices] GetAllYourPostsWithComments getAllYourPostsWithComments)
        {
            IEnumerable<GetAllYourPostsWithComments.GetAllYourPostsWithCommentsViewModel> posts = await getAllYourPostsWithComments.Do();
            if (posts == null)
                return BadRequest("GetAllYourPostsWithComments error");

            return Ok(posts);
        }

        [HttpGet]
        public IActionResult GetPostWithCommentsById([FromServices] GetPostWithCommentsById getPostWithCommentsById, [FromQuery] int id)
        {
            var post = getPostWithCommentsById.Do(id);
            if (post == null)
                return BadRequest("GetPostWithCommentsById error");

            return Ok(post);
        }

        [HttpGet]
        public IActionResult GetAllPostsByUserId([FromServices] GetAllPostsByUserId getAllPostsByUserId, [FromQuery] string id)
        {
            var post = getAllPostsByUserId.Do(id);
            if (post.Count() == 0)
                return BadRequest("GetAllPostsByUserId error");
            
            return Ok(post);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteYourPostById([FromServices] DeleteYourPostById deleteYourPostById, [FromQuery] int id)
        {
            if (await deleteYourPostById.Do(id))
                return Ok(true);

            return BadRequest("DeleteYourPostById error");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePost([FromServices] UpdatePost updatePost, [FromBody] UpdatePost.UpdatePostViewModel updatePostViewModel)
        {
            if (await updatePost.Do(updatePostViewModel))
                return Ok(true);

            return BadRequest("UpdatePost error");
        }
    }
}
