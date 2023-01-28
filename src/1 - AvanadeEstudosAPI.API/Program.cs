using AutoMapper;
using AvanadeEstudosAPI.Domain.Interfaces;
using AvanadeEstudosAPI.Infra.Context;
using AvanadeEstudosAPI.Infra.Repositories;
using AvanadeEstudosAPI.Profiles;
using AvanadeEstudosAPI.Services.Interfaces;
using AvanadeEstudosAPI.Services.Services;
using Microsoft.EntityFrameworkCore;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Configuration.AddAzureKeyVault(
       "https://kvestudosapi.vault.azure.net/",
       "7f3777b3-1ed4-42ad-a248-5f74da7e165f",
       "a9t8Q~WeqZCEU2ZChArvETYYa9HpGfZqyIKv6dho");


builder.Services.AddDbContext<AvanadeEstudosAPIContext>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("DefaultConnection")
));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

var automapper = new MapperConfiguration(item => item.AddProfile(new UserProfile()));
IMapper mapper = automapper.CreateMapper();
builder.Services.AddSingleton(mapper);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
