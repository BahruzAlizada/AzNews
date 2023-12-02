using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.DTOs;
using System;

namespace BusinessLayer.Abstract
{
    public interface IAuthorService
    {
        Task<IResult> ActivityAsync(int id);
        Task<IDataResult<int>> AuthorsCountAsync();
        Task<IDataResult<List<AuthorListDto>>> GetAuthors();
        Task<IDataResult<List<AuthorListDto>>> GetActiveAuthors();
        Task<IResult> Add(AuthorDto authorDto);
        Task<IResult> Update(AuthorDto authorDto);
    }
}
