using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Application.DTOs;
using Project.Infrastructure.Entities;

namespace Project.Application.Contract
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetById(int id);
        Task<Product> AddProduct(CreateProductDto dto);
        Task UpdateProduct(int id, ProductDto dto);
        Task DeleteProduct(int id);
        
    }
}