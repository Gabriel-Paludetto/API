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
        [Required]
        [StringLength(150)]
        public string? Nome { get; set; }
        [Column("email_cliente")]
        [Required]
        [StringLength(150)]
        public string? Email { get; set; }
        [Column("ativo")]
        public bool Ativo { get; set; }

        [Column("data_cadastro")]
        public DateTime DataCadastro { get; set; }
    }
}
