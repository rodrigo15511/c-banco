using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DesafioFarmacia
{
    [Table("Estoques")]
    public class Estoques
    {
        [Key]
        public int Id { get; set; }
        [Column("nome")]
        public string Nome { get; set; } = string.Empty;
        [Column("medicamento_id")]
        public int medicamento_id { get; set; }
        [Column("quantidade")]
        public int quantidade { get; set; }
        [Column("ultima_atualizacao")]
        public DateTime ultima_atualizacao { get; set; }
        [ForeignKey("medicamento_id")]
        [Column("medicamento_id")]
        public Medicamentos Medicamentos { get; set; }

    }
}