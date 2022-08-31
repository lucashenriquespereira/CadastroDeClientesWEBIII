using Microsoft.AspNetCore.Mvc;

namespace CadastroDeCliente.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class ClientListController : ControllerBase
    {
        private static readonly string[] Names = new[]
        {
            "Amanda Alice Gonçalves",
            "Daniel Daniel Oliveira",
            "Vanessa Sarah Emily Martins",
            "Jéssica Bruna Silveira",
            "Eduarda Evelyn Nicole Drumond",
            "Augusto Yago Assis",
            "Cecília Valentina Carvalho",
            "André Julio Almeida",
            "Matheus Ryan Araújo",
            "Sônia Alessandra dos Santos"
    };

        private static readonly string[] Cpfs = new[]
        {
            "46199685369",
            "35376287300",
            "00451813812",
            "64790465799",
            "42491796058",
            "15647316344",
            "41788435400",
            "46159559281",
            "30226159221",
            "12759258556"
        };

        private readonly ILogger<ClientListController> _logger;
        public List<ClientList> clientes { get; set; }

        public ClientListController(ILogger<ClientListController> logger)
        {
            _logger = logger;
            clientes = Enumerable.Range(1, 5).Select(index => new ClientList
            {
                Name = Names[Random.Shared.Next(Names.Length)],
                CPF = Cpfs[Random.Shared.Next(Cpfs.Length)],
                Birthday = DateTime.Now.AddYears(Random.Shared.Next(-55, -20))
            })
            .ToList();
        }

        //https://localhost:7248/ClientList GET
        [HttpGet("/cliente/consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<ClientList>> Consultar()
        {
            return Ok(clientes);
        }

        //https://localhost:7248/ClientList POST
        [HttpPost("/cliente/cadastrar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<List<ClientList>> Insert([FromBody]ClientList newClient)
        {
            clientes.Add(newClient);
            return StatusCode(201, newClient);
        }
 
        //https://localhost:7248/ClientList PUT
        [HttpPut("/cliente/{index}/atualizar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Atualizar(int index, ClientList newClient)
        {
            if (index >= clientes.Count || index < 0)
                return NotFound();
            clientes[index] = newClient;
            return NoContent();
        }

        //https://localhost:7248/ClientList DELETE
        [HttpDelete("/cliente/{index}/deletar")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Deletar(int index)
        {
            if (index >= clientes.Count || index < 0)
                return NotFound();
            clientes.RemoveAt(index);
            return NoContent();
        }
    }
}