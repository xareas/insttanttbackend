using DbUp;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;

WriteMessage("Creando la base de datos del Workflow....", ConsoleColor.Blue);

var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", true)
        .Build();

var connectionString = config.GetConnectionString("workflow") ?? "";

if (connectionString.IsNullOrEmpty())
{
    WriteMessage("Cadena de conexcion es invalida....", ConsoleColor.Red);
    return -1;
}

EnsureDatabase.For.SqlDatabase(connectionString);

var dbWf = DeployChanges.To
                            .SqlDatabase(connectionString)
                            .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                            .LogToConsole()
                            .Build();

var result = dbWf.PerformUpgrade();

if (!result.Successful)
{
    WriteMessage(result.Error.Message, ConsoleColor.Red);
#if DEBUG
    Console.ReadLine();
#endif
    return -1;
}
WriteMessage("Base de datos creada", ConsoleColor.Green);
return 0;

void WriteMessage(string message, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.WriteLine(message);
    Console.ResetColor();
}