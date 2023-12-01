using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccessLayer.EntityFramework;

public class EFContactDal : EfRepositoryBase<Contact, Context>, IContactDal
{
    public async Task<int> ContactCountAsync()
    {
        using var context = new Context();

        int count = await context.Contacts.CountAsync();
        return count;
    }

    public async Task<double> ContactPageCountAsync(double take)
    {
        using var context = new Context();

        double pageCount = Math.Ceiling(await context.Contacts.CountAsync() / take);
        return pageCount;
    }

    public async Task<List<Contact>> GetContactWithPaged(string search, int take, int page)
    {
        using var context = new Context();

        List<Contact> contacts = await context.Contacts.OrderByDescending(x => x.Id).
            Skip((page - 1) * take).Take(take).ToListAsync();
        return contacts;
    }
}
