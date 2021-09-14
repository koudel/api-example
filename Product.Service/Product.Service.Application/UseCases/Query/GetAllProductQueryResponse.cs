using Product.Service.Application.DTO.Common;
using Product.Service.Application.DTO.Product;
using System.Collections.Generic;

namespace Product.Service.Application.UseCases.Query
{
    /// <summary>
    /// MediatRs response for <see cref="GetAllProductQuery"/>
    /// </summary>
    public class GetAllProductQueryResponse
    {
        /// <summary>
        /// The payload of the message
        /// </summary>
        /// <value></value>
        public IEnumerable<ProductDTO> Payload { get; set; }
        /// <summary>
        /// Response of the message
        /// </summary>
        public ResponseDTO Response { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllProductQueryResponse"/> class.
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="response"></param>
        public GetAllProductQueryResponse(IEnumerable<ProductDTO> payload, ResponseDTO response)
        {
            Payload = payload;
            Response = response;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllProductQueryResponse"/> class.
        /// </summary>
        /// <param name="response"></param>
        public GetAllProductQueryResponse(ResponseDTO response)
        {
            Payload = null;
            Response = response;
        }
    }
}
