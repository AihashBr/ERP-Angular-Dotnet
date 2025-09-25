using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository;

public class CustomerAssetRepository : ICustomerAssetRepository
{
    private readonly AppDbContext _context;

    public CustomerAssetRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<CustomerAsset> AddAsync(CustomerAsset asset)
    {
        _context.CustomerAssets.Add(asset);
        await _context.SaveChangesAsync();
        return asset;
    }

    public async Task<CustomerAsset?> GetByIdAsync(int id)
    {
        return await _context.CustomerAssets
            .Include(a => a.Customer)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<List<CustomerAsset>> GetAsync(
        Expression<Func<CustomerAsset, bool>>? filter = null,
        Func<IQueryable<CustomerAsset>, IOrderedQueryable<CustomerAsset>>? orderBy = null)
    {
        IQueryable<CustomerAsset> query = _context.CustomerAssets.Include(a => a.Customer);

        if (filter != null)
            query = query.Where(filter);

        if (orderBy != null)
            query = orderBy(query);

        return await query.ToListAsync();
    }

    public async Task<CustomerAsset> UpdateAsync(CustomerAsset asset)
    {
        _context.CustomerAssets.Update(asset);
        await _context.SaveChangesAsync();
        return asset;
    }

    public async Task<CustomerAsset> DeleteAsync(CustomerAsset asset)
    {
        _context.CustomerAssets.Remove(asset);
        await _context.SaveChangesAsync();
        return asset;
    }
}
