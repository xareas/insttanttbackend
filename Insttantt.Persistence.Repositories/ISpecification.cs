using System.Linq.Expressions;

namespace Insttantt.Workflow.Persistence.Repositories;

/// <summary>
/// El patron Specification, es usado para definir un nombre reusable y combinable, 
//  de filtros para las entidades y otros objetos de negocios
// como Dtos(Data Transfers Objects)
/// </summary>
/// <typeparam name="T">Entidad o DTO</typeparam>
public interface ISpecification<T>
{
    bool IsSatisfiedBy(T obj);
    Expression<Func<T, bool>> ToExpression();
}

