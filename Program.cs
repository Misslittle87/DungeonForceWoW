namespace DungeonForceWoW
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(AddConfiguration)
            .ConfigureWebHostDefaults(webBuilder =>
            {
            webBuilder.UseStartup<Startup>();
            });

        private static void AddConfiguration(HostBuilderContext hbContext, IConfigurationBuilder icBuilder)
        {
            icBuilder.Sources.Clear();

            icBuilder.SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("config.json")
                     .AddEnvironmentVariables();
        }
    }
}