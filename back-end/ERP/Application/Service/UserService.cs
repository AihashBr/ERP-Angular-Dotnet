using Application.DTOs.Result;
using Application.DTOs.UserDTO;
using Application.Service.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repository.Interfaces;
using Kernel.Utils.Pagination;

namespace Application.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IPaginationRepository<User> _paginationRepository;

    public UserService(IUserRepository userRepository, IMapper mapper, IPaginationRepository<User> paginationRepository)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _paginationRepository = paginationRepository;
    }


    public async Task<Result<UserViewDTO>> CreateAsync(UserCreateDTO newUser)
    {
        if (newUser == null)
        {
            throw new ArgumentNullException(nameof(newUser), "Dados do usuário não podem ser nulos.");
        }

        var existingUser = await _userRepository.GetAsync(filter: u => u.UserName == newUser.UserName);

        if (existingUser.Count > 0)
        {
            return new Result<UserViewDTO>
            {
                Success = false,
                Message = "Já existe este usuário."
            };
        }

        newUser.Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password);

        var user = await _userRepository.AddAsync(_mapper.Map<User>(newUser));

        return new Result<UserViewDTO>
        {
            Success = true,
            Message = "Usuário criado com sucesso.",
            Data = _mapper.Map<UserViewDTO>(user)
        };
    }

    public async Task<Result<UserViewDTO>> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"Usuário com ID {id} não foi encontrado.");

        return new Result<UserViewDTO>
        {
            Success = true,
            Message = "Usuário encontrado com sucesso.",
            Data = _mapper.Map<UserViewDTO>(user)
        };
    }

    public async Task<Result<PagedResult<UserViewDTO>>> GetAsync(PaginationParams pagination)
    {
        var (users, totalItems) = await _paginationRepository.GetPagedAsync(
            pagination.PageNumber,
            pagination.PageSize,
            orderBy: user => user.OrderBy(u => u.Id));


        var pagedResult = new PagedResult<UserViewDTO>
        {
            Items = _mapper.Map<List<UserViewDTO>>(users),
            TotalItems = totalItems,
            PageNumber = pagination.PageNumber,
            PageSize = pagination.PageSize
        };

        return new Result<PagedResult<UserViewDTO>> {
            Success = true,
            Message = "Usuário atualizado com sucesso.",
            Data = pagedResult
        };
    }

    public async Task<Result<UserViewDTO>> UpdateAsync(UserCreateDTO newUser)
    {
        if (newUser == null)
        {
            throw new ArgumentNullException(nameof(newUser), "Dados do usuário não podem ser nulos.");
        }

        var existingUser = await _userRepository.GetAsync(filter: u => u.UserName == newUser.UserName);

        if (existingUser.Count > 0 && existingUser[0].Id != newUser.Id)
        {
            return new Result<UserViewDTO>
            {
                Success = false,
                Message = "Já existe este usuário."
            };
        }

        var user = await _userRepository.GetByIdAsync(newUser.Id) ?? throw new KeyNotFoundException($"Usuário com ID {newUser.Id} não foi encontrado.");
        _mapper.Map(newUser, user);

        var updatedUser = await _userRepository.UpdateAsync(user);

        return new Result<UserViewDTO>
        {
            Success = true,
            Message = "Usuário atualizado com sucesso.",
            Data = _mapper.Map<UserViewDTO>(updatedUser)
        };
    }

    public async Task<Result<UserViewDTO>> DeleteAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"Usuário com ID {id} não foi encontrado.");

        var userDelete = await _userRepository.DeleteAsync(user);

        return new Result<UserViewDTO>
        {
            Success = true,
            Message = "Usuário excluído com sucesso.",
            Data = _mapper.Map<UserViewDTO>(userDelete)
        };
    }
}
