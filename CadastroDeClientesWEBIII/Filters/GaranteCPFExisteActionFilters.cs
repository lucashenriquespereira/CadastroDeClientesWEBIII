using CadastroDeClientesWEBIII.Core.Interface;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeClientesWEBIII.Filters
{
    public class GaranteCPFExisteActionFilters
    {
        public IClienteService _clienteService;
        public GaranteCPFExisteActionFilters(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        //Implemente na APIClientes uma validação de CPF na inserção.Caso o CPF já exista na base, retorne Status de Conflito.
        public void OnActionExecuting(ActionExecutingContext context)
        {
            string CPFCliente = (string)context.ActionArguments["cpf"];
            if (_clienteService.ConsultarPeloCPF(CPFCliente) != null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status409Conflict);
            }
        }
    }
}