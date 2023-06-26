namespace Insttantt.Workflow.Shared
{
    [Serializable]
    public class EntityDto<TPrimaryKey> : IEntityDto<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }

        public EntityDto()
        {
        }

        public EntityDto(TPrimaryKey id) => this.Id = id;
    }
}
