using Product.Service.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Service.Domain.Repository
{
    public interface IMockRepository
    {
        IEnumerable<ProductEntity> GetRepository();
        int SaveChanges(ProductEntity product);
        void SetRepository();
    }
}
