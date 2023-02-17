using Microsoft.EntityFrameworkCore;
using PeopleManager.Data;
using PeopleManager.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add AutoMapper .net 6
builder.Services.AddAutoMapper(typeof(Core));
builder.Services.AddDbContext<PessoaDbContext>(opt => opt.UseInMemoryDatabase("PessoasDb"));


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
