using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ZapateriaAPI.Models
{
    public class Temp_Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int temp_productId { get; set; }

        [Required]
        [StringLength(20)]
        public string productMarca { get; set; }

        [Required]
        public string productModelo { get; set; }

        public string productDescripcion { get; set; }

        [Required]
        [StringLength(4)]
        public double productTalla { get; set; }

        [Required]
        public char productGenero { get; set; }

        [Required]
        public double productPrecio { get; set; }

        [Required]
        public string productUbicacion { get; set; }

        public int productCantidad { get; set; }
    }
}
