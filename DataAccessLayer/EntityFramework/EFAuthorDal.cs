using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
namespace DataAccessLayer.EntityFramework;

public class EFAuthorDal : EfRepositoryBase<Author, Context>, IAuthorDal
{
    #region Activity
    public async Task ActivityAsync(int id)
    {
        using var context = new Context();

        Author author = await context.Authors.SingleOrDefaultAsync(x => x.Id == id);
        List<Blog> blogs;

        if (author.IsDeactive)
        {
            author.IsDeactive = false;
            blogs = await context.Blogs.Where(x => x.AuthorId == id).ToListAsync();
            foreach (var item in blogs)
            {
                item.IsDeactive = false;
            }
        }
        else
        {
            author.IsDeactive = true;
            blogs = await context.Blogs.Where(x => x.AuthorId == id).ToListAsync();
            foreach (var item in blogs)
            {
                item.IsDeactive = true;
            }
        }

        await context.SaveChangesAsync();
    }
    #endregion

    public async Task<List<AuthorListDto>> GetActiveAuthorLists()
    {
        using var context = new Context();

        List<Author> authors = await context.Authors.Where(x=>!x.IsDeactive).OrderByDescending(x => x.Blogs.Count).ToListAsync();
        List<AuthorListDto> authorListDtos = new List<AuthorListDto>();

        foreach (var item in authors)
        {
            AuthorListDto ald = new AuthorListDto
            {
                Id = item.Id,
                Image = item.Image,
                FullName = item.FullName,
                Bio = item.Bio,
                BlogCount = await context.Blogs.Where(x => !x.IsDeactive && x.AuthorId == item.Id).CountAsync()
            };
            authorListDtos.Add(ald);
        }
        return authorListDtos;
    }

    public async Task<List<Author>> GetActiveAuthors()
    {
        using var context = new Context();

        List<Author> authors = await context.Authors.Where(x=>!x.IsDeactive).Select(x => new Author
        {
            Id = x.Id, Image = x.Image,
            FullName = x.FullName, IsDeactive = x.IsDeactive, Bio = x.Bio,
        }).ToListAsync();

        return authors;
    }

    public async Task<List<AuthorListDto>> GetAllAuthorLists()
    {
        using var context = new Context();
        
        List<Author> authors = await context.Authors.OrderByDescending(x=>x.Blogs.Count).ToListAsync();
        List<AuthorListDto> authorListDtos = new List<AuthorListDto>();

        foreach (var item in authors)
        {
            AuthorListDto ald = new AuthorListDto
            {
                Id = item.Id,
                Image = item.Image,
                FullName = item.FullName,
                Bio = item.Bio,
                BlogCount = await context.Blogs.Where(x => !x.IsDeactive && x.AuthorId == item.Id).CountAsync(),
                IsDeactive=item.IsDeactive
            };
            authorListDtos.Add(ald);
        }
        return authorListDtos;
    }

    public async Task<List<Author>> GetAllAuthors()
    {
        using var context = new Context();

        List<Author> authors = await context.Authors.Select(x => new Author
        {
            Id = x.Id, Image = x.Image,
            FullName = x.FullName, IsDeactive = x.IsDeactive, Bio = x.Bio,
        }).ToListAsync();

        return authors;
    }
}
