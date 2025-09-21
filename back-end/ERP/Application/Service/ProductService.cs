using Application.DTOs.Product;
using Application.DTOs.Result;
using Application.Service.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repository.Interfaces;
using Kernel.Utils.Pagination;

namespace Application.Service;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IPaginationRepository<Product> _paginationRepository;

    public ProductService(IProductRepository productRepository, IMapper mapper, IPaginationRepository<Product> paginationRepository)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _paginationRepository = paginationRepository;
    }

    public async Task<Result<ProductViewDTO>> CreateAsync(ProductCreateDTO newProduct)
    {
        if (newProduct == null)
            throw new ArgumentNullException(nameof(newProduct), "Dados do produto não podem ser nulos.");

        var existingProduct = await _productRepository.GetAsync(filter: p => p.Name == newProduct.Name && p.CompanyId == newProduct.CompanyId);

        if (existingProduct.Count > 0)
        {
            return new Result<ProductViewDTO>
            {
                Success = false,
                Message = "Já existe um produto com este nome para esta empresa."
            };
        }

        var product = await _productRepository.AddAsync(_mapper.Map<Product>(newProduct));

        return new Result<ProductViewDTO>
        {
            Success = true,
            Message = "Produto criado com sucesso.",
            Data = _mapper.Map<ProductViewDTO>(product)
        };
    }

    public async Task<Result<ProductViewDTO>> GetByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id) ??
            throw new KeyNotFoundException($"Produto com ID {id} não foi encontrado.");

        return new Result<ProductViewDTO>
        {
            Success = true,
            Message = "Produto encontrado com sucesso.",
            Data = _mapper.Map<ProductViewDTO>(product)
        };
    }

    public async Task<Result<PagedResult<ProductViewDTO>>> GetAsync(PaginationParams pagination)
    {
        var (products, totalItems) = await _paginationRepository.GetPagedAsync(
            pagination.PageNumber,
            pagination.PageSize,
            orderBy: product => product.OrderBy(p => p.Id));

        var pagedResult = new PagedResult<ProductViewDTO>
        {
            Items = _mapper.Map<List<ProductViewDTO>>(products),
            TotalItems = totalItems,
            PageNumber = pagination.PageNumber,
            PageSize = pagination.PageSize
        };

        return new Result<PagedResult<ProductViewDTO>>
        {
            Success = true,
            Message = "Produtos listados com sucesso.",
            Data = pagedResult
        };
    }

    public async Task<Result<ProductViewDTO>> UpdateAsync(ProductCreateDTO newProduct)
    {
        if (newProduct == null)
            throw new ArgumentNullException(nameof(newProduct), "Dados do produto não podem ser nulos.");

        var existingProduct = await _productRepository.GetAsync(filter: p => p.Name == newProduct.Name && p.CompanyId == newProduct.CompanyId);

        if (existingProduct.Count > 0 && existingProduct[0].Id != newProduct.Id)
        {
            return new Result<ProductViewDTO>
            {
                Success = false,
                Message = "Já existe um produto com este nome para esta empresa."
            };
        }

        var product = await _productRepository.GetByIdAsync(newProduct.Id) ??
            throw new KeyNotFoundException($"Produto com ID {newProduct.Id} não foi encontrado.");

        _mapper.Map(newProduct, product);

        var updatedProduct = await _productRepository.UpdateAsync(product);

        return new Result<ProductViewDTO>
        {
            Success = true,
            Message = "Produto atualizado com sucesso.",
            Data = _mapper.Map<ProductViewDTO>(updatedProduct)
        };
    }

    public async Task<Result<ProductViewDTO>> DeleteAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id) ??
            throw new KeyNotFoundException($"Produto com ID {id} não foi encontrado.");

        var deletedProduct = await _productRepository.DeleteAsync(product);

        return new Result<ProductViewDTO>
        {
            Success = true,
            Message = "Produto excluído com sucesso.",
            Data = _mapper.Map<ProductViewDTO>(deletedProduct)
        };
    }
}
