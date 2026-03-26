namespace Project.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
// FIX: Inherit from BaseApiController instead of ControllerBase
public class ProductsController : BaseApiController 
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    [Authorize(Roles = "Admin,User")]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _productService.GetProducts();
        return Ok(products); // Uses BaseApiController.Ok()
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,User")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var product = await _productService.GetById(id);
        return Ok(product);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> PostProduct(CreateProductDto productDto)
    {
        var product = await _productService.AddProduct(productDto);
        return Ok(product); 
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        await _productService.DeleteProduct(id);
        return Ok(); // Returns Envelope.Ok()
    }
}