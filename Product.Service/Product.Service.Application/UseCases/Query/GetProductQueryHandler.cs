using MediatR;
using Product.Service.Application.DTO.Common;
using Product.Service.Application.DTO.Product.Extensions;
using Product.Service.Domain.Entity;
using Product.Service.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Product.Service.Application.UseCases.Query
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, GetProductQueryResponse>
    {
        private readonly IMockRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetProductQueryHandler"/> class.
        /// </summary>
        /// <param name="IMockRepository">MockRepository</param>
        public GetProductQueryHandler(IMockRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Integration event handler for GetProductQuery
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetProductQueryResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var product = _repository.GetRepository().Where(w => w.Id == request.Payload.Id).FirstOrDefault();

                if (EqualityComparer<ProductEntity>.Default.Equals(product, default(ProductEntity)))
                {
                    return new GetProductQueryResponse(new ResponseDTO()
                    {
                        Result = ActionResult.FAILED,
                        Message = "Product not found.",
                    });
                }

                return new GetProductQueryResponse(product.MapToProductDTO(), new ResponseDTO()
                {
                    Result = ActionResult.SUCCESS
                });

            }
            catch (Exception ex)
            {
                return new GetProductQueryResponse(new ResponseDTO()
                {
                    Result = ActionResult.ERROR,
                    Message = ex.Message.ToString(),
                });
            }
        }
    }
}
