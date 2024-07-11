using CrudTarefas.API.Filters;
using CrudTarefas.Domain;
using CrudTarefas.Infra.Data;
using CrudTarefas.Infra.Data.Context;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMvc(opt =>
{
    opt.Filters.Add(typeof(ValidateModelAttribute));
})
.AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Program>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfraDependencies();
builder.Services.AddServicesDependencies();

builder.Services.AddDbContext<CrudTarefasEFContext>(options => options.UseMySql(
                                                                builder.Configuration.GetConnectionString("DbContext"),
                                                                new MySqlServerVersion(new Version(8, 0, 11))));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
