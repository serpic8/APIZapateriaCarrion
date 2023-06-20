using System.Threading.Tasks;
using ZapateriaAPI.Models;

namespace ZapateriaAPI.Repository.IRepository
{
    public interface IInventaryRepository : IRepository<Inventary>
    {
        Task<Inventary> Update(Inventary entity);
        Task AddInventary(Inventary entity);
        Task SaveAsync();
    }
}
