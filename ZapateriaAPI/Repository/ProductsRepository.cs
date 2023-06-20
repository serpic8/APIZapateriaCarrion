using ZapateriaAPI.DbContexts;
using ZapateriaAPI.Models;
using ZapateriaAPI.Repository.IRepository;

namespace ZapateriaAPI.Repository
{
    public class ProductsRepository : Repository<Products>, IProductsRepository
    {
        private readonly DataContext _db;

        public ProductsRepository(DataContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Products> AddProduct(Products entity)
        {
            await _db.Producties.AddAsync(entity);
            return entity;
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<Products> Update(Products entity)
        {
            _db.Producties.Update(entity);  //Uso el nombre que use en el data Context
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var product = await _db.Producties.FindAsync(id);
            if (product != null)
            {
                _db.Producties.Remove(product);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<Products> GetById(int id)
        {
            return await _db.Producties.FindAsync(id);
        }

        public async Task Delete(Products entity)
        {
            _db.Producties.Remove(entity);
            await _db.SaveChangesAsync();
        }

    }
}
