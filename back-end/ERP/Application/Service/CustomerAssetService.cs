using Application.DTOs.CustomerAsset;
using Application.DTOs.Result;
using Application.Service.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repository.Interfaces;
using Kernel.Utils.Pagination;

namespace Application.Service;

public class CustomerAssetService : ICustomerAssetService
{
    private readonly ICustomerAssetRepository _assetRepository;
    private readonly IMapper _mapper;
    private readonly IPaginationRepository<CustomerAsset> _paginationRepository;

    public CustomerAssetService(
        ICustomerAssetRepository assetRepository,
        IMapper mapper,
        IPaginationRepository<CustomerAsset> paginationRepository)
    {
        _assetRepository = assetRepository;
        _mapper = mapper;
        _paginationRepository = paginationRepository;
    }

    public async Task<Result<CustomerAssetViewDTO>> CreateAsync(CustomerAssetCreateDTO newAsset)
    {
        if (newAsset == null)
            throw new ArgumentNullException(nameof(newAsset), "Dados do bem não podem ser nulos.");

        var asset = await _assetRepository.AddAsync(_mapper.Map<CustomerAsset>(newAsset));

        return new Result<CustomerAssetViewDTO>
        {
            Success = true,
            Message = "Bem do cliente criado com sucesso.",
            Data = _mapper.Map<CustomerAssetViewDTO>(asset)
        };
    }

    public async Task<Result<CustomerAssetViewDTO>> GetByIdAsync(int id)
    {
        var asset = await _assetRepository.GetByIdAsync(id) ??
            throw new KeyNotFoundException($"Bem do cliente com ID {id} não foi encontrado.");

        return new Result<CustomerAssetViewDTO>
        {
            Success = true,
            Message = "Bem do cliente encontrado com sucesso.",
            Data = _mapper.Map<CustomerAssetViewDTO>(asset)
        };
    }

    public async Task<Result<PagedResult<CustomerAssetViewDTO>>> GetAsync(PaginationParams pagination)
    {
        var (assets, totalItems) = await _paginationRepository.GetPagedAsync(
            pagination.PageNumber,
            pagination.PageSize,
            orderBy: q => q.OrderBy(a => a.Id));

        var pagedResult = new PagedResult<CustomerAssetViewDTO>
        {
            Items = _mapper.Map<List<CustomerAssetViewDTO>>(assets),
            TotalItems = totalItems,
            PageNumber = pagination.PageNumber,
            PageSize = pagination.PageSize
        };

        return new Result<PagedResult<CustomerAssetViewDTO>>
        {
            Success = true,
            Message = "Bens do cliente listados com sucesso.",
            Data = pagedResult
        };
    }

    public async Task<Result<CustomerAssetViewDTO>> UpdateAsync(CustomerAssetCreateDTO updatedAsset)
    {
        if (updatedAsset == null)
            throw new ArgumentNullException(nameof(updatedAsset), "Dados do bem não podem ser nulos.");

        var asset = await _assetRepository.GetByIdAsync(updatedAsset.Id) ??
            throw new KeyNotFoundException($"Bem do cliente com ID {updatedAsset.Id} não foi encontrado.");

        _mapper.Map(updatedAsset, asset);

        var updated = await _assetRepository.UpdateAsync(asset);

        return new Result<CustomerAssetViewDTO>
        {
            Success = true,
            Message = "Bem do cliente atualizado com sucesso.",
            Data = _mapper.Map<CustomerAssetViewDTO>(updated)
        };
    }

    public async Task<Result<CustomerAssetViewDTO>> DeleteAsync(int id)
    {
        var asset = await _assetRepository.GetByIdAsync(id) ??
            throw new KeyNotFoundException($"Bem do cliente com ID {id} não foi encontrado.");

        var deleted = await _assetRepository.DeleteAsync(asset);

        return new Result<CustomerAssetViewDTO>
        {
            Success = true,
            Message = "Bem do cliente excluído com sucesso.",
            Data = _mapper.Map<CustomerAssetViewDTO>(deleted)
        };
    }
}
