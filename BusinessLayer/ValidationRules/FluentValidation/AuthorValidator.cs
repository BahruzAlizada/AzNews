using EntityLayer.DTOs;
using FluentValidation;
using System;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class AuthorValidator : AbstractValidator<AuthorDto>
    {
        public AuthorValidator()
        {
            RuleFor(x=>x.FullName).NotEmpty().WithMessage("Bu xana boş ola bilməz");
        }
    }
}
