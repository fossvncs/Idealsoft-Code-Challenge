using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Application;
using Infrastructure.Repositories;
using Infrastructure.Interfaces;
using Application.Interfaces;
using Infrastructure.DataInitialization;


var builder = WebApplication.CreateBuilder(args);

// Configurar o DbContext para usar InMemoryDatabase
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb"));

//DEPENDENCY INJECTION
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserApplication, UserApplication>();

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

app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
// Chamar o método de seeding
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<MyDbContext>();
    SeedData.Initialize(services, context); // Popula os dados iniciais
}


app.Run();
