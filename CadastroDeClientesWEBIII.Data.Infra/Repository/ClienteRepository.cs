using CadastroDeClientesWEBIII.Core.Models;
using CadastroDeClientesWEBIII.Core.Interface;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CadastroDeClientesWEBIII.Data.Infra.Repository
{
    public class ClienteRepository : IClienteRepository
    {

        private readonly IConnectionDataBase _database;

        public ClienteRepository(IConnectionDataBase database)
        {
            _database = database;
        }

        public List<Cliente> ConsultarClientes()
        {
            var query = "SELECT * FROM CLIENTES";

            using var conn = _database.CreateConnection();

            return conn.Query<Cliente>(query).ToList();
        }

        public Cliente ConsultarPeloCPF(string cpf)
        {
            var query = "SELECT * FROM clientes where cpf = @cpf";

            var parameters = new DynamicParameters();
            parameters.Add("cpf", cpf);

            using var conn = _database.CreateConnection();
            return conn.QueryFirstOrDefault<Cliente>(query, parameters);
        }

        public bool InserirCliente(Cliente cliente)
        {
            var query = "INSERT INTO clientes values (@id, @cpf, @nome, @dataNascimento, @idade)";

            var parameters = new DynamicParameters(cliente);

            using var conn = _database.CreateConnection();
            return conn.Execute(query, parameters) > 0;
        }

        public bool AtualizarCliente(Cliente cliente)
        {
            var query = @"UPDATE clientes SET CPF = @cpf, NOME = @nome, DATANASCIMENTO = @dataNascimento, IDADE = @idade
                          WHERE ID = @id";

            var parameters = new DynamicParameters(cliente);

            using var conn = _database.CreateConnection();
            return conn.Execute(query, parameters) > 0;
        }

        public bool DeletarCliente(long id)
        {
            var query = "DELETE FROM CLIENTES WHERE ID = @id";

            var parameters = new DynamicParameters(new { id });

            using var conn = _database.CreateConnection();
            return conn.Execute(query, parameters) > 0;
        }
        public Cliente ConsultarCliente(long id)
        {
            var query = "SELECT * FROM CLIENTES WHERE ID = @id";

            var parameters = new DynamicParameters(new
            {
                id
            });

            using var conn = _database.CreateConnection();
            return conn.QueryFirstOrDefault<Cliente>(query, parameters);
        }
    }
}
