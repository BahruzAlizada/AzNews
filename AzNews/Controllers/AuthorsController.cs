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

        #region GetAllAuthorsAsync
        [HttpGet("GetAllAuthorsAsync")]
        public async Task<IActionResult> GetAllAuthors()
        {
            var result = await authorService.GetAllAuthorsAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region GetAuthorListsAsync
        [HttpGet("GetAuthorListsAsync")]
        public async Task<IActionResult> GetAuthorListsAsync()
        {
            var result = await authorService.GetAuthorListsAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region GetActiveAuthorListsAsync
        [HttpGet("GetActiveAuthorListsAsync")]
        public async Task<IActionResult> GetActiveAuthorListsAsync()
        {
            var result = await authorService.GetActiveAuthorListsAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region GetActiveAuthorsAsync
        [HttpGet("GetActiveAuthorsAsync")]
        public async Task<IActionResult> GetActiveAuthorsAsync()
        {
            var result = await authorService.GetActiveAuthorsAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region GetCachingActiveAuthorsAsync
        [HttpGet("GetCachingActiveAuthorsAsync")]
        public async Task<IActionResult> GetCachingActiveAuthorsAsync()
        {
            var result = await authorService.GetCachingActiveAuthorsAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region AllAuthorsCountAsync
        [HttpGet("AllAuthorsCountAsync")]
        public async Task<IActionResult> AllAuthorsCountAsync()
        {
            int count = await authorService.AllAuthorsCountAsync();
            return Ok(count);
        }
        #endregion

        #region ActiveAuthorsCountAsync
        [HttpGet("ActiveAuthorsCountAsync")]
        public async Task<IActionResult> ActiveAuthorsCountAsync()
        {
            int count = await authorService.ActiveAuthorsCountAsync();
            return Ok(count);
        }
        #endregion

        #region GetAuthorByIdAsync
        [HttpGet("GetAuthorByIdAsync")]
        public async Task<IActionResult> GetAuthorByIdAsync(int? id)
        {
            var result = await authorService.GetAuthorByIdAsync(id);
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
            var result = await authorService.AddAsync(authorDto);
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
            var result = await authorService.UpdateAsync(authorDto);
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

        #region Delete
        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var result = authorService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
    }
}
