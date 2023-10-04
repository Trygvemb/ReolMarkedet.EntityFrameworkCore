using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using RM.DataAccess.Context;
using RM.DataAccess.Implementation;
using RM.Domain.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// adding AutoMapper to the build
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add Entiti framework
builder.Services.AddDbContext<RMManagementDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyDBConnection")));

// adding UnitOfWork to the build
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

// adds json option to ignore cycles
builder.Services.AddMvc().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

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
