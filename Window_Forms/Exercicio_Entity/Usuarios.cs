using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio_Entity
{
    [Table("usuarios")]
    public class Usuarios
    {
        [Key]
        [Column("id_usuario")]
        public int Id { get; set; }
        [Column("Passoword")]
        public string Password { get; set; }
        [Column("Nome")]
        public string Nome { get; set; }
        [Column("Ramal")]
        public int Ramal { get; set; }
        [Column("Especialidade")]
        public string Especialidade { get; set; }
    }
}