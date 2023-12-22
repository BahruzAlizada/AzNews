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

        #region GetAllCategoryListAsync
        [HttpGet("GetAllCategoryListAsync")]
        public async Task<IActionResult> GetAllCategoryListAsync()
        {
            var result = await categoryService.GetAllCategoryListAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region GetAllCategories
        [HttpGet("GetAllCategoriesAsync")]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var result = await categoryService.GetAllCategoriesAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region GetActiveCategoryListAsync
        [HttpGet("GetActiveCategoryListAsync")]
        public async Task<IActionResult> GetActiveCategoryListAsync()
        {
            var result = await categoryService.GetActiveCategoryListAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region GetActiveCategories
        [HttpGet("GetActiveCategoriesAsync")]
        public async Task<IActionResult> GetActiveCategoriesAsync()
        {
            var result = await categoryService.GetActiveCategoriesAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region GetActiveCachingCategoriesAsync
        [HttpGet("GetActiveCachingCategoriesAsync")]
        public async Task<IActionResult> GetActiveCachingCategoriesAsync()
        {
            var result = await categoryService.GetActiveCachingCategoriesAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region GetCategoryById
        [HttpGet("GetCategoryById")]
        public IActionResult GetCategoryById(int? id)
        {
            var result =  categoryService.GetCategoryById(id);
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

        #region Delete
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = categoryService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region CountAsync
        [HttpGet("AllCategoriesCountAsync")]
        public async Task<IActionResult> AllCategoriesCountAsync()
        {
            var count = await categoryService.AllCategoriesCountAsync();
            return Ok(count);
        }

        [HttpGet("ActiveCategoriesCountAsync")]
        public async Task<IActionResult> ActiveCategoriesCountAsync()
        {
            var count = await categoryService.ActiveCategoriesCountAsync();
            return Ok(count);
        }
        #endregion
    }
}
