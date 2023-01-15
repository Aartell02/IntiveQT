using System;
using IntiveQT.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BooksAPIDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("BooksAPICS")));
builder.Services.AddDbContext<AuthorsAPIDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("BooksAPICS")));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();