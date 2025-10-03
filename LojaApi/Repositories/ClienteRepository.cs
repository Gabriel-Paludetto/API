using LojaApi.Entities;

namespace LojaApi.Repositories
{
    public static class ClienteRepository // Usando 'static' para simplificar o acesso sem Injeção de Dependência 
    {
        // Lista estática para SIMULAR o Banco de Dados 
        private static List<Cliente> _clientes = new List<Cliente>
        {
            new Cliente { Id = 1, Nome = "Alice Silva", Email = "alice@mail.com", Ativo = true },
            new Cliente { Id = 2, Nome = "Bruno Costa", Email = "bruno@mail.com", Ativo = true },
            new Cliente { Id = 3, Nome = "Carlos Santos", Email = "carlos@mail.com", Ativo = false }
        };

        private static int _nextId = 4; // Variável para gerenciar o próximo ID 

        // Implementação dos métodos CRUD 

        // 1. Read (Ler Todos) 
        public static List<Cliente> GetAll()
        {
            return _clientes;
        }
 
        // 2. Read (Ler por ID) 
        public static Cliente? GetById(int id)
        {
            // Retorna o primeiro cliente com o ID, ou null se não encontrar 
            return _clientes.FirstOrDefault(c => c.Id == id);
        }

        // 3. Create (Criar) 
        public static Cliente Add(Cliente novoCliente)
        {
            novoCliente.Id = _nextId++; // Atribui o próximo ID 
            _clientes.Add(novoCliente);
            return novoCliente;
        }

        // 4. Update (Substituir/Completo) 
        public static Cliente? Update(int id, Cliente clienteAtualizado)
        {
            var clienteExistente = _clientes.FirstOrDefault(c => c.Id == id);

            if (clienteExistente == null)
            {
                return null; // Não encontrou para atualizar 
            }

            // O PUT (Update) substitui os campos 
            clienteExistente.Nome = clienteAtualizado.Nome;
            clienteExistente.Email = clienteAtualizado.Email;
            clienteExistente.Ativo = clienteAtualizado.Ativo; // Assume-se que todos os outros campos vieram

            return clienteExistente;
        }

        // 5. Delete (Excluir) 
        public static bool Delete(int id)
        {
            var clienteParaDeletar = _clientes.FirstOrDefault(c => c.Id == id);

            if (clienteParaDeletar == null)
            {
                return false; // Não encontrou para deletar 
            }

            _clientes.Remove(clienteParaDeletar);
            return true;
        }
    }
}
