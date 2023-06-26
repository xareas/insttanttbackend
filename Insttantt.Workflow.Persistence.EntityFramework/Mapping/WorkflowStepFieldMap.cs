using Insttantt.Workflow.Models;
using Microsoft.EntityFrameworkCore;

namespace Insttantt.Workflow.Persistence.EntityFramework.Mapping;
public partial class WorkflowStepFieldMap
    : IEntityTypeConfiguration<WorkflowStepField>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Models.WorkflowStepField> builder)
    {
        // table
        builder.ToTable("WorkflowStepField", "dbo");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("Id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.WorkflowStepId)
            .IsRequired()
            .HasColumnName("WorkflowStepId")
            .HasColumnType("int");

        builder.Property(t => t.FieldId)
            .IsRequired()
            .HasColumnName("FieldId")
            .HasColumnType("int");

        builder.Property(t => t.SetValue)
            .HasColumnName("SetValue")
            .HasColumnType("varchar(250)")
            .HasMaxLength(250);

        builder.Property(t => t.Output)
            .IsRequired()
            .HasColumnName("Output")
            .HasColumnType("bit");

        // relationships
        //builder.HasOne(t => t.Field)
        //    .WithMany(t => t.WorkflowStepFields)
        //   .HasForeignKey(d => d.FieldId)
        //   .HasConstraintName("FK_WorkflowStepField_Field");

        builder.HasOne(t => t.WorkflowStep)
            .WithMany(t => t.WorkflowStepFields)
            .HasForeignKey(d => d.WorkflowStepId)
            .HasConstraintName("FK_WorkflowStepField_WorkflowStep");


    }

    public readonly struct Table
    {
        public const string Schema = "dbo";
        public const string Name = "WorkflowStepField";
    }

    public readonly struct Columns
    {
        public const string Id = "Id";
        public const string WorkflowStepId = "WorkflowStepId";
        public const string FieldId = "FieldId";
        public const string SetValue = "SetValue";
        public const string Output = "Output";
    }

}
