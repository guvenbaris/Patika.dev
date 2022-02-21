using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using UnluCoProductCatalog.Application.Exceptions;
using UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces;
using UnluCoProductCatalog.Application.Interfaces.UnitOfWorks;
using UnluCoProductCatalog.Application.Validations.ProductValidation;
using UnluCoProductCatalog.Application.ViewModels.ProductViewModels;
using UnluCoProductCatalog.Domain.Entities;

namespace UnluCoProductCatalog.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable< GetProductViewModel> GetAll()
        {
            var products = _unitOfWork.Product.GetProducts();

            return _mapper.Map<IEnumerable<GetProductViewModel>>(products);
        }

        public void RetractTheOffer(int offerId)
        {
            var offer = _unitOfWork.Offer.GetById(offerId);

            if (offer is null)
            {
                throw new NotFoundExceptions("Offer", offerId);
            }

            offer.IsDeleted = true;

            _unitOfWork.Offer.Update(offer);

            if (!_unitOfWork.SaveChanges())
            {
                throw new NotSavedExceptions("Offer");
            }
        }

        public void SellProduct(int productId, string userId,double price)
        {
            var product = _unitOfWork.Product.GetById(productId);

            if (product is null)
            {
                throw new NotFoundExceptions("Product", productId);
            }
            
            if (product.Price > price)
            {
                throw new InvalidOperationException("Price is not enough");
            }

            if (product.IsOfferable)
            {
                throw new InvalidOperationException("Product is not offerable");
            }

            product.IsSold = true;
            product.UserId = userId;
            
            _unitOfWork.Product.Update(product);
            if (!_unitOfWork.SaveChanges())
            {
                throw new NotSavedExceptions("Product");
            }
        }

        public void Create(CreateProductViewModel entity,string userId)
        {
            var validator = new CreateProductViewModelValidator();

            validator.ValidateAndThrow(entity);

            var product = _mapper.Map<Product>(entity);

            product.IsSold = false;
            product.IsOfferable = false;
            product.UserId = userId;

            _unitOfWork.Product.Create(product);
            if (!_unitOfWork.SaveChanges())
            {
                throw new NotSavedExceptions("Product");
            }
        }

        public void UpdateIsOfferable(int id)
        {
            var product = _unitOfWork.Product.GetById(id);

            if (product is null)
                throw new NotFoundExceptions("Product", id);

            product.IsOfferable = true;
            _unitOfWork.Product.Update(product);
            if (!_unitOfWork.SaveChanges())
            {
                throw new NotSavedExceptions("Product");
            }
        }
    }
}
