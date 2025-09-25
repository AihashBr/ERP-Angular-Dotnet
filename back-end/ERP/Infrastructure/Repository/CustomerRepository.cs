using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository;

public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _context;

    public CustomerRepository(AppDbContext context)
    {
        _context = context;
    }

    // CREATE
    public async Task<Customer> AddAsync(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
        return customer;
    }

    // READ BY ID
    public async Task<Customer?> GetByIdAsync(int id)
    {
        return await _context.Customers
            .Include(c => c.City) // inclui a relação com City
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    // READ COM FILTRO E ORDENAÇÃO
    public async Task<List<Customer>> GetAsync(
        Expression<Func<Customer, bool>>? filter = null,
        Func<IQueryable<Customer>, IOrderedQueryable<Customer>>? orderBy = null)
    {
        IQueryable<Customer> query = _context.Customers
            .Include(c => c.City); // inclui a relação com City

        if (filter != null)
            query = query.Where(filter);

        if (orderBy != null)
            query = orderBy(query);

        return await query.ToListAsync();
    }

    // UPDATE
    public async Task<Customer> UpdateAsync(Customer customer)
    {
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
        return customer;
    }

    // DELETE
    public async Task<Customer> DeleteAsync(Customer customer)
    {
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
        return customer;
    }
}
