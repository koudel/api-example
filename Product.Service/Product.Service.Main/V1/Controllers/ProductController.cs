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
    /// Instance of Product Controller
    /// </summary>
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("[controller]/[action]")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        /// <summary>
        /// Constructor for Product Controller
        /// </summary>
        /// <param name="logger"></param>
        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get list of all stored products.
        /// </summary>
        /// <returns>List of all stored products.</returns>
        /// <response code="200">Returns requested products.</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<ProductModel>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ProductModel>> GetAll()
        {
            return new List<ProductModel>();
        }

        /// <summary>
        /// Get specific stored product.
        /// </summary>
        /// <param name="id">Unique identification of product.</param>
        /// <returns>Returns requested product.</returns>
        /// <response code="200">Returns requested product.</response>
        /// <response code="404">Requested product not found.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<ProductModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public ActionResult<ProductModel> Get([Required] Guid id)
        {
            return new ProductModel();
        }

        /// <summary>
        /// Update description on selected product.
        /// </summary>
        /// <param name="id">Unique identification of product.</param>
        /// <param name="description">New text used to describe the selected product.</param>
        /// <response code="200">Requested product was updated.</response>
        /// <response code="404">Requested product not found.</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public void UpdateDescription([Required] Guid id, [Required] string description)
        {
        }
    }
}
