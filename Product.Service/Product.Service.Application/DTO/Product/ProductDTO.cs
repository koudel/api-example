using System;
using System.Collections;
using System.Collections.Generic;

namespace Product.Service.Application.DTO.Product
{
    /// <summary>
    /// DTO for Product object
    /// </summary>
    public class ProductDTO
    {
        /// <summary>
        /// Unique identificator
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Product name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Product uri of image
        /// </summary>
        public Uri ImgUri { get; set; }
        /// <summary>
        /// Product price
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Product description
        /// </summary>
        public string Description { get; set; }
    }

    public class UpdateProductDescriptionDTO
    {
        /// <summary>
        /// Unique identificator
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Product description
        /// </summary>
        public string Description { get; set; }
    }

    public class GetProductDTO
    {
        /// <summary>
        /// Unique identificator
        /// </summary>
        public Guid Id { get; set; }
    }
}
