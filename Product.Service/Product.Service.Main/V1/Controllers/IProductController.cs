using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Product.Service.Main.V1.Controllers
{
    /// <summary>
    /// Instance of <see cref="IProductController"/>
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
