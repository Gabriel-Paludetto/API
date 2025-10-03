using LojaApi.Entities;

namespace LojaApi.Repositories
{
    public class ProdutoRepository
    {
        private static List<Produto> _produto = new List<Produto>
        {
            new Produto { Id = 1, Descricao = "Mouse", Valor = 50m, Estoque = 10 },
            new Produto { Id = 2, Descricao = "Teclado", Valor = 150m, Estoque = 5 },
            new Produto { Id = 3, Descricao = "Monitor", Valor = 1499.90m, Estoque = 2 }
        };

        public static List<Produto> GetAll()
        {
            return _produto;
        }

        public static Produto? GetById(int id)
        {
            return _produto.FirstOrDefault(p => p.Id == id);
        }

        private static int _nextId = 4;

        public static Produto Add(Produto novoProduto)
        {
            novoProduto.Id = _nextId++;
            _produto.Add(novoProduto);
            return novoProduto;
        }

        public static Produto? Update(int id, Produto produtoAtualizado)
        {
            var produtoExistente = _produto.FirstOrDefault(p => p.Id == id);

            if (produtoExistente == null)
            {
                return null;
            }

            produtoExistente.Descricao = produtoAtualizado.Descricao;
            produtoExistente.Valor = produtoAtualizado.Valor;
            produtoExistente.Estoque = produtoAtualizado.Estoque;

            return produtoExistente;
        }
        
        public static bool Delete(int id)
        {
            var produtoParaDeletar = _produto.FirstOrDefault(p => p.Id == id);

            if (produtoParaDeletar == null)
            {
                return false;
            }

            _produto.Remove(produtoParaDeletar);
            return true;
        }
    }
}