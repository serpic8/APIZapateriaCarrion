using Microsoft.EntityFrameworkCore;
using ZapateriaAPI.DbContexts;
using ZapateriaAPI.Models;
using ZapateriaAPI.Repository.IRepository;
using ZapateriaAPI.Repository;

public class SalesRepository : Repository<Sales>, ISalesRepository
{
    private readonly DataContext _db;

    public SalesRepository(DataContext db) : base(db)
    {
        _db = db;
    }

    public async Task<Sales> GetById(int id)
    {
        return await _db.Saliers.FindAsync(id);
    }

    //public async Task<IEnumerable<Sales>> GetAll()
    //{
    //    return await _db.Saliers.ToListAsync();
    //}

    public async Task<Sales> AddSale(Sales entity)
    {
        await _db.Saliers.AddAsync(entity);
        return entity;
    }


    public async Task<Sales> Update(Sales entity)
    {
        _db.Saliers.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task Delete(int id)
    {
        var sale = await _db.Saliers.FindAsync(id);
        if (sale != null)
        {
            _db.Saliers.Remove(sale);
            await _db.SaveChangesAsync();
        }
    }

    public async Task Delete(Sales entity)
    {
        _db.Saliers.Remove(entity);
        await _db.SaveChangesAsync();
    }

    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }
}