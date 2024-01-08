using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography.X509Certificates;

namespace DataAccessLayer.EntityFramework
{
    public class EFBlogDal : EfRepositoryBase<Blog, Context>, IBlogDal
    {
        #region Activity
        public async Task Activity(int id)
        {
            using var context = new Context();
            Blog blog = await context.Blogs.SingleOrDefaultAsync(x => x.Id == id);
            if (blog.IsDeactive)
                blog.IsDeactive = false;
            else
                blog.IsDeactive = true;

            await context.SaveChangesAsync();
        }
        #endregion

        #region BlogCountWithFilter
        public async Task<int> BlogCountWithFilter(string search, int? catId, int? authId)
        {
            using var context = new Context();

            int blogCount = await context.Blogs
            .Include(x => x.Author).Include(x => x.Category).Where(x => !x.IsDeactive
            && (search == null || x.Name.Contains(search) && (catId == null || x.CategoryId == catId)
            && (authId == null || x.AuthorId == authId))).OrderByDescending(x => x.Id).CountAsync();

            return blogCount;
        }
        #endregion

        #region GetActiveBlogs
        public async Task<List<BlogListDto>> GetActiveBlogs(string search, int? catId, int? authId, int take)
        {
            using var context = new Context();

            List<Blog> blogs = await context.Blogs
            .Include(x => x.Author).Include(x => x.Category).Where(x => !x.IsDeactive
            && (search == null || x.Name.Contains(search) && (catId == null || x.CategoryId == catId)
            && (authId == null || x.AuthorId == authId))).OrderByDescending(x => x.Id).Take(take).ToListAsync();

            List<BlogListDto> blogListDtos = new List<BlogListDto>();

            foreach (var item in blogs)
            {
                BlogListDto bld = new BlogListDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Image = item.Image,
                    Description = item.Description,
                    Seen = item.Seen,
                    Created = item.Created,
                    IsDeactive = item.IsDeactive
                };
                blogListDtos.Add(bld);
            }

            return blogListDtos;
        }
        #endregion

        #region LoadMoreAsync
        public async Task<List<BlogListDto>> LoadMoreAsync(string search, int? catId, int? authId, int skipCount, int take)
        {
            using var context = new Context();

            List<Blog> blogs = await context.Blogs
            .Include(x => x.Author).Include(x => x.Category).Where(x => !x.IsDeactive
            && (search == null || x.Name.Contains(search) && (catId == null || x.CategoryId == catId)
            && (authId == null || x.AuthorId == authId))).OrderByDescending(x => x.Id).Skip(skipCount).Take(take).ToListAsync();

            List<BlogListDto> blogListDtos = new List<BlogListDto>();

            foreach (var item in blogs)
            {
                BlogListDto bld = new BlogListDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Image = item.Image,
                    Description = item.Description,
                    Seen = item.Seen,
                    Created = item.Created,
                    IsDeactive = item.IsDeactive
                };
                blogListDtos.Add(bld);
            }

            return blogListDtos;
        }
        #endregion
    }
}
