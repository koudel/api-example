using Product.Service.Domain.Entity;

namespace Product.Service.Application.DTO.Product.Extensions
{
    /// <summary>
    /// <see cref="ProductExtensions"/>
    /// </summary>
    public static class ProductExtensions
    {
        /// <summary>
        /// Enables map <see cref="ProductEntity"/> into <see cref="ProductDTO"/>
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
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
