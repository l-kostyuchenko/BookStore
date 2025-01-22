using BookStore.Application.Extensions;
using BookStore.Persistence.Extensions;
using AutoMapper;
using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using BookStore.Web.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	var basePath = AppContext.BaseDirectory;

	var xmlPath = Path.Combine(basePath, "BookStoreAPI.xml");
	options.IncludeXmlComments(xmlPath);
});

builder.Services.AddDependencies();
builder.Services.AddRepositories();
builder.Services.AddContextExtension(builder.Configuration);

builder.Services.AddSingleton(provider => new MapperConfiguration(cfg => 
	{
		cfg.AddProfile(new BookStore.Application.Mapper.MappingProfile());
	})
	.CreateMapper()
);

builder.Services.AddApiVersioning(options =>
{
	options.ReportApiVersions = true;
	options.DefaultApiVersion = new ApiVersion(1, 0);
	options.AssumeDefaultVersionWhenUnspecified = true;
	options.ApiVersionReader = new UrlSegmentApiVersionReader();
})
.AddApiExplorer(options =>
{
	options.GroupNameFormat = "'v'VVV";
	options.SubstituteApiVersionInUrl = true;
});

builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(options =>
	{
		var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
		foreach (var description in provider.ApiVersionDescriptions)
		{
			options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
		}
	});
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Services.UseDBMigration();

app.Run();
