using AutoMapper;
using UnluCo.ECommerce.Application.ProductOperations.Command.CreateProduct;
using UnluCo.ECommerce.Application.ProductOperations.Command.UpdateProduct;
using UnluCo.ECommerce.Application.ProductOperations.Queries.GetProductDetail;
using UnluCo.ECommerce.Application.ProductOperations.Queries.GetProducts;
using UnluCo.ECommerce.Application.ProductOperations.Queries.GetProductsByCategory;
using UnluCo.ECommerce.DbOperations;
using UnluCo.ECommerce.Entities;

namespace UnluCo.ECommerce.Common
{
    //AutoMapper kullanabilmek için Automapper 'ın Profile class'ın dan inherit almamız gerekmektedir.
    //Constructor'da tanımladığımız Map leme işlemlerini kullanabiliriz bu şekilde.
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductModel, Product>();
            CreateMap<Product, ProductsByCategoryModel>();
            CreateMap<UpdateProductModel, Product>();
            CreateMap<Product, ProductQueryModel>();
            CreateMap<Product, ProductDetailQueryModel>();

            //Manuel mapleme işlemi yaptık. O yüzden alttaki kısımları çıkarttık.
            //CreateMap<Product, ProductDetailQueryModel>();
        }
    }
}
