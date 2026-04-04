using System.Text.Json.Serialization;
using GameLibraryApi.Data;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
{
   options.UseSqlite("Data Source=games.db"); 
});

var app = builder.Build();

if (app.Environment.IsDevelopment()) app.MapOpenApi();

app.MapControllers();

app.UseHttpsRedirection();

app.Run();
