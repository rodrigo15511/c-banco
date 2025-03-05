using System.ComponentModel.DataAnnotations;

namespace Exercicio
{
    public class Maquina
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        
        [StringLength(50)]
        public string NumeroSerie { get; set; }
    }
}