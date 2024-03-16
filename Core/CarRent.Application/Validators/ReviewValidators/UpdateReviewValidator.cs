using CarRent.Application.Features.Mediator.Commands.ReviewCommands;
using FluentValidation;

namespace CarRent.Application.Validators.ReviewValidators
{
    public class UpdateReviewValidator : AbstractValidator<UpdateReviewCommand>
    {
        public UpdateReviewValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Lütfen müşteri adını boş geçmeyiniz.");
            RuleFor(x => x.CustomerName).MinimumLength(5).WithMessage("Lütfen en az 5 karakter veri girişi yapınız.");
            RuleFor(x => x.RaitingValue).NotEmpty().WithMessage("Lütfen puan değerini boş geçmeyiniz");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Lütfen yorum değerini boş geçmeyiniz");
            RuleFor(x => x.Comment).MinimumLength(50).WithMessage("Lütfen yorum kısmına en az 50 karakter veri girişi yapınız");
            RuleFor(x => x.Comment).MaximumLength(500).WithMessage("Lütfen yorum kısmına en fazla 500 karakter veri girişi yapınız");
            RuleFor(x => x.CustomerImage).NotEmpty().WithMessage("Lütfen müşteri görselini boş geçmeyiniz.").MinimumLength(10).WithMessage("Lütfen en az 10 karakter uzunluğunda veri girişi yapınız.");
        }
    }
}
