using HalcyonApparelsApplication.Interfaces;
using HalcyonApparelsInfrastructure.Data.Repository;
using HalcyonApparelsInfrastructure.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("default")));
builder.Services.AddScoped<IAccessory, AccessoryImplement>();
builder.Services.AddScoped<ISalesforceCrud, SalesforceCrud>();
builder.Services.AddScoped<IMapping, Mapping>();
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
