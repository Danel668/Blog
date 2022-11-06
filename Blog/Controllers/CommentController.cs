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
    [Authorize]
    public class CommentController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddMainComment([FromServices] AddMainComment addMainComment, [FromBody] AddMainComment.MainCommentViewModel mainCommentViewModel)
        {
            return Ok(await addMainComment.Do(mainCommentViewModel));
        }

        [HttpPost]
        public async Task<IActionResult> AddSubComment([FromServices] AddSubComment addSubComment, [FromBody] AddSubComment.SubCommentViewModel subCommentViewModel)
        {
            return Ok(await addSubComment.Do(subCommentViewModel));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMainComment([FromServices] DeleteMainComment deleteMainComment, [FromQuery] int id)
        {
            if (await deleteMainComment.Do(id))
                return Ok(true);

            return BadRequest("DeleteMainComment error");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSubComment([FromServices] DeleteSubComment deleteSubComment, [FromQuery] int id)
        {
            if (await deleteSubComment.Do(id))
                return Ok(true);

            return BadRequest("DeleteSubComment error");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMainComment([FromServices] UpdateMainComment updateMainComment, [FromBody] UpdateMainComment.UpdateMainCommentViewModel updateMainCommentViewModel)
        {
            if (await updateMainComment.Do(updateMainCommentViewModel))
                return Ok(true);

            return BadRequest("UpdateMainComment error");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSubComment([FromServices] UpdateSubComment updateSubComment, [FromBody] UpdateSubComment.UpdateSubCommentViewModel updateSubCommentViewModel)
        {
            if (await updateSubComment.Do(updateSubCommentViewModel))
                return Ok(true);

            return BadRequest("UpdateSubComment error");
        }
    }
}
