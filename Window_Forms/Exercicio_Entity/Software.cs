using System;
using System.Collections.Generic;
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
        public string Produto { get; set; }

        [Column("HardDisk")]
        public int HardDisk { get; set; }

        [Column("Memoria_Ram")]
        public int Memoria_Ram { get; set; }

        [Column("Fk_Maquina")]
        [ForeignKey("Maquina")]
        public int Fk_Maquina { get; set; }

        public Maquina Maquina { get; set; } 
    }
}