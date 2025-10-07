using LojaApi.Entities;
using LojaApi.Repositories.Interfaces;

public class ClienteRepository : IClienteRepository
{
    private readonly List<Cliente> _clientes = new List<Cliente>
        {
            new Cliente { Id = 1, Nome = "ALICE SILVA", Email = "alice@mail.com", Ativo = true },
            new Cliente { Id = 2, Nome = "BRUNO COSTA", Email = "bruno@mail.com", Ativo = true },
            new Cliente { Id = 3, Nome = "CARLOS SANTOS", Email = "carlos@mail.com", Ativo = false }
        };

    private int _nextId = 4;

    public List<Cliente> ObterTodos() => _clientes;

    public Cliente? ObterPorId(int id) => _clientes.FirstOrDefault(c => c.Id == id);

    public Cliente Adicionar(Cliente novoCliente)
    {
        novoCliente.Id = _nextId++;
        _clientes.Add(novoCliente);
        return novoCliente;
    }

    public Cliente? Atualizar(int id, Cliente clienteAtualizado)
    {
        var clienteExistente = ObterPorId(id);
        if (clienteExistente == null) return null;

        clienteExistente.Nome = clienteAtualizado.Nome;
        clienteExistente.Email = clienteAtualizado.Email;
        clienteExistente.Ativo = clienteAtualizado.Ativo;
        return clienteExistente;
    }

    public bool Remover(int id)
    {
        var clienteParaDeletar = ObterPorId(id);
        if (clienteParaDeletar == null) return false;

        _clientes.Remove(clienteParaDeletar);
        return true;
    }
}