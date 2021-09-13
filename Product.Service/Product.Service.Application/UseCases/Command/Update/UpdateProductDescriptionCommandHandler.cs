using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Product.Service.Application.DTO.Common;
using Product.Service.Application.DTO.Product;
using Product.Service.Domain.Repository;
using System.Linq;
using Product.Service.Domain.Entity;
using System.Collections.Generic;
using Product.Service.Application.DTO.Product.Extensions;

namespace Product.Service.Application.UseCases.Command.Update
{
    /// <summary>
    /// Handles the update of description on product
    /// </summary>
    public class UpdateProductDescriptionCommandHandler : IRequestHandler<UpdateProductDescriptionCommand, UpdateProductDescriptionCommandResponse>
    {
        private readonly IMockRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductUpdateDescriptionCommandHandler"/> class.
        /// </summary>
        /// <param name="IMockRepository">MockRepository</param>
        public UpdateProductDescriptionCommandHandler(IMockRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Integration event handler for ProductUpdateDescriptionCommand
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<UpdateProductDescriptionCommandResponse> Handle(UpdateProductDescriptionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = _repository.GetRepository().Where(w => w.Id == request.Payload.Id).FirstOrDefault();

                if (EqualityComparer<ProductEntity>.Default.Equals(product, default(ProductEntity)))
                {
                    return new UpdateProductDescriptionCommandResponse(new ResponseDTO()
                    {
                        Result = ActionResult.FAILED,
                        Message = "Product not found.",
                    });
                }

                product.Description = request.Payload.Description;

                // mock repository is not async -> with normal repo use async here :)
                var res = _repository.SaveChanges(product);

                if (res > 0)
                {
                    var editedRow = _repository.GetRepository().Where(w => w.Id == request.Payload.Id).First();
                    return new UpdateProductDescriptionCommandResponse(editedRow.MapToProductDTO(), new ResponseDTO()
                    {
                        Result = ActionResult.SUCCESS,
                    });
                }
            }
            catch (Exception ex)
            {
                return new UpdateProductDescriptionCommandResponse(new ResponseDTO()
                {
                    Result = ActionResult.ERROR,
                    Message = ex.Message.ToString(),
                });
            }

            return new UpdateProductDescriptionCommandResponse(new ResponseDTO()
            {
                Result = ActionResult.ERROR,
                Message = "Failed to update product.",
            });
        }
    }
}