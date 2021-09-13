using Product.Service.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Product.Service.Domain.Repository
{
    public class MockRepository : IMockRepository
    {
        private List<ProductEntity> _repo = new List<ProductEntity>();

        public MockRepository()
        {
            SetRepository();
        }

        public IEnumerable<ProductEntity> GetRepository()
        {
            return _repo;
        }

        public void SetRepository()
        {
            _repo.Add(new ProductEntity() { Id = new Guid("5225ec77-f735-4f47-80a8-4957298d64f4"), Name = "Shoes", ImgUri = new Uri("https://3-cz-cdn.bata.eu/gallery/1/e/f/6/7/5.jpg"), Price = 200.60M, Description = "Best shoes." });
            _repo.Add(new ProductEntity() { Id = new Guid("258c42fb-3efa-4502-96fc-3fb2249e8384"), Name = "Tent", ImgUri = new Uri("https://www.ikea.com/cz/en/images/products/cirkustaelt-childrens-tent__0710148_pe727349_s5.jpg"), Price = 1500.56M, Description = "Best tent." });
            _repo.Add(new ProductEntity() { Id = new Guid("474091d2-cd78-4fd5-b449-5bf50b279078"), Name = "Car", ImgUri = new Uri("https://carsguide-res.cloudinary.com/image/upload/f_auto%2Cfl_lossy%2Cq_auto%2Ct_default/v1/editorial/story/hero_image/1908-Ford-Model-T_0.jpg"), Price = 5000000.90M, Description = "Best car ever." });
            _repo.Add(new ProductEntity() { Id = new Guid("c98560c1-5965-434d-8052-82bcd7dbf44f"), Name = "Phone", ImgUri = new Uri("https://cdn.alza.cz/Foto/f4/RI/RI075i1a.jpg"), Price = 22500.00M, Description = "Best phone." });
            _repo.Add(new ProductEntity() { Id = new Guid("fde06615-a930-4a9d-9680-32cd7ebcbda2"), Name = "Watches", ImgUri = new Uri("https://cdn.alza.cz/ImgW.ashx?fd=f4&cd=XI300i12e&i=1.jpg"), Price = 2000.81M, Description = "Best watches." });
        }

        public int SaveChanges(ProductEntity product)
        {
            int index =  _repo.FindIndex(a => a.Id == product.Id);

            if (index == -1)
            {
                return 0;
            }

            _repo[index].Name = product.Name;
            _repo[index].ImgUri = product.ImgUri;
            _repo[index].Price = product.Price;
            _repo[index].Description = product.Description;

            return 1;
        }
    }
}
