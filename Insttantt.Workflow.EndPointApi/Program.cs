using FluentValidation;
using Insttantt.Workflow.CQRServices.Field;
using Insttantt.Workflow.EndPointApi.Infraestructure;
using Insttantt.Workflow.Persistence.EntityFramework;
using Insttantt.Workflow.Persistence.Repositories;
using Insttantt.Workflow.Rules;
using Microsoft.EntityFrameworkCore;
using NLog;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);


LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();

// Add services to the container.
builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var workFlowDb = builder.Configuration.GetConnectionString("workflow");
//Context de la base de datos
builder.Services.AddDbContext<InsttanttContext>(options => options.UseSqlServer(workFlowDb));

//Registramos repositorios genericos
builder.Services.AddTransient(typeof(IRepository<,>), typeof(Repository<,>));


//Registrando MediatR con integracion de Fluent
ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("es");
builder.Services.AddValidatorsFromAssembly(typeof(FieldRules).Assembly);
//builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateUpdateFieldHandler).Assembly));

var app = builder.Build();

//Configuramos midleware para manejo de excepciones
var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
