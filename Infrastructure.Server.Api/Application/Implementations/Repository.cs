using Application.Abstractions;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Application.Implementations;

public class Repository<TEntity>(InfrastructureContext dbContext) : IRepository<TEntity> where TEntity : class
{

    public async Task<bool> Add(TEntity entity)
    {
        try
        {
            await dbContext.AddAsync(entity);

            await dbContext.SaveChangesAsync();

            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<List<TEntity>> Get()
    {
        return await dbContext.Set<TEntity>().ToListAsync();
    }
}
