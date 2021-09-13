using Product.Service.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Service.Application.DTO.Product.Extensions
{
    public static class ProductExtensions
    {
        public static ProductDTO MapToProductDTO(this ProductEntity entity)
        {
            return new ProductDTO()
            {
                Id = entity.Id,
                Name = entity.Name,
                ImgUri = entity.ImgUri,
                Price = entity.Price,
                Description = entity.Description
            };
        }
    }
}
