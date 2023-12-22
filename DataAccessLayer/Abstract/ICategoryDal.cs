using Core.DataAccess;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;

namespace DataAccessLayer.Abstract
{
    public interface ICategoryDal : IRepositoryBase<Category>
    {
        void Activity(int id);
        Task<List<CategoryListDto>> GetAllCategoryListAsync();
        Task<List<CategoryListDto>> GetActiveCategoryListAsync();
        Task<List<Category>> GetAllCategories();
        Task<List<Category>> GetActiveCategories();
    }
}
