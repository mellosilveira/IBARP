using DbUp;
using System;
using System.Reflection;

namespace IBARP.Database
{
    public class Program
    {
        static void Main(string[] args)
        {
            string database = "ibarp";
            var connectionString = $"Server=127.0.0.1;Port=5432;Database={database};User Id=postgres;Password=postgres;";

            EnsureDatabase.For.PostgresqlDatabase(connectionString);

            var upgrader = DeployChanges.To.PostgresqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToConsole()
                .Build();

            var result = upgrader.PerformUpgrade();

            Console.Out.WriteLine(result.Successful ? $"'{database}' migration has been success." : $"'{database}' migration failed! {result.Error}");
        }
    }
}
