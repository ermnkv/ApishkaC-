using CarsApi.Models;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<CarsApiContext>(
            options => options.UseSqlServer(builder.Configuration["ConnectionString"]));

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<CarsApiContext>();
            context.Database.Migrate();
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors(builder => builder.AllowAnyOrigin()
        .AllowAnyHeader() 
        .AllowAnyMethod());

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}