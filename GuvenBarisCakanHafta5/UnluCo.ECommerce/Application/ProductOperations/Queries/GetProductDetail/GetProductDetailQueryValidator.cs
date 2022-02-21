using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace UnluCo.ECommerce.Application.ProductOperations.Queries.GetProductDetail
{
    public class GetProductDetailQueryValidator : AbstractValidator<GetProductDetailQuery>
    {
        public GetProductDetailQueryValidator()
        {

            RuleFor(p => p.ProductId).GreaterThan(0);
        }
    }
}
