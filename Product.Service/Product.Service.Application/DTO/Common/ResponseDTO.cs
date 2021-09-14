namespace Product.Service.Application.DTO.Common
{
    public class ResponseDTO
    {
        /// <summary>
        /// Set this to the result
        /// </summary>
        public ActionResult Result { get; set; }

        /// <summary>
        /// Message describing the result
        /// </summary>
        public string Message { get; set; } = string.Empty;
    }
}