using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.Concrete;
using System;


namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        IDataResult<About> GetAbout();
        Task<IDataResult<About>> GetAboutAsync();
        IDataResult<About> GetAboutById(int id);
        Task<IDataResult<About>> GetAboutByIdAsync(int id);
        IResult Update(About about);
    }
}
