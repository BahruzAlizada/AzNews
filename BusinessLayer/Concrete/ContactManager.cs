using BusinessLayer.Abstract;
using BusinessLayer.Constants;
using BusinessLayer.ValidationRules.FluentValidation;
using CoreLayer.Aspects.Autofac.Validation;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal contactDal;
        public ContactManager(IContactDal contactDal)
        {
            this.contactDal = contactDal;
        }


        [ValidationAspect(typeof(ContactValidator))]
        public async Task<IResult> AddAsync(Contact contact)
        {
            await contactDal.AddAsync(contact);
            return new SuccessResult(Messages.Added);
        }

        public async Task<int> ContactCountAsync()
        {
            return await contactDal.GetCountAsync();
        }

        public async Task<double> ContactPageCountAsync(double take)
        {
            return await contactDal.ContactPageCountAsync(take);
        }

        public IResult Delete(int id)
        {
            Contact contact = contactDal.Get(x => x.Id == id);
            contactDal.Delete(contact);
            return new SuccessResult(Messages.Deleted);
        }

        public async Task<IDataResult<Contact>> GetContactDetailById(int id)
        {
            Contact contact = await contactDal.GetAsync(x=>x.Id==id);
            return new SuccessDataResult<Contact>(contact, Messages.GetByFilter);
        }

        public async Task<IDataResult<List<Contact>>> GetContactWithPagedAsync(int take, int page)
        {
            List<Contact> contacts = await contactDal.GetContactWithPagedAsync(take, page);
            return new SuccessDataResult<List<Contact>>(contacts, Messages.GetAll);
        }

    }
}
