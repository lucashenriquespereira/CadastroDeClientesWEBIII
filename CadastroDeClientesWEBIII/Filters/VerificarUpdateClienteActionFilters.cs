using CadastroDeClientesWEBIII.Core.Interface;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using CadastroDeClientesWEBIII.Core.Models;

namespace CadastroDeClientesWEBIII.Filters
{
    public class VerificarUpdateClienteActionFilters
    {
        public IClienteService _clienteService;
        public VerificarUpdateClienteActionFilters(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        //Implemente na APIClientes uma validação no update. Caso o registro a ser atualizado não exista, retorne status de BadRequest.
        //Caso o registro exista e o update não consiga ser efetivado, retorne Internal Server Error.
        public void OnActionExecuting(ActionExecutingContext context)
        {
            string CPFCliente = (string)context.ActionArguments["cpf"];
            if (_clienteService.ConsultarPeloCPF(CPFCliente) == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
        }
    }
}
