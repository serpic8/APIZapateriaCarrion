using ZapateriaAPI.DbContexts;
using ZapateriaAPI.Models;
using ZapateriaAPI.Repository.IRepository;

namespace ZapateriaAPI.Repository
{
    public class InventaryRepository : Repository<Inventary>, IInventaryRepository
    {
        private readonly DataContext _db;

        public InventaryRepository(DataContext db) : base(db)
        {
            _db = db;
        }

        public async Task AddInventary(Inventary entity)
        {
            await _db.Inventaries.AddAsync(entity);
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<Inventary> Update(Inventary entity)
        {
            _db.Inventaries.Update(entity);  //Uso el nombre que use en el data Context
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
