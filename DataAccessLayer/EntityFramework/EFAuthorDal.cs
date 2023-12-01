using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography.X509Certificates;

namespace DataAccessLayer.EntityFramework;

public class EFAuthorDal : EfRepositoryBase<Author, Context>, IAuthorDal
{
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

    public Task<double> AuthorsCountAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<AuthorListDto>> GetActiveAuthors()
    {
        throw new NotImplementedException();
    }

    public Task<List<AuthorListDto>> GetAuthors()
    {
        throw new NotImplementedException();
    }
}
