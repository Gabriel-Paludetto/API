using System;

namespace LojaApi.Entities
{
    // A classe que representa o nosso recurso 
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Ativo { get; set; }
    }
}
