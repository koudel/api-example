using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Service.Main.V1.Models
{
    /// <summary>
    /// Model class for Product object
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// Unique identificator
        /// </summary>
        /// <example>4824d9e7-8ca5-4f67-8fa8-ff0542914cb0</example>
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Product name
        /// </summary>
        /// <example>Awesome shoes</example>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Product uri of image
        /// </summary>
        /// <example>foo://example.com:1234/over/there.png</example>
        [Required]
        public Uri ImgUri { get; set; }
        /// <summary>
        /// Product price
        /// </summary>
        /// <example>20.51</example>
        [Required]
        public decimal Price { get; set; }
        /// <summary>
        /// Product description
        /// </summary>
        /// <example>These are best shoes you will ever have.</example>
        public string Description { get; set; }
    }
}
