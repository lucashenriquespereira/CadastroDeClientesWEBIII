using CadastroDeClientesWEBIII.Core.Interface;
using CadastroDeClientesWEBIII.Core.Models;

namespace CadastroDeClientesWEBIII.Core.Services
{
    public class ClienteService : IClienteService
    {
        private IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public List<Cliente> ConsultarClientes()
        {
            return _clienteRepository.ConsultarClientes();
        }
        public Cliente ConsultarPeloCPF(string cpf)
        {
            return _clienteRepository.ConsultarPeloCPF(cpf);
        }
        public bool InserirCliente(Cliente cliente)
        {
            return _clienteRepository.InserirCliente(cliente);
        }
        public bool AtualizarCliente(long id, Cliente cliente)
        {
        
            cliente.Id = id;
            return _clienteRepository.AtualizarCliente(cliente);
        }
        public bool DeletarCliente(long id)
        {
            return _clienteRepository.DeletarCliente(id);
        }
        public Cliente ConsultarCliente(long id)
        {
            return _clienteRepository.ConsultarCliente(id);
        }
    }
}
