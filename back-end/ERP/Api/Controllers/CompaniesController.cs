using Application.DTOs.Company;
using Application.DTOs.Result;
using Application.Service.Interfaces;
using Domain.Entities;
using Kernel.Utils.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Tags("Empresas")]
[ApiController]
[Route("api/[controller]")]
public class CompaniesController : ControllerBase
{
    private readonly ICompanyService _companyService;

    public CompaniesController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    // Retorna todas as empresas (paginadas).
    [HttpGet]
    public async Task<ActionResult<Result<PagedResult<CompanyViewDTO>>>> Get([FromQuery] PaginationParams pagination)
    {
        return Ok(await _companyService.GetAsync(pagination));
    }

    // Obtém uma empresa pelo ID.
    [HttpGet("{id}")]
    public async Task<ActionResult<Result<CompanyViewDTO>>> GetById(int id)
    {
        return Ok(await _companyService.GetByIdAsync(id));
    }

    // Cria uma nova empresa.
    [HttpPost]
    public async Task<ActionResult<Result<CompanyViewDTO>>> Create(CompanyCreateDTO company)
    {
        return Ok(await _companyService.CreateAsync(company));
    }

    // Atualiza uma empresa existente.
    [HttpPut]
    public async Task<ActionResult<Result<CompanyViewDTO>>> Update(CompanyCreateDTO company)
    {
        return Ok(await _companyService.UpdateAsync(company));
    }

    // Remove uma empresa pelo ID.
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await _companyService.DeleteAsync(id));
    }
}
