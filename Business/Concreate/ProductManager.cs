using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Caching;
using Core.Aspects.Secure;
using Core.Aspects.Transaction;
using Core.Aspects.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }   

        [ValidationAspect(typeof(ProductAddValidation))]
        [SecuredOperation("product.add")]
        [CacheRemoveAspect("IProductService.get")]
        [TransactionScopeAspect]
        public async Task<IResult> InsertAsync(Product product)
        {
            List<IResult> logics = new List<IResult>()
            {
                CheckIfProductCountOfCategoryCorrect(product.CategoryID)
            };

            var businessResult = BusinessRules.Run(logics);
            if (businessResult.Success)
            {
                var response = await _productDal.InsertAsync(product);
                if (response != 0)
                {
                    return new SuccessResult("Başarılı !");
                }
                else
                {
                    return new ErrorResult("Başarısız !");
                }
            }
            else
            {
                return new ErrorResult(businessResult.Message);
            }
            
        }
        private IResult CheckIfProductCountOfCategoryCorrect(int CategoryId)
        {
            var result = _productDal.CategoryCount(CategoryId);
            if (result > 10)
            {
                return new ErrorResult("Category Sayısı 10 dan büyük !");
            }
            return new SuccessResult();
        }
    }
}
