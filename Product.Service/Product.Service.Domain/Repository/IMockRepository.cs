using Product.Service.Domain.Entity;
using System.Collections.Generic;

namespace Product.Service.Domain.Repository
{
    /// <summary>
    /// <see cref="IMockRepository"/>
    /// </summary>
    public interface IMockRepository
    {
        IEnumerable<ProductEntity> GetRepository();
        int SaveChanges(ProductEntity product);
        void SetRepository();
    }
}
