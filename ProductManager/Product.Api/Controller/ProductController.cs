// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using Project.Api.Controller;
// using Project.Application.Contract;
// using Project.Application.DTOs;


// namespace Project.API.Controllers;

// [ApiController]
// [Route("api/[controller]")]
// [Authorize]
// public class ProductController : BaseApiController
// {
//     private readonly IProductService _service;

//     public ProductController(IProductService service)
//     {
//         _service = service;
//     }

//     [HttpGet]
   
//     public async Task<IActionResult> Get()
//     {
//         return Ok(await _service.GetProducts());
//     }

//     [HttpGet("{id}")]
   
//     public async Task<IActionResult> Get(int id)
//     {
//         return Ok(await _service.GetById(id));
//     }

//     [HttpPost]
 
//     public async Task<IActionResult> Post(CreateProductDto dto)
//     {
//         return Ok(await _service.AddProduct(dto));
//     }

//     [HttpPut("{id}")]

//     public async Task<IActionResult> Put(int id, ProductDto dto)
//     {
//         await _service.UpdateProduct(id, dto);
//         return Ok();
//     }

//     [HttpDelete("{id}")]
  
//     public async Task<IActionResult> Delete(int id)
//     {
//         await _service.DeleteProduct(id);
//         return Ok();
//     }
// }