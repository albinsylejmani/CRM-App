using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using CrmProject.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAllOrigins",
                      policy  =>
                      {
                          policy.WithOrigins("http://localhost:4200",
                                              "http://localhost:4200");
                      });
});


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRegisterRepository, RegisterRepository>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();

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

app.UseCors("AllowAllOrigins");

app.MapControllers();

app.Run();
