using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Application;
using Infrastructure.Repositories;
using Infrastructure.Interfaces;
using Application.Interfaces;
using Infrastructure.DataInitialization;


var builder = WebApplication.CreateBuilder(args);

// configurar o DbContext para usar InMemoryDatabase
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb"));

//DEPENDENCY INJECTION
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserApplication, UserApplication>();

// add services to the container.

builder.Services.AddControllers();
// learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
// chamar o método de seeding
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<MyDbContext>();
    SeedData.Initialize(services, context); // popular os dados iniciais
}


app.Run();
