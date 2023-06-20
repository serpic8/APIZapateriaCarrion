using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZapateriaAPI.Models
{
    public class Inventary 
    {
        [Key]
        public int inventaryId { get; set; }

        [ForeignKey ("Products")]
        public Products productsMarca { get; set; }
        public int Stock;

    }
}
