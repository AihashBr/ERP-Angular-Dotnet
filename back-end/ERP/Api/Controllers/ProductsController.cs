using Application.DTOs.Product;
using Application.DTOs.Result;
using Application.Service.Interfaces;
using Kernel.Utils.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Tags("Produtos")]
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    // Retorna todos os produtos (paginados).
    [HttpGet]
    public async Task<ActionResult<Result<PagedResult<ProductViewDTO>>>> Get([FromQuery] PaginationParams pagination)
    {
        return Ok(await _productService.GetAsync(pagination));
    }

    // Obtém um produto pelo ID.
    [HttpGet("{id}")]
    public async Task<ActionResult<Result<ProductViewDTO>>> GetById(int id)
    {
        return Ok(await _productService.GetByIdAsync(id));
    }

    // Cria um novo produto.
    [HttpPost]
    public async Task<ActionResult<Result<ProductViewDTO>>> Create(ProductCreateDTO product)
    {
        return Ok(await _productService.CreateAsync(product));
    }

    // Atualiza um produto existente.
    [HttpPut]
    public async Task<ActionResult<Result<ProductViewDTO>>> Update(ProductCreateDTO product)
    {
        return Ok(await _productService.UpdateAsync(product));
    }

    // Remove um produto pelo ID.
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await _productService.DeleteAsync(id));
    }
}
