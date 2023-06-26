using Microsoft.EntityFrameworkCore;

namespace Insttantt.Workflow.Persistence.EntityFramework.Mapping;
public partial class WorkflowMap
    : IEntityTypeConfiguration<Models.Workflow>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Models.Workflow> builder)
    {
        // table
        builder.ToTable("Workflow", "dbo");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("Id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Code)
            .IsRequired()
            .HasColumnName("code")
            .HasColumnType("varchar(50)")
            .HasMaxLength(50);

        builder.Property(t => t.Name)
            .IsRequired()
            .HasColumnName("name")
            .HasColumnType("varchar(150)")
            .HasMaxLength(150);


    }

    public readonly struct Table
    {
        public const string Schema = "dbo";
        public const string Name = "Workflow";
    }

    public readonly struct Columns
    {
        public const string Id = "Id";
        public const string Code = "code";
        public const string Name = "name";
    }

}
