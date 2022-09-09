using CadastroDeCliente;
using Microsoft.Data.SqlClient;
using Dapper;

namespace CadastroDeClientesWEBIII.Repository
{
    public class ClientRepository
    {
        private readonly IConfiguration _configuration;

        public ClientRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<ClientList> GetClientes()
        {
            var query = "SELECT * FROM Clientes";

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Query<ClientList>(query).ToList();
        }

        public bool InsertClientes(ClientList clientList) 
        {
            var query = "INSERT INTO Clientes VALUES (@Name, @Birthday, @CPF)";

            var parameters = new DynamicParameters();
            parameters.Add("Name", clientList.Name);
            parameters.Add("Birthday", clientList.Birthday);
            parameters.Add("CPF", clientList.CPF);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }

        public bool DeleteClientes(long id)
        {
            var query = "DELETE FROM Clientes WHERE id = @id";

            var parameters = new DynamicParameters();
            parameters.Add("id", id);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }

        public bool UpdateClientes(long id, ClientList clientList)
        {
            var query = @"UPDATE Clientes SET Name = @Name, Birthday = @Birthday, CPF = @CPF
                          WHERE id = @id";

            clientList.Id = id;
            var parameters = new DynamicParameters(clientList);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            
            return conn.Execute(query, parameters) == 1;
        }
    }
}
