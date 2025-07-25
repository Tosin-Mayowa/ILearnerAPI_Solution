using ILearnerAPI.Application.ApplicationExtension;
using ILearnerAPI.Infrastructure.ExtensionMethod.infrastructure;
using ILearnerAPI.Infrastructure.Persistence;
using ILearnerAPI.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (String.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
}
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
  .AddInfrastructureService(connectionString)
  .AddApplication();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesDbContext>();
        dbContext.Database.Migrate();


        var courseSeeder = scope.ServiceProvider.GetRequiredService<ICourseSeeders>();
        await courseSeeder.Seed(); 

        Console.WriteLine("Database migrations applied and seed data initialized successfully.");


    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
