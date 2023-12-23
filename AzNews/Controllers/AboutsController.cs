using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzNews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService aboutService;
        public AboutsController(IAboutService aboutService)
        {
            this.aboutService = aboutService;
        }

        #region GetAbout
        [HttpGet("GetAbout")]
        public IActionResult GetAbout()
        {
            var result = aboutService.GetAbout();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region GetAboutAsync
        [HttpGet("GetAboutAsync")]
        public async Task<IActionResult> GetAboutAsync()
        {
            var result = await aboutService.GetAboutAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region GetAboutById
        [HttpGet("GetAboutById/{id}")]
        public IActionResult GetAboutById(int id)
        {
            var result = aboutService.GetAboutById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region GetAboutByIdAsync
        [HttpGet("GetAboutByIdAsync")]
        public async Task<IActionResult> GetAboutByIdAsync(int id)
        {
            var result = await aboutService.GetAboutByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region Update
        [HttpPut("Update")]
        public IActionResult Update(int id, About about)
        {
            var result = aboutService.Update(about);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
    }
}
