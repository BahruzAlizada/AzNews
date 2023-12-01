using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.Concrete;
using System;


namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        IDataResult<About> GetAbout();
        IDataResult<About> GetAboutById(int id);
        IResult Update(About about);
    }
}
