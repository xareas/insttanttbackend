using Microsoft.EntityFrameworkCore;

namespace Insttantt.Workflow.Persistence.Repositories;


/// <summary>
/// Contexto de Entity
/// </summary>
/// <typeparam name="TDbContext">Contexto</typeparam>
public interface IDbContextProvider<TDbContext>
        where TDbContext : DbContext
{
    TDbContext GetDbContext();
    Task<TDbContext> GetDbContextAsync();
}

