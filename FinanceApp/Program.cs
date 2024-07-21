using FinanceApp.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            // Build configuration
            var configuration = builder.Configuration;

            ConfigureDatabase(builder, configuration, builder.Environment);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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
        }

        private static void ConfigureDatabase(WebApplicationBuilder builder, ConfigurationManager configuration, IWebHostEnvironment env)
        {
            // Replace the placeholder in the connection string
            var dbPathPlaceholder = "{DBPath}";
            var connectionString = configuration.GetConnectionString("DatabaseConnectionString");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("Connection string is empty or null");
            }

            if (connectionString.Contains(dbPathPlaceholder))
            {
                var currentDir = env.ContentRootPath;
                var parentDir = Directory.GetParent(currentDir).FullName;

                connectionString = connectionString.Replace(dbPathPlaceholder, parentDir);
            }

            builder.Services.AddDbContext<FinanceDbContext>(options =>
                options.UseSqlite(connectionString));
        }
    }
}
