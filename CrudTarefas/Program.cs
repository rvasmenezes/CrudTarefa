using CrudTarefas.Infra.Data;
using CrudTarefas.Domain;
using CrudTarefas.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using CrudTarefas.API.Validators;
using System.Reflection;
using CrudTarefas.API.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMvc(opt =>
{
    opt.Filters.Add(typeof(ValidateModelAttribute));
})
.AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Program>());

/*
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidateModelAttribute>();
})
.AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(typeof(Program).Assembly));
*/
/*
builder.Services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(typeof(Program).Assembly));

builder.Services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
*/
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfraDependencies();
builder.Services.AddServicesDependencies();

builder.Services.AddDbContext<CrudTarefasEFContext>(options => options.UseMySql(
                                                                builder.Configuration.GetConnectionString("DbContext"),
                                                                new MySqlServerVersion(new Version(8, 0, 11))));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
