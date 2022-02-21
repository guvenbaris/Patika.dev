using System.Collections.Generic;
using System.Threading.Tasks;
using UnluCoProductCatalog.Application.ViewModels.ProductViewModels;
using UnluCoProductCatalog.Domain.Entities;

namespace UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces
{
    public interface IProductService
    {
        IEnumerable<GetProductViewModel> GetAll();
        void RetractTheOffer(int productId);
        void SellProduct(int productId, string userId, double price);
        void Create(CreateProductViewModel entity,string userId);
        void UpdateIsOfferable(int id);
    }
}