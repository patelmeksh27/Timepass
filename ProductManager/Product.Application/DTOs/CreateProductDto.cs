namespace Project.Application.DTOs;

public class CreateProductDto
{
   public required string? Name { get; set; }
    public decimal? Price { get; set; }
    public int Quantity { get; set; }
    public string? Category { get; set; } 

}
