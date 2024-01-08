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
    public class EFCategoryDal : EfRepositoryBase<Category, Context>, ICategoryDal
    {
        public void Activity(int id)
        {
            using var context = new Context();
            Category category = context.Categories.SingleOrDefault(c => c.Id == id);
            if (category.IsDeactive)
                category.IsDeactive = false;
            else
                category.IsDeactive = true;

            context.SaveChanges();
        }

        public async Task<List<Category>> GetActiveCategories()
        {
            using var context = new Context();

            List<Category> categories = await context.Categories.Where(x=>!x.IsDeactive).
                Select(c=> new Category { Id=c.Id,Name=c.Name}).ToListAsync();
            return categories;
        }

        public async Task<List<CategoryListDto>> GetActiveCategoryListAsync()
        {
            using var context = new Context();

            List<Category> categories = await context.Categories.Where(x=>!x.IsDeactive).Include(x => x.Blogs).OrderByDescending(x => x.Blogs.Count()).
                Select(x => new Category {Id=x.Id, Name=x.Name}).ToListAsync();
            List<CategoryListDto> categoryListDtos = new List<CategoryListDto>();

            foreach (var item in categories)
            {
                CategoryListDto cld = new CategoryListDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    IsDeactive = item.IsDeactive,
                    BlogCount = await context.Blogs.Where(x => !x.IsDeactive && x.CategoryId == item.Id).CountAsync()
                };
                categoryListDtos.Add(cld);
            }

            return categoryListDtos;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            using var context = new Context();

            List<Category> categories = await context.Categories.
               Select(c => new Category { Id = c.Id, Name = c.Name, IsDeactive = c.IsDeactive }).ToListAsync();
            return categories;
        }

        public async Task<List<CategoryListDto>> GetAllCategoryListAsync()
        {
            using var context = new Context();

            List<Category> categories = await context.Categories.Include(x => x.Blogs).OrderByDescending(x => x.Blogs.Count()).ToListAsync();
            List<CategoryListDto> categoryListDtos = new List<CategoryListDto>();

            foreach  (var item in categories)
            {
                CategoryListDto cld = new CategoryListDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    IsDeactive = item.IsDeactive,
                    BlogCount = await context.Blogs.Where(x => !x.IsDeactive && x.CategoryId == item.Id).CountAsync()
                };
                categoryListDtos.Add(cld);
            }

            return categoryListDtos;
        }
    }
}
