using Insttantt.Workflow.Models;
using Microsoft.EntityFrameworkCore;

namespace Insttantt.Workflow.Persistence.EntityFramework.Mapping;
public partial class WorkflowStepMap : IEntityTypeConfiguration<WorkflowStep>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<WorkflowStep> builder)
    {
        // table
        builder.ToTable("WorkflowStep", "dbo");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("Id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.WorkFlowId)
            .IsRequired()
            .HasColumnName("WorkFlowId")
            .HasColumnType("int");

        builder.Property(t => t.StepId)
            .IsRequired()
            .HasColumnName("StepId")
            .HasColumnType("int");

        builder.Property(t => t.StepNumber)
            .IsRequired()
            .HasColumnName("StepNumber")
            .HasColumnType("int");

        builder.Property(t => t.After)
            .IsRequired()
            .HasColumnName("After")
            .HasColumnType("int");

        builder.Property(t => t.Before)
            .IsRequired()
            .HasColumnName("Before")
            .HasColumnType("int");

        // relationships
        // builder.HasOne(t => t.Step)
        //    .WithMany(t => t.WorkflowSteps)
        //   .HasForeignKey(d => d.StepId)
        //   .HasConstraintName("FK_WorkflowStep_Step");

        builder.HasOne(t => t.Workflow)
            .WithMany(t => t.WorkflowSteps)
            .HasForeignKey(d => d.WorkFlowId)
            .HasConstraintName("FK_WorkflowStep_Workflow");


    }

    public readonly struct Table
    {
        public const string Schema = "dbo";
        public const string Name = "WorkflowStep";
    }

    public readonly struct Columns
    {
        public const string Id = "Id";
        public const string WorkFlowId = "WorkFlowId";
        public const string StepId = "StepId";
        public const string StepNumber = "StepNumber";
        public const string After = "After";
        public const string Before = "Before";
    }

}
