using System;
using MediatR;
using System.Collections.Generic;
using System.Text;
using Product.Service.Application.DTO.Product;

namespace Product.Service.Application.UseCases.Command.Update
{
    public class UpdateProductDescriptionCommand : IRequest<UpdateProductDescriptionCommandResponse>
    {
        /// <summary>
        /// The payload of the message
        /// </summary>
        /// <value></value>
        public UpdateProductDescriptionDTO Payload { get; set; }

        public UpdateProductDescriptionCommand(UpdateProductDescriptionDTO payload)
        {
            Payload = payload;
        }

    }
}
