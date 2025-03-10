using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio_Entity
{
    [Table("Software")]
    public class Software
    {
        [Key]
        [Column("Id_Software")]
        public int Id { get; set; }

        [Column("Produto")]
        public string Produto { get; set; } = string.Empty;

        [Column("HardDisk")]
        public int HardDisk { get; set; }

        [Column("Memoria_Ram")]
        public int Memoria_Ram { get; set; }

        [ForeignKey("Maquina")]
        [Column("Fk_Maquina")]
        public int Fk_Maquina { get; set; }

    }
}