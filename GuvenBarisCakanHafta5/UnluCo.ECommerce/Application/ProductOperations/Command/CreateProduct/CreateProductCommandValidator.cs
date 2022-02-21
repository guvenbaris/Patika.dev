using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace UnluCo.ECommerce.Application.ProductOperations.Command.CreateProduct
{
    //Post işlemi için eklenecek olan ürünün validasyon kontrolü yapılmıştır.
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Model.ProductName).MinimumLength(2).NotEmpty();
            RuleFor(x => x.Model.StockAmount).GreaterThan(0);
            RuleFor(x => x.Model.UnitPrice).GreaterThan(0);
            RuleFor(x => x.Model.CategoryId).GreaterThan(0);
        }
    }
}
