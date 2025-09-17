using Application.DTOs.Company;
using Application.DTOs.Result;
using Application.Service.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repository.Interfaces;
using Kernel.Utils.Pagination;

namespace Application.Service;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IMapper _mapper;
    private readonly IPaginationRepository<Company> _paginationRepository;

    public CompanyService(ICompanyRepository companyRepository, IMapper mapper, IPaginationRepository<Company> paginationRepository)
    {
        _companyRepository = companyRepository;
        _mapper = mapper;
        _paginationRepository = paginationRepository;
    }

    public async Task<Result<CompanyViewDTO>> CreateAsync(CompanyCreateDTO newCompany)
    {
        if (newCompany == null)
            throw new ArgumentNullException(nameof(newCompany), "Dados da empresa não podem ser nulos.");

        var existingCompany = await _companyRepository.GetAsync(filter: c => c.Cnpj == newCompany.Cnpj);

        if (existingCompany.Count > 0)
        {
            return new Result<CompanyViewDTO>
            {
                Success = false,
                Message = "Já existe uma empresa com este CNPJ."
            };
        }

        var company = await _companyRepository.AddAsync(_mapper.Map<Company>(newCompany));

        return new Result<CompanyViewDTO>
        {
            Success = true,
            Message = "Empresa criada com sucesso.",
            Data = _mapper.Map<CompanyViewDTO>(company)
        };
    }

    public async Task<Result<CompanyViewDTO>> GetByIdAsync(int id)
    {
        var company = await _companyRepository.GetByIdAsync(id) ??
            throw new KeyNotFoundException($"Empresa com ID {id} não foi encontrada.");

        return new Result<CompanyViewDTO>
        {
            Success = true,
            Message = "Empresa encontrada com sucesso.",
            Data = _mapper.Map<CompanyViewDTO>(company)
        };
    }

    public async Task<Result<PagedResult<CompanyViewDTO>>> GetAsync(PaginationParams pagination)
    {
        var (companies, totalItems) = await _paginationRepository.GetPagedAsync(
            pagination.PageNumber,
            pagination.PageSize,
            orderBy: company => company.OrderBy(c => c.Id));

        var pagedResult = new PagedResult<CompanyViewDTO>
        {
            Items = _mapper.Map<List<CompanyViewDTO>>(companies),
            TotalItems = totalItems,
            PageNumber = pagination.PageNumber,
            PageSize = pagination.PageSize
        };

        return new Result<PagedResult<CompanyViewDTO>>
        {
            Success = true,
            Message = "Empresas listadas com sucesso.",
            Data = pagedResult
        };
    }

    public async Task<Result<CompanyViewDTO>> UpdateAsync(CompanyCreateDTO newCompany)
    {
        if (newCompany == null)
            throw new ArgumentNullException(nameof(newCompany), "Dados da empresa não podem ser nulos.");

        var existingCompany = await _companyRepository.GetAsync(filter: c => c.Cnpj == newCompany.Cnpj);

        if (existingCompany.Count > 0 && existingCompany[0].Id != newCompany.Id)
        {
            return new Result<CompanyViewDTO>
            {
                Success = false,
                Message = "Já existe uma empresa com este CNPJ."
            };
        }

        var company = await _companyRepository.GetByIdAsync(newCompany.Id) ??
            throw new KeyNotFoundException($"Empresa com ID {newCompany.Id} não foi encontrada.");

        _mapper.Map(newCompany, company);

        var updatedCompany = await _companyRepository.UpdateAsync(company);

        return new Result<CompanyViewDTO>
        {
            Success = true,
            Message = "Empresa atualizada com sucesso.",
            Data = _mapper.Map<CompanyViewDTO>(updatedCompany)
        };
    }

    public async Task<Result<CompanyViewDTO>> DeleteAsync(int id)
    {
        var company = await _companyRepository.GetByIdAsync(id) ??
            throw new KeyNotFoundException($"Empresa com ID {id} não foi encontrada.");

        var deletedCompany = await _companyRepository.DeleteAsync(company);

        return new Result<CompanyViewDTO>
        {
            Success = true,
            Message = "Empresa excluída com sucesso.",
            Data = _mapper.Map<CompanyViewDTO>(deletedCompany)
        };
    }
}
