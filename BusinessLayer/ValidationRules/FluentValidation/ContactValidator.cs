using EntityLayer.Concrete;
using FluentValidation;
using System;


namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x=>x.FullName).NotEmpty().WithMessage("Bu xana boş ola bilməz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Bu xana boş ola bilməz");
            RuleFor(x=>x.Email).NotEmpty().WithMessage("Bu xana boş ola bilməz");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Düzgün elektron poçt ünvanınızı qeyd edin");
            RuleFor(x=>x.Message).NotEmpty().WithMessage("Bu xana boş ola bilməz");
        }
    }
}
