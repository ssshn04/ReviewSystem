using FluentValidation;

namespace Application.Reviews.DTOs.Validators
{
    public class ReviewDTOValidator : AbstractValidator<ReviewDto>
    {
        public ReviewDTOValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User ID є обов'язковим.");

            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Product ID є обов'язковим.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Опис є обов'язковим.")
                .Length(1, 500).WithMessage("Опис має бути між 1 та 500 символами.");

            RuleFor(x => x.Rating)
                .InclusiveBetween(1, 5).WithMessage("Рейтинг має бути між 1 і 5.");
        }
    }
}
