using MediatR;
using Product.Service.Application.DTO.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Service.Application.UseCases.Query
{
    public class GetAllProductQuery : IRequest<GetAllProductQueryResponse>
    {
    }
}
