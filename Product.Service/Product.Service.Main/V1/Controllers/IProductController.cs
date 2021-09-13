using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Product.Service.Main.V1.Models;

namespace Product.Service.Main.V1.Controllers
{
    /// <summary>
    /// Instance of Product Interface
    /// </summary>
    public interface IProductController
    {
        /// <summary>
        /// Get all stored products
        /// </summary>
        /// <param name="Base"></param>
        /// <returns></returns>
        Task<IActionResult> GetAllProduct(ControllerBase Base);
        /// <summary>
        /// Get specific product
        /// </summary>
        /// <param name="Base"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IActionResult> GetProduct(ControllerBase Base, Guid id);
        /// <summary>
        /// Update product description
        /// </summary>
        /// <param name="Base"></param>
        /// <param name="id"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        Task<IActionResult> UpdateProductDescription(ControllerBase Base, Guid id, string description);
    }
}
