using System;
using MediatR;
using System.Collections.Generic;
using System.Text;
using Product.Service.Application.DTO;
using Product.Service.Application.DTO.Common;
using Product.Service.Application.DTO.Product;

namespace Product.Service.Application.UseCases.Command.Update
{
    public class UpdateProductDescriptionCommandResponse
    {
        /// <summary>
        /// The payload of the message
        /// </summary>
        /// <value></value>
        public ProductDTO Payload { get; set; }
        public ResponseDTO Response { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateProductDescriptionCommandResponse"/> class.
        /// </summary>
        /// <param name="payload"></param>
        public UpdateProductDescriptionCommandResponse(ProductDTO payload, ResponseDTO response)
        {
            Payload = payload;
            Response = response;
        }

        public UpdateProductDescriptionCommandResponse(ResponseDTO response)
        {
            Payload = null;
            Response = response;
        }
    }
}
