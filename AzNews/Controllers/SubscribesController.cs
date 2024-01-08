using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzNews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribesController : ControllerBase
    {
        private readonly ISubscribeService subscribeService;
        public SubscribesController(ISubscribeService subscribeService)
        {
            this.subscribeService= subscribeService;   
        }

        #region SubscribeAsync
        [HttpPost("SubscribeAsync")]
        public async Task<IActionResult> SubscribesAsync(Subscribe subscribe)
        {
            var result = await subscribeService.SubscribeAsync(subscribe);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region UnSubscribe
        [HttpDelete("UnSubscribe")]
        public IActionResult Delete(string email)
        {
            var result = subscribeService.UnSubscribe(email);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

    }
}
