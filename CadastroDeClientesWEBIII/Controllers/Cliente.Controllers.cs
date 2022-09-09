using APIProdutos.Filters;
using CadastroDeClientesWEBIII.Core.Interface;
using CadastroDeClientesWEBIII.Core.Models;
using CadastroDeClientesWEBIII.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeClientesWEBIII.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [TypeFilter(typeof(LogResourceFilter))]
    public class ClienteController : ControllerBase
    {
        public IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            Console.WriteLine("Instanciando Cliente Controller");
            _clienteService = clienteService;
        }

        [HttpGet("/Cliente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [TypeFilter(typeof(LogAuthorizationFilter))]
        public ActionResult<List<Cliente>> ConsultarClientes()
        {
            Console.WriteLine("Iniciando");
            return Ok(_clienteService.ConsultarClientes());
        }

        [HttpGet("/Cliente/{cpf}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Cliente> GetInfoCliente(string cpf)
        {
            var cliente = _clienteService.ConsultarPeloCPF(cpf);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [TypeFilter(typeof(LogActionFilter))]
        public ActionResult<Cliente> PostCliente(Cliente cliente)
        {
            Console.WriteLine("Iniciando");
            if (!_clienteService.InserirCliente(cliente))
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(PostCliente), cliente);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [TypeFilter(typeof(LogActionFilter))]
        [ServiceFilter(typeof(GaranteClienteExisteActionFilters))]
        public IActionResult UpdateCliente(long id, Cliente cliente)
        {
            Console.WriteLine("Iniciando");
            if (! _clienteService.AtualizarCliente(id, cliente))
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ServiceFilter(typeof(GaranteClienteExisteActionFilters))]
        public ActionResult<List<Cliente>> DeletarCliente(long id)
        {
            Console.WriteLine("Iniciando");
            if (_clienteService.DeletarCliente(id))
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            return NoContent();
        }
    }
}