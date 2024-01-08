
using BusinessLayer.Abstract;
using BusinessLayer.Constants;
using BusinessLayer.Helper;
using BusinessLayer.ValidationRules.FluentValidation;
using CoreLayer.Aspects.Autofac.Validation;
using CoreLayer.Utilities.Business;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class SubscribeManager : ISubscribeService
    {
        private readonly ISubscribeDal subscribeDal;
        public SubscribeManager(ISubscribeDal subscribeDal)
        {
            this.subscribeDal = subscribeDal;
        }

        [ValidationAspect(typeof(SubscribeValidator))]
        public async Task<IResult> SubscribeAsync(Subscribe subscribe)
        {
            var result = BusinessRules.Run(CheckIfNameExist(subscribe.Email));
            if (result != null)
            {
                return result;
            }
            await subscribeDal.AddAsync(subscribe);
            await SendMail.SendMailAsync("Xoş gəlmisiniz", "Abunə olundu", subscribe.Email);
            return new SuccessResult(Messages.Subscribed);
        }

        public IResult UnSubscribe(string email)
        {
            subscribeDal.UnSubscribe(email);
            return new SuccessResult("Abunəlik ləğv edildi");
        }



        #region Business Rules
        private IResult CheckIfNameExist(string email)
        {
            var result = subscribeDal.GetAll().Any(x => x.Email == email);
            if (result)
            {
                return new ErrorResult(Messages.NameExisted);
            }
            return new SuccessResult();
        }
        #endregion

    }
}
