using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZapateriaAPI.Models
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int productId { get; set; }

        [Required]
        [StringLength(20)]
        public string productMarca { get; set; }

        [Required]
        public string productModelo { get; set; }

        public string productTipo { get; set; }

        [StringLength(15)]
        public string productColor { get; set; }

        [Required]
        [StringLength(4)]
        public double productTalla { get; set; }

        [Required]
        public char productGenero { get; set; }

        [Required]
        public double productPrecio { get; set; }

        [Required]
        public string productUbicacion { get; set; }

       


    }
}
