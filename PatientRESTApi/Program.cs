using Microsoft.EntityFrameworkCore;
using PatientRESTApi.Data;
using PatientRESTApi.Services.Implementations;
using PatientRESTApi.Services.Interfaces;

namespace PatientRESTApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));

            builder.Services.AddScoped<IPatientService, PatientService>();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                if (context.Database.IsSqlServer())
                {
                    context.Database.Migrate();
                }
            }

            app.Run("http://*:8080");
        }
    }
}
