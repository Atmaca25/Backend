using Entities.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductAddValidation : AbstractValidator<Product>
    {
        public ProductAddValidation()
        {
            RuleFor(r => r.ProductName).MinimumLength(5);
        }
    }
}
