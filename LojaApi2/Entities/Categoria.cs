using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LojaApi.Entities
{
    [Table("TB_CATEGORIAS")]
    public class Categoria
    {
        [Key]
        [Column("id_categoria")]
        public int Id { get; set; }

        [Column("nome_categoria")]
        [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 150 caracteres.")]
        public string? Nome { get; set; } 

        [JsonIgnore]
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
    }
}