using Core.DataAccess.EntityFramework;
using CoreLayer.Utilities.Results.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EFSubscribeDal : EfRepositoryBase<Subscribe, Context>, ISubscribeDal
    {
        public void UnSubscribe(string email)
        {
            using var context = new Context();
            Subscribe? subscribe = context.Subscribes.FirstOrDefault(x=>x.Email==email);
            if (subscribe is null)
            {
                throw new Exception("Bu cür email abunə olmayıb");
            }

            context.Subscribes.Remove(subscribe);
            context.SaveChanges();
        }
    }
}
