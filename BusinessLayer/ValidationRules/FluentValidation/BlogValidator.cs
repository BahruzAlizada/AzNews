using EntityLayer.Concrete;
using FluentValidation;
using System;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x=>x.Image).NotEmpty().WithMessage("Bu xana boş ola bilməz");
            RuleFor(x=> x.Name).NotEmpty().WithMessage("Bu xana boş ola bilməz");
            RuleFor(x=> x.Description).NotEmpty().WithMessage("Bu xana boş ola bilməz");
        }
    }
}
