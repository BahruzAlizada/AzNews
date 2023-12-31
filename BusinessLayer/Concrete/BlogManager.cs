﻿using AutoMapper;
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
using System.Security.Cryptography.X509Certificates;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal blogDal;
        private readonly IMapper mapper;
        public BlogManager(IBlogDal blogDal,IMapper mapper)
        {
            this.blogDal = blogDal;
            this.mapper = mapper;
        }



        public async Task<IResult> ActivityAsync(int id)
        {
            await blogDal.Activity(id);
            return new SuccessResult(Messages.Status);
        }


        [ValidationAspect(typeof(BlogValidator))]
        public async Task<IResult> AddAsync(BlogDto blogDto)
        {
            var result = BusinessRules.Run(CheckIfNameExist(blogDto.Name));
            if (result != null)
            {
                return result;
            }
            Blog blog = mapper.Map<Blog>(blogDto);
            await blogDal.AddAsync(blog);
            return new SuccessResult(Messages.Added);
        }

        public async Task<IDataResult<int>> BlogCountWithFilter(string search, int? catId, int? authId)
        {
            int blogCountWithFilter = await blogDal.BlogCountWithFilter(search, catId, authId);
            return new SuccessDataResult<int>(blogCountWithFilter);
        }

        public IResult Delete(int id)
        {
            Blog blog = blogDal.Get(x => x.Id == id);
            blogDal.Delete(blog);
            return new SuccessResult(Messages.Deleted);
        }

        public async Task<IDataResult<List<BlogListDto>>> GetActiveBlogs(string search, int? catId, int? authId, int take)
        {
            List<BlogListDto> blogListDtos = await blogDal.GetActiveBlogs(search, catId, authId, take);
            return new SuccessDataResult<List<BlogListDto>>(blogListDtos, Messages.GetAll);
        }

        public async Task<IDataResult<List<BlogListDto>>> LoadMoreAsync(string search, int? catId, int? authId, int skipCount, int take)
        {
            List<BlogListDto> blogListDtos = await blogDal.LoadMoreAsync(search, catId, authId, skipCount, take);
            return new SuccessDataResult<List<BlogListDto>>(blogListDtos,Messages.GetAll);
        }

        [ValidationAspect(typeof(BlogValidator))]
        public async Task<IResult> UpdateAsync(BlogDto blogDto)
        {
            var result = BusinessRules.Run(CheckIfNameExistForUpdate(blogDto.Id,blogDto.Name));
            if (result != null)
            {
                return result;
            }
            Blog blog = mapper.Map<Blog>(blogDto);
            await blogDal.UpdateAsync(blog);
            return new SuccessResult(Messages.Updated);
        }




        #region Business Rules
        private IResult CheckIfNameExist(string name)
        {
            var result = blogDal.GetAll().Any(x=>x.Name == name);
            if (result)
            {
                return new ErrorResult(Messages.NameExisted);
            }
            return new SuccessResult();
        }

        private IResult CheckIfNameExistForUpdate(int id, string name)
        {
            var result = blogDal.GetAll().Any(x => x.Name == name && x.Id != id);
            if (result)
            {
                return new ErrorResult(Messages.NameExisted);
            }
            return new SuccessResult();
        }
        #endregion

    }
}
