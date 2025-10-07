using System;
using LojaApi.Entities;
using LojaApi.Repositories.Interfaces;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly List<Categoria> _categoria = new List<Categoria>
    {
        new Categoria { Id = 1, Descricao = "Eletrônicos" },
        new Categoria { Id = 2, Descricao = "Roupas" },
        new Categoria { Id = 3, Descricao = "Alimentos" }
    };

    public List<Categoria> ObterTodos() => _categoria;

    public Categoria? ObterPorId(int id) => _categoria.FirstOrDefault(c => c.Id == id);

    private int _nextId = 4;
    public Categoria Adicionar(Categoria novaCategoria)
    {
        novaCategoria.Id = _nextId++;
        _categoria.Add(novaCategoria);
        return novaCategoria;
    }

    public Categoria? Atualizar(int id, Categoria categoriaAtualizada)
    {
        var categoriaExistente = ObterPorId(id);
        if (categoriaExistente == null) return null;

        categoriaExistente.Descricao = categoriaAtualizada.Descricao;
        return categoriaExistente;
    }

    public bool Remover(int id)
    {
        var categoriaDeletar = ObterPorId(id);
        if (categoriaDeletar == null) return false;

        _categoria.Remove(categoriaDeletar);
        return true;
    }
}
