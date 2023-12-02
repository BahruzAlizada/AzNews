using BusinessLayer.Abstract;
using EntityLayer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzNews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        #region GetAllCategories
        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await categoryService.GetAllCategories();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region GetActiveCategories
        [HttpGet("GetActiveCategories")]
        public async Task<IActionResult> GetActiveCategories()
        {
            var result = await categoryService.GetActiveCategories();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region Add
        [HttpPost("Add")]
        public IActionResult Add(CategoryDto categoryDto)
        {
            var result = categoryService.Add(categoryDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region Update
        [HttpPut("Update")]
        public IActionResult Update(CategoryDto categoryDto)
        {
            var result = categoryService.Update(categoryDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region Activity
        [HttpGet("Activity/{id}")]
        public IActionResult Activity(int id)
        {
            var result = categoryService.Activity(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
    }
}
