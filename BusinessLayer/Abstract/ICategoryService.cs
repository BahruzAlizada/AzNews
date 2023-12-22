using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        IResult Activity(int id);
        Task<IDataResult<List<CategoryListDto>>> GetAllCategoryListAsync();
        Task<IDataResult<List<CategoryListDto>>> GetActiveCategoryListAsync();
        Task<IDataResult<List<Category>>> GetAllCategoriesAsync();
        Task<IDataResult<List<Category>>> GetActiveCategoriesAsync();
        Task<IDataResult<List<Category>>> GetActiveCachingCategoriesAsync();
        IDataResult<Category> GetCategoryById(int? id);
        IResult Add(CategoryDto categoryDto);
        IResult Update(CategoryDto categoryDto);
        IResult Delete(int id);
        Task<int> ActiveCategoriesCountAsync();
        Task<int> AllCategoriesCountAsync();

    }
}
