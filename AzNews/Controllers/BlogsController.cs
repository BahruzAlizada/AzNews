using BusinessLayer.Abstract;
using EntityLayer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzNews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService blogService;
        public BlogsController(IBlogService blogService)
        {
            this.blogService=blogService;
        }

        #region GetActiveBlogs
        [HttpGet("GetActiveBlogs")]
        public async Task<IActionResult> GetActiveBlogs(string? search, int? catId, int? authId, int take)
        {
            var result = await blogService.GetActiveBlogs(search, catId, authId, take);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region LoadMoreAsync
        [HttpGet("LoadMoreAsync")]
        public async Task<IActionResult> LoadMoreAsync(string? search, int? catId, int? authId, int skipCount, int take)
        {
            var result = await blogService.LoadMoreAsync(search,catId,authId,skipCount,take);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region BlogCountWithFilter
        [HttpGet("BlogCountWithFilter")]
        public async Task<IActionResult> BlogCountWithFilter(string search, int? catId, int? authId)
        {
            var result = await blogService.BlogCountWithFilter(search, catId, authId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region AddAsync
        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync(BlogDto blogDto)
        {
            var result = await blogService.AddAsync(blogDto);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region UpdateAsync
        [HttpPut("UpdateASync")]
        public async Task<IActionResult> UpdateAsync(BlogDto blogDto)
        {
            var result = await blogService.UpdateAsync(blogDto);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region Delete
        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var result = blogService.Delete(id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region ActivityAsync
        [HttpGet("ActivityAsync")]
        public async Task<IActionResult> ActivityAsync(int id)
        {
            var result = await blogService.ActivityAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
    }
}
