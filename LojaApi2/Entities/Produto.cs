using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaApi.Entities
{
    [Table("TB_PRODUTOS")]
    public class Produto
    {
        [Key]
        [Column("id_produto")]
        public int Id { get; set; }
        [Column("descricao_produto")]
        [Required]
        [StringLength(150)]
        public string Descricao { get; set; } = string.Empty;
        [Column("valor_produto")]
        [Required]
        public decimal Valor { get; set; }
        [Column("estoque_produto")]
        [Required]
        public int Estoque { get; set; }
    }
}