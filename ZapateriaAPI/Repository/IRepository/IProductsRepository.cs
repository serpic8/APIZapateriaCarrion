using ZapateriaAPI.Models;

namespace ZapateriaAPI.Repository.IRepository
{
    public interface IProductsRepository : IRepository<Products>
    {
        Task SaveAsync();
        Task<Products> Update(Products entity);
        Task<Products> AddProduct(Products entity);
        Task<Products> GetById(int id);
        Task Delete(Products entity);


    }
}
