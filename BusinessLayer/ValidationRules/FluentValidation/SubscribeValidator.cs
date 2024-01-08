
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class SubscribeValidator : AbstractValidator<Subscribe>
    {
        public SubscribeValidator()
        {
            RuleFor(x=>x.Email).NotEmpty().WithMessage("Bu xana boş ola bilməz");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Düzgün email adresini yazın");
        }
    }
}
