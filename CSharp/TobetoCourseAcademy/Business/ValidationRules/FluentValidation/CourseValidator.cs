using Entities.Concretes;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    //Doğrulama kuralları
    public class CourseValidator:AbstractValidator<Course>
    {
        public CourseValidator()
        {
            
        }
    }
}
