﻿using FluentValidation;
using UnluCoProductCatalog.Application.ViewModels.CategoryViewModels;

namespace UnluCoProductCatalog.Application.Validations.CategoryValidation
{
    public class CommandCategoryViewModelValidator : AbstractValidator<CommandCategoryViewModel>
    {
        public CommandCategoryViewModelValidator()
        {
            RuleFor(c => c.CategoryName).NotEmpty().WithMessage("Category name is required");
        }
    }
}
