using Core.DataAccess;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
namespace DataAccessLayer.Abstract
{
    public interface IBlogDal : IRepositoryBase<Blog>
    {
        Task<List<BlogListDto>> GetActiveBlogs(string search, int? catId, int? authId, int take);
        Task<int> BlogCountWithFilter(string search, int? catId, int? authId);
        Task<List<BlogListDto>> LoadMoreAsync(string search, int? catId, int? authId, int skipCount, int take);
        Task Activity(int id);
    }
}
