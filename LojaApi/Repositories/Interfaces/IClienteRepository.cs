using System;
using LojaApi.Entities;

namespace LojaApi.Repositories.Interfaces;

public interface IClienteRepository
{
    List<Cliente> ObterTodos();
    Cliente? ObterPorId(int id);
    Cliente Adicionar(Cliente novoCliente);
    Cliente? Atualizar(int id, Cliente clienteAtualizado);
    bool Remover(int id);
}
