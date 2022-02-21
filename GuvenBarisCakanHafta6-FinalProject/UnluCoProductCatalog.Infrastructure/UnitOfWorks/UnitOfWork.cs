using UnluCoProductCatalog.Application.Interfaces.Repositories;
using UnluCoProductCatalog.Application.Interfaces.UnitOfWorks;
using UnluCoProductCatalog.Infrastructure.Contexts;

namespace UnluCoProductCatalog.Infrastructure.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ProductCatalogDbContext _context;


        public IColorRepository Color { get; }
        public IOfferRepository Offer { get; }
        public IProductRepository Product { get; }
        public ICategoryRepository Category { get; }
        public IBrandRepository Brand { get; }
        public IUsingStatusRepository UsingStatus { get; }
        public IAccountDetailRepository AccountDetail { get; }


        public UnitOfWork(IColorRepository color, IOfferRepository offer, IProductRepository product,
            ICategoryRepository category, IBrandRepository brand, IUsingStatusRepository usingStatus,
            IAccountDetailRepository accountDetail, ProductCatalogDbContext context)
        {
            _context = context;
            Color = color;
            Offer = offer;
            Product = product;
            Category = category;
            Brand = brand;
            UsingStatus = usingStatus;
            AccountDetail = accountDetail;
        }

        public bool SaveChanges() => _context.SaveChanges() > 0;
    }
}

