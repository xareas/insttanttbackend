using Insttantt.Workflow.Persistence.EntityFramework;
using Insttantt.Workflow.Shared;

namespace Insttantt.Workflow.Persistence.Repositories
{
    public class Repository<TEntity, TKey> : RepositoryAsync<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        public Repository(InsttanttContext context) : base(context)
        {
        }
    }
}
