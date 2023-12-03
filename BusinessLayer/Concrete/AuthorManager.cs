using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Constants;
using BusinessLayer.ValidationRules.FluentValidation;
using CoreLayer.Aspects.Autofac.Validation;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;

namespace BusinessLayer.Concrete
{
    public class AuthorManager : IAuthorService
    {
        private readonly IAuthorDal authorDal;
        private readonly IMapper mapper;
        public AuthorManager(IAuthorDal authorDal,IMapper mapper)
        {
            this.authorDal = authorDal;
            this.mapper = mapper;
        }


        public async Task<IResult> ActivityAsync(int id)
        {
            await authorDal.ActivityAsync(id);
            return new SuccessResult(Messages.Status);
        }

        [ValidationAspect(typeof(AuthorValidator))]
        public async Task<IResult> AddAsync(AuthorDto authorDto)
        {
            Author author = mapper.Map<Author>(authorDto);
            await authorDal.AddAsync(author);
            return new SuccessResult(Messages.Added);
        }

        public async Task<IDataResult<int>> AuthorsCountAsync()
        {
            int count = await authorDal.AuthorsCountAsync();
            return new SuccessDataResult<int>();
        }

        public IResult Delete(int id)
        {
            Author author = authorDal.Get(x => x.Id == id);
            authorDal.Delete(author);
            return new SuccessResult(Messages.Deleted);
        }

        public async Task<IDataResult<List<AuthorListDto>>> GetActiveAuthors()
        {
            List<AuthorListDto> authorListDtos = await authorDal.GetActiveAuthors();
            return new SuccessDataResult<List<AuthorListDto>>(authorListDtos,Messages.GetAll);
        }

        public async Task<IDataResult<List<AuthorListDto>>> GetAuthors()
        {
            List<AuthorListDto> authorListDtos = await authorDal.GetAuthors();
            return new SuccessDataResult<List<AuthorListDto>>(authorListDtos, Messages.GetAll);
        }

        [ValidationAspect(typeof(AuthorValidator))]
        public async Task<IResult> UpdateAsync(AuthorDto authorDto)
        {
            Author author = mapper.Map<Author>(authorDto);
            await authorDal.UpdateAsync(author);
            return new SuccessResult(Messages.Updated);
        }
    }
}
