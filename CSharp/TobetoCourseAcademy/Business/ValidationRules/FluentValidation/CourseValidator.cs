using Entities.Concretes;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    //Doğrulama kuralları
    //AbstractValidator, IValidator'ü kendine implement eder.
    //Burada CourseValidatorun Course için geçerli olduğunu base sınıf olan AbstractValidator<Course> generic ifadesi kısmında belirtiyoruz.
    public class CourseValidator : AbstractValidator<Course>
    {
        public CourseValidator()
        {
            RuleFor(c => c.Name).NotNull();
            RuleFor(c => c.Name).MinimumLength(2);
            RuleFor(c => c.Price).GreaterThan(0);
            RuleFor(c => c.Price).GreaterThanOrEqualTo(10).When(c => c.CategoryId == 1);
            RuleFor(c => c.Name).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı!");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
