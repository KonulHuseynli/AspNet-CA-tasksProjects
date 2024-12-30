using Business.DTOs.Category.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validator.Category
{
    internal class CategoryCreateDTOValidator : AbstractValidator<CategoryCreateDto>
    {
        public CategoryCreateDTOValidator()
        {
            RuleFor(x => x.Title)
                .MinimumLength(3)
                .WithMessage("Title uzunluğu minimum 3 olmalıdır");
        }
    }
}
