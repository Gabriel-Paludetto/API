// Services/ClienteService.cs
using LojaApi.Entities;
using LojaApi.Repositories.Interfaces;
using LojaApi.Services.Interfaces;

namespace LojaApi.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        // O Service agora recebe sua dependência (o contrato do repositório) via construtor.
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        // Os métodos agora usam a dependência injetada (_clienteRepository)
        public List<Cliente> ObterTodos()
        {
            // Regra: Não exibir clientes inativos.
            return _clienteRepository.ObterTodos().Where(c => c.Ativo).ToList();
        }

        public Cliente? ObterPorId(int id)
        {
            return _clienteRepository.ObterPorId(id);
        }

        public Cliente Adicionar(Cliente novoCliente)
        {
            novoCliente.Nome = novoCliente.Nome.ToUpper();
            novoCliente.Ativo = true;
            return _clienteRepository.Adicionar(novoCliente);
        }

        public Cliente? Atualizar(int id, Cliente clienteAtualizado)
        {
            if (id != clienteAtualizado.Id) return null;
            return _clienteRepository.Atualizar(id, clienteAtualizado);
        }

        public bool Remover(int id)
        {
            var cliente = _clienteRepository.ObterPorId(id);
            if (cliente != null)
            {
                cliente.Ativo = false;
                return _clienteRepository.Atualizar(id, cliente) != null;
            }
            return false;
        }
    }
}