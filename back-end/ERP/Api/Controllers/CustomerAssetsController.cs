using Application.DTOs.CustomerAsset;
using Application.DTOs.Result;
using Application.Service.Interfaces;
using Kernel.Utils.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Tags("Bens do Cliente")]
[ApiController]
[Route("api/[controller]")]
public class CustomerAssetsController : ControllerBase
{
    private readonly ICustomerAssetService _customerAssetService;

    public CustomerAssetsController(ICustomerAssetService customerAssetService)
    {
        _customerAssetService = customerAssetService;
    }

    // Retorna todos os bens (paginados)
    [HttpGet]
    public async Task<ActionResult<Result<PagedResult<CustomerAssetViewDTO>>>> Get([FromQuery] PaginationParams pagination)
    {
        return Ok(await _customerAssetService.GetAsync(pagination));
    }

    // Obtém um bem pelo ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Result<CustomerAssetViewDTO>>> GetById(int id)
    {
        return Ok(await _customerAssetService.GetByIdAsync(id));
    }

    // Cria um novo bem
    [HttpPost]
    public async Task<ActionResult<Result<CustomerAssetViewDTO>>> Create(CustomerAssetCreateDTO asset)
    {
        return Ok(await _customerAssetService.CreateAsync(asset));
    }

    // Atualiza um bem existente
    [HttpPut]
    public async Task<ActionResult<Result<CustomerAssetViewDTO>>> Update(CustomerAssetCreateDTO asset)
    {
        return Ok(await _customerAssetService.UpdateAsync(asset));
    }

    // Remove um bem pelo ID
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await _customerAssetService.DeleteAsync(id));
    }
}
