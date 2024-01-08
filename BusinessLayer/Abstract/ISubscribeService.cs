

using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ISubscribeService
    {
        Task<IResult> SubscribeAsync(Subscribe subscribe);
        IResult UnSubscribe(string email);
    }
}
