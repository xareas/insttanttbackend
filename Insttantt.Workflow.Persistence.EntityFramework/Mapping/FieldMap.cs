using Insttantt.Workflow.Models;
using Microsoft.EntityFrameworkCore;

namespace Insttantt.Workflow.Persistence.EntityFramework.Mapping;
public partial class FieldMap : IEntityTypeConfiguration<Field>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Field> builder)
    {
        // table
        builder.ToTable("Field", "dbo");

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
            .HasColumnName("Code")
            .HasColumnType("varchar(50)")
            .HasMaxLength(50);

        builder.Property(t => t.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("varchar(150)")
            .HasMaxLength(150);


    }


    public readonly struct Table
    {
        public const string Schema = "dbo";
        public const string Name = "Field";
    }

    public readonly struct Columns
    {
        public const string Id = "Id";
        public const string Code = "Code";
        public const string Name = "Name";
    }

}
