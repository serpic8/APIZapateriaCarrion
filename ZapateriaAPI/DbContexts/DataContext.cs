using Microsoft.EntityFrameworkCore;
using ZapateriaAPI.Models;

namespace ZapateriaAPI.DbContexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        
        }

        public DbSet<Inventary> Inventaries => Set<Inventary>();
        public DbSet<Products> Producties => Set<Products>();
        public DbSet<Sales> Saliers => Set<Sales>();
        public DbSet<Temp_Products> Temp_Producties => Set<Temp_Products>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().HasData(
              new Products()
              {
                  productId = 1,
                  productMarca = "Nike",
                  productModelo = "Air Force 1",
                  productTipo = "Rojo, con detalles negros",
                  productColor = "Rojo",
                  productTalla = 42.5,
                  productGenero = 'F',
                  productPrecio = 500.0,
                  productUbicacion = "Bodega"
                  


             },
              new Products()
              {
                 productId = 2,
                  productMarca = "Adidas",
                  productModelo = "Road Street",
                  productTipo = "Blanco, con detalles negros",
                  productColor = "Blanco",
                 productTalla = 42.5,
                 productGenero = 'F',
                 productPrecio = 500.0,
                  productUbicacion = "Bodega"

              },
              new Products()
              {
                  productId = 3,
                 productMarca = "New Balance",
                 productModelo = "Zapatillas",
                 productTipo = "Rojo, con detalles negros",
                  productColor = "Amarillo",
                productTalla = 42.5,
                  productGenero = 'F',
                  productPrecio = 500.0,
                  productUbicacion = "Bodega"

               },
                 new Products()
               {
                 productId = 4,
                  productMarca = "Lacoste",
                  productModelo = "Zapatos",
                  productTipo = "Rojo, con detalles negros",
                  productColor = "Verde",
                  productTalla = 42.5,
                  productGenero = 'F',
                  productPrecio = 500.0,
                  productUbicacion = "Bodega"

              }) ;
        }

        
    }
}
