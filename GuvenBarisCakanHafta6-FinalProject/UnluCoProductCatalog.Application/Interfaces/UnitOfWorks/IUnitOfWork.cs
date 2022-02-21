using UnluCoProductCatalog.Application.Interfaces.Repositories;

namespace UnluCoProductCatalog.Application.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IColorRepository Color { get; }
        IOfferRepository Offer { get; }
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }
        IBrandRepository Brand { get; }
        IUsingStatusRepository UsingStatus { get; }
        IAccountDetailRepository AccountDetail { get;}
        bool SaveChanges();

    }
}
