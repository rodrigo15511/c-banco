using System.ComponentModel.DataAnnotations;

namespace Exercicio
{
    public class Usuario
    {
        [Key] 
        public int Id { get; set; }
        
        [Required] 
        [StringLength(100)]
        public string Nome { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
    }
}