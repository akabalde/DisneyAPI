using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DisneyAPI.Data;
using DisneyAPI.Controllers;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DisneyAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DisneyAPIContext") ?? throw new InvalidOperationException("Connection string 'DisneyAPIContext' not found.")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<DisneyAPIContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
