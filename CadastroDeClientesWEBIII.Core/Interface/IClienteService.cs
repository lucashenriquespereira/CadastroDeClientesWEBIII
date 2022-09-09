using CadastroDeClientesWEBIII.Core.Models;

namespace CadastroDeClientesWEBIII.Core.Interface
{
    public interface IClienteService
    {
        List<Cliente> ConsultarClientes();
        Cliente ConsultarPeloCPF(string cpf);
        bool InserirCliente(Cliente cliente);
        bool AtualizarCliente(long id, Cliente cliente);
        bool DeletarCliente(long id);
        Cliente ConsultarCliente(long id);
    }
}
