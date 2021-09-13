using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Product.Service.Main.V1.Models;
using MediatR;
using AutoMapper;
using Product.Service.Application.DTO.Product;
using Product.Service.Application.UseCases.Command.Update;
using Product.Service.Application.UseCases.Query;

namespace Product.Service.Main.V1.Controllers
{
    /// <summary>
    /// Instance of Product Controller
    /// </summary>
    public class ProductController : IProductController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        /// <summary>
        /// ProductController
        /// </summary>
        /// <param name="mediator"></param>
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;

            var mc = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductModel, ProductDTO>().ReverseMap();
            });

            mc.AssertConfigurationIsValid();
            _mapper = mc.CreateMapper();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Base"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetAllProduct(ControllerBase Base)
        {
            var qry = new GetAllProductQuery();

            var response = await _mediator.Send(qry);

            if (response.Response.Result == ActionResult.SUCCESS)
            {
                var resp = response.Payload.Select(s => _mapper.Map<ProductDTO, ProductModel>(s));
                return Base.Ok(resp);
            }
            else if (response.Response.Result == ActionResult.FAILED)
            {
                Base.Response.StatusCode = StatusCodes.Status404NotFound;
                return Base.NotFound();
            }
            else
            {
                Base.Response.StatusCode = StatusCodes.Status500InternalServerError;
                return Base.StatusCode(500);
            }
        }

        /// <summary>
        /// Get specific product
        /// </summary>
        /// <param name="Base"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetProduct(ControllerBase Base, Guid id)
        {
            var dto = new GetProductDTO() { Id = id };
            var qry = new GetProductQuery(dto);

            var response = await _mediator.Send(qry);

            if (response.Response.Result == ActionResult.SUCCESS)
            {
                var resp = _mapper.Map<ProductDTO, ProductModel>(response.Payload);
                return Base.Ok(resp);
            }
            else if (response.Response.Result == ActionResult.FAILED)
            {
                Base.Response.StatusCode = StatusCodes.Status404NotFound;
                return Base.NotFound();
            }
            else
            {
                Base.Response.StatusCode = StatusCodes.Status500InternalServerError;
                return Base.StatusCode(500);
            }
        }

        public async Task<IActionResult> UpdateProductDescription(ControllerBase Base, Guid id, string description)
        {
            var dto = new UpdateProductDescriptionDTO() { Id = id, Description = description };
            var cmd = new UpdateProductDescriptionCommand(dto);

            var response = await _mediator.Send(cmd);

            if (response.Response.Result == ActionResult.SUCCESS)
            {
                var resp = _mapper.Map<ProductDTO, ProductModel>(response.Payload);
                return Base.Ok(resp);
            }
            else if (response.Response.Result == ActionResult.FAILED)
            {
                Base.Response.StatusCode = StatusCodes.Status404NotFound;
                return Base.NotFound();
            }
            else
            {
                Base.Response.StatusCode = StatusCodes.Status500InternalServerError;
                return Base.StatusCode(500);
            }
        }
    }
}
