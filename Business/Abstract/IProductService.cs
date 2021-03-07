using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll(); // tümünü getir.


        IDataResult<List<Product>> GetAllByCategoryId(int Id); // categroy id göre getir.

        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);

        IDataResult<List<ProductDetailDto>> GetProductDetails();

        IDataResult<Product> GetById(int productId); //tek başına ürün döndürür.

       IResult Add(Product product);

       IResult AddTransactionalTest(Product product);
    }
}