using Data.Context;
using Services;
using Microsoft.EntityFrameworkCore;
using Services.Mapping;
using System.Reflection.PortableExecutable;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LessonsDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseCors(builder =>
    builder.WithOrigins("https://localhost:3000", "http://localhost:3000")
           .AllowAnyHeader()
           .AllowAnyMethod());

app.MapControllers();

app.Run();
