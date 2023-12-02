using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.DTOs;
using System;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        IResult Activity(int id);
        Task<IDataResult<List<CategoryListDto>>> GetAllCategories();
        Task<IDataResult<List<CategoryListDto>>> GetActiveCategories();
        IResult Add(CategoryDto categoryDto);
        IResult Update(CategoryDto categoryDto);
        IResult Delete(int id);
    }
}
