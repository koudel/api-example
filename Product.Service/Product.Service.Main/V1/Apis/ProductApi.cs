using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Product.Service.Main.V1.Models;
using Product.Service.Main.V1.Controllers;

namespace Product.Service.Main.V1.Apis
{
    /// <summary>
    /// Instance of Product Api
    /// </summary>
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("v{version}/[controller]/[action]")]
    public class Product : ControllerBase
    {
        private readonly ILogger<Product> _logger;
        private readonly IProductController _controller;

        private readonly int timeout = 2000;

        /// <summary>
        /// Constructor for Product Api
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="controller"></param>
        public Product(ILogger<Product> logger, IProductController controller)
        {
            _logger = logger;
            _controller = controller;
        }

        /// <summary>
        /// Get list of all stored products.
        /// </summary>
        /// <returns>List of all stored products.</returns>
        /// <response code="200">Returns requested products.</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<ProductModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var resp = _controller.GetAllProduct(this);
            if (await Task.WhenAny(resp, Task.Delay(timeout)) != resp)
            {
                _logger.LogInformation("Get operation took longer then {0}ms", timeout);
                await resp;
            }
            return resp.Result;
        }

        /// <summary>
        /// Get specific stored product.
        /// </summary>
        /// <param name="id">Unique identificator of product.</param>
        /// <returns>Returns requested product.</returns>
        /// <response code="200">Returns requested product.</response>
        /// <response code="404">Requested product not found.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<ProductModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public async Task<IActionResult> Get([FromRoute][Required] Guid id)
        {
            var resp = _controller.GetProduct(this, id);
            if (await Task.WhenAny(resp, Task.Delay(timeout)) != resp)
            {
                _logger.LogInformation("Get operation took longer then {0}ms", timeout);
                await resp;
            }
            return resp.Result;
        }

        /// <summary>
        /// Update description on selected product.
        /// </summary>
        /// <param name="id">Unique identificator of product.</param>
        /// <param name="description">New text used to describe the selected product.</param>
        /// <returns>Returns edited row from stored product.</returns>
        /// <response code="200">Requested product was updated. Returns edited row from stored product.</response>
        /// <response code="404">Requested product not found.</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateDescription([Required] Guid id, [FromBody][Required] string description)
        {
            var resp = _controller.UpdateProductDescription(this, id, description);
            if (await Task.WhenAny(resp, Task.Delay(timeout)) != resp)
            {
                _logger.LogInformation("Get operation took longer then {0}ms", timeout);
                await resp;
            }

            return resp.Result;
        }
    }
}
