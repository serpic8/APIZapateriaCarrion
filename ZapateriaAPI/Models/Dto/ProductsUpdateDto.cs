using System.ComponentModel.DataAnnotations;

namespace ZapateriaAPI.Models.Dto
{
    public class ProductsUpdateDto
    {
        public int productId { get; set; }

        public string productMarca { get; set; }

        public string productModelo { get; set; }

        public string productTipo { get; set; }

        public string productColor { get; set; }

        public double productTalla { get; set; }

        public char productGenero { get; set; }

        public double productPrecio { get; set; }

        public string productUbicacion { get; set; }

    }
}
