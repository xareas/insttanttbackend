using System.Runtime.Serialization;

namespace Insttantt.Workflow.Persistence.Repositories;

/// <summary>
/// Manejo de excepcion elemento no encontrada de la entidad
/// </summary>
[Serializable]
public class EntityNotFoundException : Exception
{
    public Type EntityType { get; set; }
    public object Id { get; set; }

    public EntityNotFoundException()
    {
        EntityType = typeof(EntityNotFoundException);
        Id = Guid.NewGuid();
    }

    public EntityNotFoundException(SerializationInfo serializationInfo, StreamingContext context)
        : base(serializationInfo, context)
    {
        EntityType = typeof(EntityNotFoundException);
        Id = Guid.NewGuid();
    }

    public EntityNotFoundException(Type entityType, object id)
        : this(entityType, id, null!)
    {

    }

    public EntityNotFoundException(Type entityType, object id, Exception innerException)
        : base($"La Entidad no existe. Tipo Entidad: {entityType.FullName}, id: {id}", innerException)
    {
        EntityType = entityType;
        Id = id;
    }

    public EntityNotFoundException(string message)
        : base(message)
    {
        EntityType = typeof(EntityNotFoundException);
        Id = Guid.NewGuid();
    }

    public EntityNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
        EntityType = typeof(EntityNotFoundException);
        Id = Guid.NewGuid();
    }

}

