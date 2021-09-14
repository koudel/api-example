using Product.Service.Application.DTO.Common;
using Product.Service.Application.DTO.Product;

namespace Product.Service.Application.UseCases.Query
{
    /// <summary>
    /// MediatRs response for <see cref="GetProductQuery"/>
    /// </summary>
    public class GetProductQueryResponse
    {
        /// <summary>
        /// The payload of the message
        /// </summary>
        public ProductDTO Payload { get; set; }
        /// <summary>
        /// Response of the message
        /// </summary>
        public ResponseDTO Response { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetProductQueryResponse"/> class.
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="response"></param>
        public GetProductQueryResponse(ProductDTO payload, ResponseDTO response)
        {
            Payload = payload;
            Response = response;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetProductQueryResponse"/> class.
        /// </summary>
        /// <param name="response"></param>
        public GetProductQueryResponse(ResponseDTO response)
        {
            Payload = null;
            Response = response;
        }
    }
}
