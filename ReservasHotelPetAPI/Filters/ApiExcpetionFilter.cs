using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Runtime.CompilerServices;

namespace ReservasHotelPetAPI.Filters
{
    public class ApiExcpetionFilter : IExceptionFilter
    {
        private readonly ILogger<ApiExcpetionFilter> _logger;

        public ApiExcpetionFilter(ILogger<ApiExcpetionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "Ocorreu uma exceção não tratada: Status Code 500. " + context.Exception.Message);

            context.Result = new ObjectResult("Ocorreu um problema ao tratar a sua solicitação: Status Code 500. " + context.Exception.Message)
            {
                StatusCode = StatusCodes.Status500InternalServerError,
            };
        }
    }
}
