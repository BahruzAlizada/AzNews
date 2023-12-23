using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;

namespace BusinessLayer.Abstract
{
    public interface IAuthorService
    {
        Task<IResult> ActivityAsync(int id);
        Task<int> ActiveAuthorsCountAsync();
        Task<int> AllAuthorsCountAsync();
        Task<IDataResult<List<AuthorListDto>>> GetAuthorListsAsync();
        Task<IDataResult<List<AuthorListDto>>> GetActiveAuthorListsAsync();
        Task<IDataResult<List<Author>>> GetAllAuthorsAsync();
        Task<IDataResult<List<Author>>> GetActiveAuthorsAsync();
        Task<IDataResult<List<Author>>> GetCachingActiveAuthorsAsync();
        Task<IDataResult<Author>> GetAuthorByIdAsync(int? id);
        Task<IResult> AddAsync(AuthorDto authorDto);
        Task<IResult> UpdateAsync(AuthorDto authorDto);
        IResult Delete(int id);
    }
}
