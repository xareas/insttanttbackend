using Insttantt.Workflow.Models;
using Microsoft.EntityFrameworkCore;

namespace Insttantt.Workflow.Persistence.EntityFramework;

public class InsttanttContext : DbContext
{

    public InsttanttContext()
    {
    }
    public InsttanttContext(DbContextOptions<InsttanttContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine);
    }


    public virtual DbSet<Field> Fields { get; set; } = null!;
    public virtual DbSet<Step> Steps { get; set; } = null!;
    public virtual DbSet<Models.Workflow> Workflows { get; set; } = null!;
    public virtual DbSet<WorkflowStepField> WorkflowStepFields { get; set; } = null!;
    public virtual DbSet<WorkflowStep> WorkflowSteps { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Mapping.FieldMap());
        modelBuilder.ApplyConfiguration(new Mapping.StepMap());
        modelBuilder.ApplyConfiguration(new Mapping.WorkflowMap());
        modelBuilder.ApplyConfiguration(new Mapping.WorkflowStepFieldMap());
        modelBuilder.ApplyConfiguration(new Mapping.WorkflowStepMap());
    }

}