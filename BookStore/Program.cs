using Microsoft.EntityFrameworkCore;
using Application.Extensions;
using BookStore.Persistence.Extensions;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDependencies();
builder.Services.AddRepositories();
builder.Services.AddContextExtension(builder.Configuration);

builder.Services.AddSingleton(provider => new MapperConfiguration(cfg => 
	{
		cfg.AddProfile(new Application.Mapper.MappingProfile());
	})
	.CreateMapper()
);

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

app.Services.UseDBMigration();

app.Run();
