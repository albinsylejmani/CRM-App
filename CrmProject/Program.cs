using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using CrmProject.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CrmProject.Controllers;
using Microsoft.AspNetCore.Identity;
using CrmProject.Database;
using CrmProject.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials()
                  .WithExposedHeaders("Content-Disposition")
                  .WithExposedHeaders("Content-Length")
                  .WithExposedHeaders("Content-Range")
                  .WithHeaders("Content-Type");
        });
});


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRegisterRepository, RegisterRepository>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddScoped<UserManager<UserModel>>();
//builder.Services.AddScoped<UserController>();

// Retrieve the connection string from the configuration
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add DbContext to the container with the specified database provider and connection string
builder.Services.AddDbContext<YourDbContext>(options =>
    options.UseSqlServer(connectionString));

/*builder.Services.AddIdentity<UserModel, IdentityRole>()
    .AddEntityFrameworkStores<YourDbContext>()
    .AddUserManager<UserManager<UserModel>>();*/

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
