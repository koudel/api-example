using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product.Service.Application.DTO.Product;
using Product.Service.Application.UseCases.Command.Update;
using Product.Service.Application.UseCases.Query;
using Product.Service.Main.V1.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Service.Main.V1.Controllers
{
    /// <summary>
    /// Instance of <see cref="ProductController"/>
    /// </summary>
    public class ProductController : IProductController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        /// <summary>
        /// <see cref="ProductController"/>
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
        /// Get all stored products
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
                return Base.NotFound();
            }
            else
            {
                return Base.StatusCode(500);
            }
        }

        /// <summary>
        /// Get specific stored product
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
                return Base.NotFound();
            }
            else
            {
                return Base.StatusCode(500);
            }
        }

        /// <summary>
        /// Update description on product based on ID
        /// </summary>
        /// <param name="Base"></param>
        /// <param name="id"></param>
        /// <param name="description"></param>
        /// <returns></returns>
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
                return Base.NotFound();
            }
            else
            {
                return Base.StatusCode(500);
            }
        }
    }
}
