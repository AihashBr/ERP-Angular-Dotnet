using Application.DTOs.Customer;
using Application.DTOs.Result;
using Application.Service.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repository.Interfaces;
using Kernel.Utils.Pagination;

namespace Application.Service;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    private readonly IPaginationRepository<Customer> _paginationRepository;

    public CustomerService(ICustomerRepository customerRepository, IMapper mapper, IPaginationRepository<Customer> paginationRepository)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
        _paginationRepository = paginationRepository;
    }

    public async Task<Result<CustomerViewDTO>> CreateAsync(CustomerCreateDTO newCustomer)
    {
        if (newCustomer == null)
            throw new ArgumentNullException(nameof(newCustomer), "Dados do cliente não podem ser nulos.");

        var customer = await _customerRepository.AddAsync(_mapper.Map<Customer>(newCustomer));

        return new Result<CustomerViewDTO>
        {
            Success = true,
            Message = "Cliente criado com sucesso.",
            Data = _mapper.Map<CustomerViewDTO>(customer)
        };
    }

    public async Task<Result<CustomerViewDTO>> GetByIdAsync(int id)
    {
        var customer = await _customerRepository.GetByIdAsync(id) ??
            throw new KeyNotFoundException($"Cliente com ID {id} não foi encontrado.");

        return new Result<CustomerViewDTO>
        {
            Success = true,
            Message = "Cliente encontrado com sucesso.",
            Data = _mapper.Map<CustomerViewDTO>(customer)
        };
    }

    public async Task<Result<PagedResult<CustomerViewDTO>>> GetAsync(PaginationParams pagination)
    {
        var (customers, totalItems) = await _paginationRepository.GetPagedAsync(
            pagination.PageNumber,
            pagination.PageSize,
            orderBy: q => q.OrderBy(c => c.Id));

        var pagedResult = new PagedResult<CustomerViewDTO>
        {
            Items = _mapper.Map<List<CustomerViewDTO>>(customers),
            TotalItems = totalItems,
            PageNumber = pagination.PageNumber,
            PageSize = pagination.PageSize
        };

        return new Result<PagedResult<CustomerViewDTO>>
        {
            Success = true,
            Message = "Clientes listados com sucesso.",
            Data = pagedResult
        };
    }

    public async Task<Result<CustomerViewDTO>> UpdateAsync(CustomerCreateDTO newCustomer)
    {
        if (newCustomer == null)
            throw new ArgumentNullException(nameof(newCustomer), "Dados do cliente não podem ser nulos.");


        var customer = await _customerRepository.GetByIdAsync(newCustomer.Id) ??
            throw new KeyNotFoundException($"Cliente com ID {newCustomer.Id} não foi encontrado.");

        _mapper.Map(newCustomer, customer);

        var updatedCustomer = await _customerRepository.UpdateAsync(customer);

        return new Result<CustomerViewDTO>
        {
            Success = true,
            Message = "Cliente atualizado com sucesso.",
            Data = _mapper.Map<CustomerViewDTO>(updatedCustomer)
        };
    }

    public async Task<Result<CustomerViewDTO>> DeleteAsync(int id)
    {
        var customer = await _customerRepository.GetByIdAsync(id) ??
            throw new KeyNotFoundException($"Cliente com ID {id} não foi encontrado.");

        var deletedCustomer = await _customerRepository.DeleteAsync(customer);

        return new Result<CustomerViewDTO>
        {
            Success = true,
            Message = "Cliente excluído com sucesso.",
            Data = _mapper.Map<CustomerViewDTO>(deletedCustomer)
        };
    }
}
