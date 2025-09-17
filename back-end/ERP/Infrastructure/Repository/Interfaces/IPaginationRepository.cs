using System.Linq.Expressions;

namespace Infrastructure.Repository.Interfaces;
public interface IPaginationRepository<T> where T : class
{
    Task<(List<T> Items, int TotalItems)> GetPagedAsync(
        int pageNumber,
        int pageSize,
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null);
}
