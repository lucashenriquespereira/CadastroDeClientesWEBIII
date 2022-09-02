using CadastroDeClientesWEBIII.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeCliente.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class ClientListController : ControllerBase
    {
        public List<ClientList> clientes { get; set; }

        private ClientRepository _repositoryClient { get; set; }

        public ClientListController(IConfiguration configuration)
        {
            clientes = new List<ClientList>();
            _repositoryClient = new ClientRepository(configuration);
        }

        //https://localhost:7248/ClientList **GET
        [HttpGet("/cliente/consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<ClientList>> Consultar()
        {
            return Ok(_repositoryClient.GetClientes());
        }

        //https://localhost:7248/ClientList **POST
        [HttpPost("/cliente/cadastrar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ClientList> Insert([FromBody]ClientList clientList)
        {
            if(!_repositoryClient.InsertClientes(clientList))
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Insert), clientList);
        }
 
        //https://localhost:7248/ClientList **PUT
        [HttpPut("/cliente/{index}/atualizar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Atualizar(long id, ClientList clientList)
        {
            if (!_repositoryClient.UpdateClientes(id, clientList))
            {
                return NotFound();
            }
            return NoContent();
        }

        //https://localhost:7248/ClientList **DELETE
        [HttpDelete("/cliente/{index}/deletar")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Deletar(long id)
        {
            if (!_repositoryClient.DeleteClientes(id))
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}