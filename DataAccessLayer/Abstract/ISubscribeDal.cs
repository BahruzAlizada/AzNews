using Core.DataAccess;
using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface ISubscribeDal : IRepositoryBase<Subscribe>
    {
        void UnSubscribe(string email);
    }
}
