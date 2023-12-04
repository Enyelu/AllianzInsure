using AllianzeInsure.Core;
using AllianzInsure.Infrastructure;
using AllianzInsure.Server.Extensions;
using AllianzInsure.Server.Middlewares;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCore();
builder.Services.AddCors();
builder.Services.AddRouting();
builder.Services.AddAntiforgery();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();

//builder.Services.AddDbContext<ApplicationContext>(context => context.UseMySQL(builder.Configuration["ConnectionString:MySqlConnection"]));

builder.Services.AddDbContext<ApplicationContext>(context => context.UseMySQL(builder.Configuration["ConnectionString:MySqlConnection"]));
var app = builder.Build();
app.UseCors();
app.ConfigureExceptionHandler();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AllianzInsureApi v1"));

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapFallbackToFile("/index.html");

app.Run();
