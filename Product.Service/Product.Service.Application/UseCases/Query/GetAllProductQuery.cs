using MediatR;

namespace Product.Service.Application.UseCases.Query
{
    /// <summary>
    /// MediatRs request for <see cref="GetAllProductQuery"/> 
    /// </summary>
    public class GetAllProductQuery : IRequest<GetAllProductQueryResponse>
    {
    }
}
