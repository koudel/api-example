using MediatR;
using Product.Service.Application.DTO.Common;
using Product.Service.Application.DTO.Product;
using Product.Service.Application.DTO.Product.Extensions;
using Product.Service.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Product.Service.Application.UseCases.Query
{
    /// <summary>
    /// MediatRs handler for <see cref="GetAllProductQuery"/>
    /// </summary>
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, GetAllProductQueryResponse>
    {
        private readonly IMockRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllProductQueryHandler"/> class.
        /// </summary>
        /// <param name="IMockRepository">MockRepository</param>
        public GetAllProductQueryHandler(IMockRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Integration event handler for <see cref="GetAllProductQuery"/>
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GetAllProductQueryResponse> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var productEntities = _repository.GetRepository();

                var prodactDtos = new List<ProductDTO>();

                productEntities.ToList().ForEach(product => { prodactDtos.Add(product.MapToProductDTO()); });
                return new GetAllProductQueryResponse(productEntities.Select(s => s.MapToProductDTO()), new ResponseDTO()
                {
                    Result = ActionResult.SUCCESS
                });

            }
            catch (Exception ex)
            {
                return new GetAllProductQueryResponse(new ResponseDTO()
                {
                    Result = ActionResult.ERROR,
                    Message = ex.Message.ToString(),
                });
            }
        }
    }
}
