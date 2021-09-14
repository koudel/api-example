using MediatR;
using Product.Service.Application.DTO.Product;

namespace Product.Service.Application.UseCases.Query
{
    /// <summary>
    /// MediatRs request for <see cref="GetProductQuery"/> 
    /// </summary>
    public class GetProductQuery : IRequest<GetProductQueryResponse>
    {
        /// <summary>
        /// The payload of the message
        /// </summary>
        public GetProductDTO Payload { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetProductQuery"/> class.
        /// </summary>
        /// <param name="payload"></param>
        public GetProductQuery(GetProductDTO payload)
        {
            Payload = payload;
        }
    }
}
