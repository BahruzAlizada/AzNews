using BusinessLayer.Abstract;
using BusinessLayer.Constants;
using BusinessLayer.ValidationRules.FluentValidation;
using CoreLayer.Aspects.Autofac.Validation;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal aboutDal;
        public AboutManager(IAboutDal aboutDal)
        {
            this.aboutDal= aboutDal;
        }


        public IDataResult<About> GetAbout()
        {
            return new SuccessDataResult<About>(aboutDal.Get(),Messages.GetByFilter);
        }

        public IDataResult<About> GetAboutById(int id)
        {
            return new SuccessDataResult<About>(aboutDal.Get(x => x.Id == id), Messages.GetByFilter);
        }

        [ValidationAspect(typeof(AboutValidator))]
        public IResult Update(About about)
        {
            aboutDal.Update(about);
            return new SuccessResult(Messages.Updated);
        }
    }
}
