using Product.Service.Application.DTO.Common;
using Product.Service.Application.DTO.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Service.Application.UseCases.Query
{
    public class GetAllProductQueryResponse
    {
        /// <summary>
        /// The payload of the message
        /// </summary>
        /// <value></value>
        public IEnumerable<ProductDTO> Payload { get; set; }
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
