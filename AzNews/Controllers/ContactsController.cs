using BusinessLayer.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzNews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService contactService;
        public ContactsController(IContactService contactService)
        {
            this.contactService = contactService;   
        }

        #region AddAsync
        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync(Contact contact)
        {
            var result = await contactService.AddAsync(contact);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region GetContactWithPaged
        [HttpGet("GetContactWithPaged")]
        public async Task<IActionResult> GetContactWithPaged(int take, int page=1)
        {
            var result = await contactService.GetContactWithPagedAsync(take,page);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region ContactPageCountAsync
        [HttpGet("ContactPageCountAsync")]
        public async Task<IActionResult> ContactPageCountAsync(double take)
        {
            double pageCount = await contactService.ContactPageCountAsync(take);
            return Ok(pageCount);
        }
        #endregion

        #region ContactDetail
        [HttpGet("GetContactDetail/{id}")]
        public async Task<IActionResult> GetContactDetail(int id)
        {
            var result = await contactService.GetContactDetailById(id);
            if(result.Success )
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region ContactCountAsync
        [HttpGet("ContactCountAsync")]
        public async Task<IActionResult> ContactCountAsync()
        {
            int count = await contactService.ContactCountAsync();
            return Ok(count);
        }
        #endregion

        #region Delete
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = contactService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

    }
}
