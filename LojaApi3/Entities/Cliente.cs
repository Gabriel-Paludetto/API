using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaApi.Entities
{
    // A classe que representa o nosso recurso 
    [Table("TB_CLIENTES")]
    public class Cliente
    {
        [Key]
        [Column("id_cliente")]
        public int Id { get; set; }
        [Column("nome_cliente")]
        public string Nome { get; set; } = string.Empty;
        [Column("email_cliente")]
        public string Email { get; set; } = string.Empty;
        [Column("ativo")]
        public bool Ativo { get; set; }
    }
}
