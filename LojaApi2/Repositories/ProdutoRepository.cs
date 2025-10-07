using LojaApi.Entities;
using LojaApi.Repositories.Interfaces;

public class ProdutoRepository : IProdutoRepository
{
    private readonly List<Produto> _produto = new List<Produto>
    {
        new Produto { Id = 1, Descricao = "Chuteira", Valor = 300m, Estoque = 5 },
        new Produto { Id = 2, Descricao = "Bola", Valor = 450m, Estoque = 10 },
        new Produto { Id = 3, Descricao = "Meião", Valor = 50m, Estoque = 25 }
    };

    public List<Produto> ObterTodos() => _produto;

    public Produto? ObterPorId(int id) => _produto.FirstOrDefault(p => p.Id == id);

    private int _nextId = 4;
    public Produto Adicionar(Produto novoProduto)
    {
        novoProduto.Id = _nextId++;
        _produto.Add(novoProduto);
        return novoProduto;
    }

    public Produto? Atualizar(int id, Produto produtoAtualizado)
    {
        var produtoExistente = ObterPorId(id);
        if (produtoExistente == null) return null;

        produtoExistente.Descricao = produtoAtualizado.Descricao;
        produtoExistente.Valor = produtoAtualizado.Valor;
        produtoExistente.Estoque = produtoAtualizado.Estoque;
        return produtoExistente;
    }

    public bool Remover(int id)
    {
        var produtoDeletar = ObterPorId(id);
        if (produtoDeletar == null) return false;

        _produto.Remove(produtoDeletar);
        return true;
    }
}
