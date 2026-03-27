using System.Security;
using Project.Application.Contract;
using Project.Application.DTOs;
using Project.Infrastructure.Contracts;
using Project.Infrastructure.Entities;
using Project.Utility;
using Project.Utility.Resource;

 

namespace Project.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repo;

    public ProductService(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<Product>> GetProducts()
    { //validation 
     
        return await _repo.GetAll();
    }

    public async Task<Product> GetById(int id)
    { if (id <= 0)
        {
           throw new BadRequest("invalid id");
        }
        var product = await _repo.GetById(id);
        if (product == null)
        {
            throw new NotFound("not found");
        }
        return product;
        
    }

    public async Task<Product> AddProduct(CreateProductDto dto)
    {
        Product p = new Product
        {
            Name = dto.Name,
            Price = dto.Price,
            Quantity = dto.Quantity,
            // Category = dto.Category,
            CreatedDate = DateTime.Now
        };

        return await _repo.Add(p);
    }

    public async Task UpdateProduct(int id, ProductDto dto)
    {
        var product = await _repo.GetById(id);
            if (product == null)
            {
                throw new NotFound("not found");
            }
        product.Name = dto.Name;
        product.Price = dto.Price;
        product.Quantity = dto.Quantity;
        product.Category = dto.Category;

        await _repo.Update(product);
    }

    public async Task DeleteProduct(int id)
    {
        var product = await _repo.GetById(id);

        if (product == null)
        {
            throw new NotFound("not found");
        }

        await _repo.Delete(product);
    }
   

}