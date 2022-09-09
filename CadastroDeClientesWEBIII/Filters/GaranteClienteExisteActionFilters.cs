using CadastroDeClientesWEBIII.Core.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CadastroDeClientesWEBIII.Filters
{
    public class GaranteClienteExisteActionFilters : ActionFilterAttribute
    {
        public IClienteService _clienteService;
        public GaranteClienteExisteActionFilters(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            long idCliente = (long)context.ActionArguments["id"];
            if (_clienteService.ConsultarCliente(idCliente) == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status404NotFound);
            }
        }
    }
}
