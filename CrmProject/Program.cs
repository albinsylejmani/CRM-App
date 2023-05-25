using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
//using CrmProject.Database;
using CrmProject.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRegisterRepository, RegisterRepository>();

// Retrieve the connection string from the configuration
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add DbContext to the container with the specified database provider and connection string


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
