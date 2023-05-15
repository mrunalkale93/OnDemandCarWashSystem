using CarWashSystem;
using CarWashSystem.Data;
using CarWashSystem.Interface;
using CarWashSystem.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CarWashDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("CarWashConnectionString")));
builder.Services.AddScoped<IUser,UserRepository>();
builder.Services.AddScoped<IAddon, AddonRepository>();
builder.Services.AddScoped<IWashPackage, WashPackageRepository>();
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
