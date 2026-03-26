using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Infrastructure.Entities;

namespace Project.Infrastructure.Contracts
{
    public interface IProductRepository
    {
        
        Task<List<Product>> GetAll();
        Task<Product?> GetById(int id);
        Task<Product> Add(Product product);
        Task Update(Product product);
        Task Delete(Product product);
    }
}