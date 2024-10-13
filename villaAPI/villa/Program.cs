using Microsoft.EntityFrameworkCore;
using Serilog;
using villa.Data;
using AutoMapper;
namespace villa
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Configure Serilog to log to a file
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)//file here for logs in external log and we use rollingInterval for logging in anew file for every day 
                .CreateLogger();

            builder.Host.UseSerilog();

            builder.Services.AddControllers().AddNewtonsoftJson();// add newtonsoftjson for patch method
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add DbContext configuration
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            // Add AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingConfig)); // Specify the assembly explicitly

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication(); 
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
