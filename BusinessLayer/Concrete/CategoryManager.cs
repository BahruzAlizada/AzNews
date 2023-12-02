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
using System;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal categoryDal;
        private readonly IMapper mapper;
        public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
        {
            this.categoryDal = categoryDal;
            this.mapper = mapper;
        }


        public IResult Activity(int id)
        {
            categoryDal.Activity(id);
            return new SuccessResult(Messages.Status);
        }

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

        public IResult Delete(int id)
        {
            Category category = categoryDal.Get(x => x.Id == id);
            categoryDal.Delete(category);
            return new SuccessResult(Messages.Deleted);
        }

        public async Task<IDataResult<List<CategoryListDto>>> GetActiveCategories()
        {
            List<CategoryListDto> categoryListDtos = await categoryDal.GetActiveCategories();
            return new SuccessDataResult<List<CategoryListDto>>(categoryListDtos,Messages.GetAll);
        }

        public async Task<IDataResult<List<CategoryListDto>>> GetAllCategories()
        {
            List<CategoryListDto> categoryListDtos = await categoryDal.GetAllCategories();
            return new SuccessDataResult<List<CategoryListDto>>(categoryListDtos, Messages.GetAll);
        }

        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Update(CategoryDto categoryDto)
        {
            var result = BusinessRules.Run(CheckIfNameExistedForUpdated(categoryDto.Id, categoryDto.Name));
            if(result != null)
            {
                return result;
            }

            Category category = mapper.Map<Category>(categoryDto);
            categoryDal.Update(category);
            return new SuccessResult(Messages.Updated);
        }


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
