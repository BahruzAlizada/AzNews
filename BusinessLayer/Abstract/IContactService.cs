using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.Concrete;
using System;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        Task<IDataResult<List<Contact>>> GetContactWithPaged(string search, int take, int page);
        Task<int> ContactCountAsync();
        Task<double> ContactPageCountAsync(double take);
        Task<IResult> AddAsync(Contact contact);
        IResult Delete(int id);
        
    }
}
