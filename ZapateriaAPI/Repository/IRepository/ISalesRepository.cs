using ZapateriaAPI.Models;
using ZapateriaAPI.Repository.IRepository;

public interface ISalesRepository : IRepository<Sales>
{
    Task<Sales> GetById(int id);
    //Task<IEnumerable<Sales>> GetAll();
    Task<Sales> AddSale(Sales entity);
    Task<Sales> Update(Sales entity);
    Task Delete(int id);
    Task Delete(Sales entity);
    Task SaveAsync();
}