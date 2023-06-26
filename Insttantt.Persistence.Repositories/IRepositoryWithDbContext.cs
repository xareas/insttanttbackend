using Microsoft.EntityFrameworkCore;

namespace Insttantt.Workflow.Persistence.Repositories;

/// <summary>
/// Contexto de EF en los repositorios
/// </summary>
public interface IRepositoryWithDbContext
{
    DbContext GetDbContext();
    Task<DbContext> GetDbContextAsync();
}

