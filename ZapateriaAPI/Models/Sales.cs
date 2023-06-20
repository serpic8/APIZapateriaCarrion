using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZapateriaAPI.Models
{
    public class Sales
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalesId { get; set; }

        [Required]
        public DateTime SalesFecha { get; set; }

        public int SalesCantidad { get; set; }
        public double SalesPrecioV { get; set; }
        public double SalesTotal { get; set; }

        public Sales()
        {
        }
    }
}
