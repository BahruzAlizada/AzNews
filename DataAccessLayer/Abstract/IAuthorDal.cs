using Core.DataAccess;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;


namespace DataAccessLayer.Abstract
{
    public interface IAuthorDal : IRepositoryBase<Author>
    {
        Task ActivityAsync(int id);
        Task<List<Author>> GetAllAuthors();
        Task<List<Author>> GetActiveAuthors();
        Task<List<AuthorListDto>> GetAllAuthorLists();
        Task<List<AuthorListDto>> GetActiveAuthorLists();
    }
}
