using FluentValidation;
using VerstaTask.Models.Orders;

namespace VerstaTask.Validators;

public sealed class CreateOrderValidator : AbstractValidator<CreateOrderRequest>
{
    public CreateOrderValidator()
    {
        RuleFor(o => o.CityFrom).NotEmpty().MinimumLength(3);
        RuleFor(o => o.AddressFrom).NotEmpty().MinimumLength(3);
        RuleFor(o => o.CityTo).NotEmpty().MinimumLength(3);
        RuleFor(o => o.AddressTo).NotEmpty().MinimumLength(3);
        RuleFor(o => o.Weight).NotEmpty().GreaterThan(0);
        RuleFor(o => o.RecievingDate).NotEmpty();
    }
}
