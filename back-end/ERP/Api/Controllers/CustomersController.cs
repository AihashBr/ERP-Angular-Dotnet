using Application.DTOs.Customer;
using Application.DTOs.Result;
using Application.Service.Interfaces;
using Kernel.Utils.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Tags("Clientes")]
[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    // Retorna todos os clientes (paginados)
    [HttpGet]
    public async Task<ActionResult<Result<PagedResult<CustomerViewDTO>>>> Get([FromQuery] PaginationParams pagination)
    {
        return Ok(await _customerService.GetAsync(pagination));
    }

    // Obtém um cliente pelo ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Result<CustomerViewDTO>>> GetById(int id)
    {
        return Ok(await _customerService.GetByIdAsync(id));
    }

    // Cria um novo cliente
    [HttpPost]
    public async Task<ActionResult<Result<CustomerViewDTO>>> Create(CustomerCreateDTO customer)
    {
        return Ok(await _customerService.CreateAsync(customer));
    }

    // Atualiza um cliente existente
    [HttpPut]
    public async Task<ActionResult<Result<CustomerViewDTO>>> Update(CustomerCreateDTO customer)
    {
        return Ok(await _customerService.UpdateAsync(customer));
    }

    // Remove um cliente pelo ID
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await _customerService.DeleteAsync(id));
    }
}
