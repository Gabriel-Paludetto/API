using System;
using LojaApi.Entities;

namespace LojaApi.Repositories.Interfaces;

public interface IProdutoRepository
{
    List<Produto> ObterTodos();
    Produto? ObterPorId(int id);
    Produto Adicionar(Produto novoProduto);
    Produto? Atualizar(int id, Produto produtoAtualizado);
    bool Remover(int id);
}
