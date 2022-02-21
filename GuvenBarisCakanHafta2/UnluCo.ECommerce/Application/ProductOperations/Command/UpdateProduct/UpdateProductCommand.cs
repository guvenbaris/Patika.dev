using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using UnluCo.ECommerce.DbOperations;
using UnluCo.ECommerce.Extensions;

namespace UnluCo.ECommerce.Application.ProductOperations.Command.UpdateProduct
{
    //Product Update işlemi için yazılmıştır.
    public class UpdateProductCommand
    {
        private readonly IMapper _mapper;

        public UpdateProductModel Model { get; set; }
        public int ProductId { get; set; }
        public UpdateProductCommand(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void Handle()
        {
            var product = DataGenerator.ProductList.SingleOrDefault(p => p.ProductId == ProductId);
            if (product is null)
            {
                throw new InvalidOperationException("Product has not been in exist");
            }
            //string extension yazılmıştır. ProductName için
            product.ProductName = Model.ProductName.IsNull() != default ? Model.ProductName : product.ProductName;
            product.UnitPrice = Model.UnitPrice != default ? Model.UnitPrice : product.UnitPrice;
            product.StockAmount = Model.StockAmount != default ? Model.StockAmount : product.StockAmount;
            product.CategoryId = Model.CategoryId != default ? Model.CategoryId : product.CategoryId;
        }
    }

    //Map edilecek Model tanımlanmıştır.
    public class UpdateProductModel
    {
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockAmount { get; set; }
    }
}
