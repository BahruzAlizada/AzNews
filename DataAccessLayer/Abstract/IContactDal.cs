using Core.DataAccess;
using EntityLayer.Concrete;
using System;


namespace DataAccessLayer.Abstract
{
    public interface IContactDal : IRepositoryBase<Contact>
    {
        Task<List<Contact>> GetContactWithPaged(string search, int take, int page);
        Task<int> ContactCountAsync();
        Task<double> ContactPageCountAsync(double take);
    }
}
