using MediatR;
using Product.Service.Application.DTO.Product;

namespace Product.Service.Application.UseCases.Command.Update
{
    /// <summary>
    /// MediatRs request for <see cref="UpdateProductDescriptionCommand"/> 
    /// </summary>
    public class UpdateProductDescriptionCommand : IRequest<UpdateProductDescriptionCommandResponse>
    {
        /// <summary>
        /// The payload of the message
        /// </summary>
        /// <value></value>
        public UpdateProductDescriptionDTO Payload { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateProductDescriptionCommand"/> class.
        /// </summary>
        /// <param name="payload"></param>
        public UpdateProductDescriptionCommand(UpdateProductDescriptionDTO payload)
        {
            Payload = payload;
        }

    }
}
