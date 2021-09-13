using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Service.Domain.Entity
{
    public class ProductEntity
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
}
