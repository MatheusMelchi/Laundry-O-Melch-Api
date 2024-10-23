using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laundry_O_Melch_Api.Entities
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }

        //EF just hates me very much - had to put this variable as nullable otherwise would not work
        public Cliente? Cliente { get; set; }

        [Required]
        [MaxLength(5000)]
        public string Descricao { get; set; }
    }
}
