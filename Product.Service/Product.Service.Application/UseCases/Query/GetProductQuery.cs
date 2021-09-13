using MediatR;
using Product.Service.Application.DTO.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Service.Application.UseCases.Query
{
    public class GetProductQuery : IRequest<GetProductQueryResponse>
    {
        /// <summary>
        /// The payload of the message
        /// </summary>
        /// <value></value>
        public GetProductDTO Payload { get; set; }

        public GetProductQuery(GetProductDTO payload)
        {
            Payload = payload;
        }
    }
}
