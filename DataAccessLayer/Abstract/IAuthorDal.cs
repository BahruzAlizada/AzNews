using Core.DataAccess;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;


namespace DataAccessLayer.Abstract
{
    public interface IAuthorDal : IRepositoryBase<Author>
    {
        Task ActivityAsync(int id);
        Task<int> AuthorsCountAsync();
        Task<List<AuthorListDto>> GetAuthors();
        Task<List<AuthorListDto>> GetActiveAuthors();
    }
}
