using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace UnluCo.ECommerce.Application.ProductOperations.Command.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Model.ProductName).MinimumLength(2).NotEmpty();
            RuleFor(x => x.Model.StockAmount).GreaterThan(0);
            RuleFor(x => x.Model.UnitPrice).GreaterThan(0);
            RuleFor(x => x.Model.CategoryId).GreaterThan(0);
        }
    }
}
