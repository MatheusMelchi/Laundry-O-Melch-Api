using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Laundry_O_Melch_Api.Entities
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]    
        public string Nome { get; set; }

        [MaxLength(255)]
        [AllowNull]
        public string? Email { get; set; }

        [MaxLength(15)]
        [AllowNull]
        public string? Celular { get; set; }

        [MaxLength(15)]
        [AllowNull]
        public string? Cpf { get; set; }

        [MaxLength(25)]
        [AllowNull]
        public string? Cnpj { get; set; }
    }
}
