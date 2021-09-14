using Product.Service.Application.DTO.Common;
using Product.Service.Application.DTO.Product;

namespace Product.Service.Application.UseCases.Command.Update
{
    /// <summary>
    /// MediatRs response for <see cref="UpdateProductDescriptionCommand"/>
    /// </summary>
    public class UpdateProductDescriptionCommandResponse
    {
        /// <summary>
        /// The payload of the message
        /// </summary>
        /// <value></value>
        public ProductDTO Payload { get; set; }
        /// <summary>
        /// Response of the message
        /// </summary>
        public ResponseDTO Response { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateProductDescriptionCommandResponse"/> class.
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="response"></param>
        public UpdateProductDescriptionCommandResponse(ProductDTO payload, ResponseDTO response)
        {
            Payload = payload;
            Response = response;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateProductDescriptionCommandResponse"/> class.
        /// </summary>
        /// <param name="response"></param>
        public UpdateProductDescriptionCommandResponse(ResponseDTO response)
        {
            Payload = null;
            Response = response;
        }
    }
}
