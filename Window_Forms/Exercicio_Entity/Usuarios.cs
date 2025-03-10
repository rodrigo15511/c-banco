using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Column("Password")]
        public string Password { get; set; } = string.Empty;
        [Column("Nome_Usuario")]
        public string Nome_Usuario { get; set; } = string.Empty;
        [Column("Ramal")]
        public int Ramal { get; set; } 
        [Column("Especialidade")]
        public string Especialidade { get; set; } = string.Empty;


    }
}