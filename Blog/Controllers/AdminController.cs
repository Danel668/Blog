using Blog.Services.AdminFunctionality;
using Blog.Services.Comments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllPosts([FromServices] GetAllPosts getAllPosts)
        {
            return Ok(getAllPosts.Do());
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePost([FromServices] DeletePost deletePost, [FromQuery] int id)
        {
            return Ok(await deletePost.Do(id));
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePost([FromServices] AdminUpdatePost adminUpdatePost, [FromBody] AdminUpdatePost.PostViewModel postViewModel)
        {
            return Ok(await adminUpdatePost.Do(postViewModel));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteComment([FromServices] AdminDeleteComment adminDeleteComment, [FromBody] AdminDeleteComment.AdminDeleteCommentViewModel adminDeleteCommentViewModel)
        {
            return Ok(await adminDeleteComment.Do(adminDeleteCommentViewModel));
        }

        [HttpGet]
        public IActionResult GetAllCommentsByUserId([FromServices] GetCommentsByUserId getCommentsByUserId, [FromQuery] string userId)
        {
            return Ok(getCommentsByUserId.Do(userId));
        }
    }
    
}
