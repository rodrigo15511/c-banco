using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio_Entity
{
    [Table("maquina")]
    public class Maquina
    {
        [Key]
        [Column("id_Maquina")]
        public int Id { get; set; }

        [Column("Tipo")]
        public string Tipo { get; set; }

        [Column("Velocidade")]
        public int Velocidade { get; set; }
        [Column("HardDisk")]
        public int HardDisk { get; set; }
        [Column("Placa_Rede")]
        public int Placa_Rede { get; set; }
        [Column("Memoria_Ram")]
        public int Memoria_Ram { get; set; }
        [Column("Fk_Usuario")]
        [ForeignKey("Usuario")]
        public int Fk_Usuario { get; set; }
        public Usuario Usuario { get; set; }


    }
}