using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Constants;
using BusinessLayer.ValidationRules.FluentValidation;
using CoreLayer.Aspects.Autofac.Validation;
using CoreLayer.Utilities.Business;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal categoryDal;
        private readonly IMemoryCache memoryCache;
        private readonly IMapper mapper;
        public CategoryManager(ICategoryDal categoryDal, IMemoryCache memoryCache, IMapper mapper)
        {
            this.categoryDal = categoryDal;
            this.memoryCache = memoryCache;
            this.mapper = mapper;
        }

        #region CountAsync
        public Task<int> AllCategoriesCountAsync()
        {
            return categoryDal.GetCountAsync();
        }

        public Task<int> ActiveCategoriesCountAsync()
        {
            return categoryDal.GetCountAsync(x => !x.IsDeactive);
        }
        #endregion

        #region Activity
        public IResult Activity(int id)
        {
            categoryDal.Activity(id);
            return new SuccessResult(Messages.Status);
        }
        #endregion

        #region Add
        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Add(CategoryDto categoryDto)
        {
            var result = BusinessRules.Run(CheckIfNameExisted(categoryDto.Name));
            if (result != null)
            {
                return result;
            }

            Category category = mapper.Map<Category>(categoryDto);
            category.IsDeactive = false;
            categoryDal.Add(category);
            return new SuccessResult(Messages.Added);
        }
        #endregion

        #region Delete
        public IResult Delete(int id)
        {
            Category category = categoryDal.Get(x => x.Id == id);
            categoryDal.Delete(category);
            return new SuccessResult(Messages.Deleted);
        }
        #endregion

        #region GetActiveCachingCategories
        public async Task<IDataResult<List<Category>>> GetActiveCachingCategoriesAsync()
        {
            const string cachedKey= "categories";
            List<Category> categories;

            if(!memoryCache.TryGetValue(cachedKey, out categories))
            {
                categories = await categoryDal.GetActiveCategories();

                memoryCache.Set(cachedKey, categories, new MemoryCacheEntryOptions
                {
                    SlidingExpiration=TimeSpan.FromMinutes(3),
                    AbsoluteExpirationRelativeToNow=TimeSpan.FromMinutes(9)
                });
            }

            return new SuccessDataResult<List<Category>>(categories,Messages.GetAll);
        }
        #endregion

        #region GetActiveCategoriesAsync
        public async Task<IDataResult<List<Category>>> GetActiveCategoriesAsync()
        {
            List<Category> categories = await categoryDal.GetActiveCategories();
            return new SuccessDataResult<List<Category>>(categories, Messages.GetAll);
        }
        #endregion

        #region GetActiveCategoryListAsync
        public async Task<IDataResult<List<CategoryListDto>>> GetActiveCategoryListAsync()
        {
            List<CategoryListDto> categoryListDtos = await categoryDal.GetActiveCategoryListAsync();
            return new SuccessDataResult<List<CategoryListDto>>(categoryListDtos, Messages.GetAll);
        }
        #endregion

        #region GetAllCategoriesAsync
        public async Task<IDataResult<List<Category>>> GetAllCategoriesAsync()
        {
            List<Category> categories = await categoryDal.GetAllCategories();
            return new SuccessDataResult<List<Category>>(categories, Messages.GetAll);
        }
        #endregion

        #region GetAllCategoryListAsync
        public async Task<IDataResult<List<CategoryListDto>>> GetAllCategoryListAsync()
        {
            List<CategoryListDto> categoryListDtos = await categoryDal.GetAllCategoryListAsync();
            return new SuccessDataResult<List<CategoryListDto>>(categoryListDtos, Messages.GetAll);
        }
        #endregion

        #region GetCategoryById
        public IDataResult<Category> GetCategoryById(int? id)
        {
            Category category = categoryDal.Get(x => x.Id == id);
            return new SuccessDataResult<Category>(category, Messages.GetByFilter);
        }
        #endregion

        #region Update
        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Update(CategoryDto categoryDto)
        {
            var result = BusinessRules.Run(CheckIfNameExistedForUpdated(categoryDto.Id, categoryDto.Name));
            if (result != null)
            {
                return result;
            }

            Category category = mapper.Map<Category>(categoryDto);
            categoryDal.Update(category);
            return new SuccessResult(Messages.Updated);
        }
        #endregion




        #region Business Rules
        private IResult CheckIfNameExisted(string name)
        {
            bool result = categoryDal.GetAll().Any(x => x.Name == name);
            if(result)
            {
                return new ErrorResult(Messages.NameExisted);
            }
            return new SuccessResult();
        }

        private IResult CheckIfNameExistedForUpdated(int id,string name)
        {
            bool result = categoryDal.GetAll().Any(x => x.Name == name && x.Id!=id);
            if (result)
            {
                return new ErrorResult(Messages.NameExisted);
            }
            return new SuccessResult();
        }
        #endregion

    }
}
