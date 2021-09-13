using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Service.Application.UseCases.Command.Update
{
    /// <summary>
    /// Validation for update of description on product
    /// </summary>
    public class UpdateProductDescriptionCommandValidator : AbstractValidator<UpdateProductDescriptionCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateProductDescriptionCommandValidator"/> class.
        /// </summary>
        public UpdateProductDescriptionCommandValidator()
        {
            // no valid ruless for this update
        }
    }
}