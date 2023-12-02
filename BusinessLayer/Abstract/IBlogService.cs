using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.DTOs;
using System;


namespace BusinessLayer.Abstract
{
    public interface IBlogService
    {
        Task<IDataResult<List<BlogListDto>>> GetActiveBlogs(string search, int? catId, int? authId, int take);
        Task<IDataResult<int>> BlogCountWithFilter(string search, int? catId, int? authId);
        Task<IDataResult<List<BlogListDto>>> LoadMoreAsync(string search, int? catId, int? authId, int skipCount, int take);
        Task<IResult> AddAsync(BlogDto blogDto);
        Task<IResult> UpdateAsync(BlogDto blogDto);
        IResult Delete(int id);
        Task<IResult> ActivityAsync(int id);
    }
}
