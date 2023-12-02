using BusinessLayer.Abstract;
using EntityLayer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzNews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService authorService;
        public AuthorsController(IAuthorService authorService)
        {
            this.authorService= authorService;
        }

        #region GetAuthors
        [HttpGet("GetAuthors")]
        public async Task<IActionResult> GetAuthors()
        {
            var result = await authorService.GetAuthors();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region GetActiveAuthors
        [HttpGet("GetActiveAuthors")]
        public async Task<IActionResult> GetActiveAuthors()
        {
            var result = await authorService.GetActiveAuthors();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region AuthorsCountAsync
        [HttpGet("AuthorsCountAsync")]
        public async Task<IActionResult> AuthorsCountAsync()
        {
            var result = await authorService.AuthorsCountAsync();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region AddAsync
        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync(AuthorDto authorDto)
        {
            var result = await authorService.Add(authorDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region UpdateAsync
        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync(AuthorDto authorDto)
        {
            var result = await authorService.Update(authorDto);
            if (result.Success)
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
            var result = await authorService.ActivityAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
    }
}
