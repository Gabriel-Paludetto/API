using System;

namespace LojaApi.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public int Estoque { get; set; }
    }
}