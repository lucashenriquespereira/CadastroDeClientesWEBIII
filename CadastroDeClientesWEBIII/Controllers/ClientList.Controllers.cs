using Microsoft.AspNetCore.Mvc;

namespace CadastroDeCliente.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            "461.996.853-69",
            "353.762.873-00",
            "004.518.138-12",
            "647.904.657-99",
            "424.917.960-58",
            "156.473.163-44",
            "417.884.354-00",
            "461.595.592-81",
            "302.261.592-21",
            "127.592.585-56"
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
        [HttpGet]
        public IEnumerable<ClientList> Get()
        {
            return clientes;
        }

        //https://localhost:7248/ClientList POST
        [HttpPost]
        public ClientList Insert(ClientList newClient)
        {
            clientes.Add(newClient);
            return newClient;
        }

        //https://localhost:7248/ClientList PUT
        [HttpPut]
        public ClientList Atualizar(int index, ClientList newClient)
        {
            clientes[index] = newClient;
            return clientes[index];
        }

        //https://localhost:7248/ClientList DELETE
        [HttpDelete]
        public List<ClientList> Deletar(int index)
        {
            clientes.RemoveAt(index);
            return clientes;
        }
    }
}