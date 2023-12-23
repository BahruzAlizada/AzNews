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
using Microsoft.Extensions.Caching.Memory;
using System;

namespace BusinessLayer.Concrete
{
    public class AuthorManager : IAuthorService
    {
        private readonly IAuthorDal authorDal;
        private readonly IMemoryCache memoryCache;
        private readonly IMapper mapper;
        public AuthorManager(IAuthorDal authorDal,IMemoryCache memoryCache,IMapper mapper)
        {
            this.authorDal = authorDal;
            this.memoryCache = memoryCache;
            this.mapper = mapper;
        }



        #region CountAsync
        public async Task<int> AllAuthorsCountAsync()
        {
            int count = await authorDal.GetCountAsync();
            return count;
        }

        public async Task<int> ActiveAuthorsCountAsync()
        {
            int count = await authorDal.GetCountAsync(x => !x.IsDeactive);
            return count;
        }
        #endregion

        #region Activity
        public async Task<IResult> ActivityAsync(int id)
        {
            await authorDal.ActivityAsync(id);
            return new SuccessResult(Messages.Status);
        }
        #endregion

        #region AddAsync
        [ValidationAspect(typeof(AuthorValidator))]
        public async Task<IResult> AddAsync(AuthorDto authorDto)
        {
            Author author = mapper.Map<Author>(authorDto);
            await authorDal.AddAsync(author);
            return new SuccessResult(Messages.Added);
        }
        #endregion

        #region Delete
        public IResult Delete(int id)
        {
            Author author = authorDal.Get(x => x.Id == id);
            authorDal.Delete(author);
            return new SuccessResult(Messages.Deleted);
        }
        #endregion

        #region GetActiveAuthorListsAsync
        public async Task<IDataResult<List<AuthorListDto>>> GetActiveAuthorListsAsync()
        {
            List<AuthorListDto> authorListDtos = await authorDal.GetActiveAuthorLists();
            return new SuccessDataResult<List<AuthorListDto>>(authorListDtos, Messages.GetAll);
        }
        #endregion

        #region GetAuthorListsAsync
        public async Task<IDataResult<List<AuthorListDto>>> GetAuthorListsAsync()
        {
            List<AuthorListDto> authorListDtos = await authorDal.GetAllAuthorLists();
            return new SuccessDataResult<List<AuthorListDto>>(authorListDtos, Messages.GetAll);
        }
        #endregion

        #region GetAllAuthorsAsync
        public async Task<IDataResult<List<Author>>> GetAllAuthorsAsync()
        {
            List<Author> authors = await authorDal.GetAllAuthors();
            return new SuccessDataResult<List<Author>>(authors, Messages.GetAll);
        }
        #endregion

        #region GetActiveAuthorsAsync
        public async Task<IDataResult<List<Author>>> GetActiveAuthorsAsync()
        {
            List<Author> authors = await authorDal.GetActiveAuthors();
            return new SuccessDataResult<List<Author>>(authors, Messages.GetAll);
        }
        #endregion

        #region GetCachingActiveAuthorsAsync
        public async Task<IDataResult<List<Author>>> GetCachingActiveAuthorsAsync()
        {
            const string cachedKey = "authors";
            List<Author> authors;

            if (!memoryCache.TryGetValue(cachedKey, out authors))
            {
                authors = await authorDal.GetActiveAuthors();

                memoryCache.Set(cachedKey, authors, new MemoryCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromMinutes(3),
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(9)
                });
            }

            return new SuccessDataResult<List<Author>>(authors, Messages.GetAll);
        }
        #endregion

        #region GetAuthorByIdAsync
        public async Task<IDataResult<Author>> GetAuthorByIdAsync(int? id)
        {
            Author author = await authorDal.GetAsync(x => x.Id == id);
            return new SuccessDataResult<Author>(author, Messages.GetByFilter);
        }
        #endregion

        #region Update
        [ValidationAspect(typeof(AuthorValidator))]
        public async Task<IResult> UpdateAsync(AuthorDto authorDto)
        {
            Author author = mapper.Map<Author>(authorDto);
            await authorDal.UpdateAsync(author);
            return new SuccessResult(Messages.Updated);
        }
        #endregion
    }
}
