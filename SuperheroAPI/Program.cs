using DomainSuperhero.Interfaces;
using DomainSuperhero.Models;
using Microsoft.OpenApi.Models;
using SuperheroConnection;
using SuperheroDapper;
using Swashbuckle.AspNetCore.Annotations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<ISuperheroRepository, SuperheroDataConnection>();

builder.Services.AddCors(options => options.AddPolicy(name: "policy",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }));

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Superhero API",
        Description = "An ASP.NET Core Web API for managing heroes",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.EnableAnnotations();
});



var app = builder.Build();

app.MapGet("/Superhero", () => "Superhero").WithMetadata(new SwaggerOperationAttribute("Superheroes", "Gets all superheroes"));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("policy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
