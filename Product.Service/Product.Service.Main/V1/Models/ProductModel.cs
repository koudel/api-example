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
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Product name
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Product uri of image
        /// </summary>
        [Required]
        public Uri ImgUri { get; set; }
        /// <summary>
        /// Product price
        /// </summary>
        [Required]
        public decimal Price { get; set; }
        /// <summary>
        /// Product description
        /// </summary>
        public string Description { get; set; }
    }
}
