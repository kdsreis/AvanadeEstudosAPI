using AutoMapper;
using AvanadeEstudosAPI.Domain.Interfaces;
using AvanadeEstudosAPI.Infra.Context;
using AvanadeEstudosAPI.Infra.Repositories;
using AvanadeEstudosAPI.Profiles;
using AvanadeEstudosAPI.Services.Interfaces;
using AvanadeEstudosAPI.Services.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
