using EntityLayer.DTOs;
using FluentValidation;
using System;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<CategoryDto>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Bu xana boş ola bilməz");
        }
    }
}
