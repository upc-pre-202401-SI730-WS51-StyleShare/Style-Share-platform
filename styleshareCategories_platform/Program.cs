using styleshareCategories_platform.CategoryService.Infrastructure.Persistence.EFC;
using styleshareCategories_platform.Shared.Interfaces.ASP.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using styleshareCategories_platform.CategoryService.Application.Internal.CommandService;
using styleshareCategories_platform.CategoryService.Application.Internal.QueryService;
using styleshareCategories_platform.CategoryService.Domain.Repositories;
using styleshareCategories_platform.CategoryService.Domain.Services;
using styleshareCategories_platform.CategoryService.Infrastructure.Persistence.EFC.Repositories;
using styleshareCategories_platform.Shared.Domain.Repositories;
using styleshareCategories_platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using styleshareCategories_platform.Shared.Infrastructure.Persistence.EFC.Repositories;
using styleshareCategories_platform.Shared.Interfaces.ASP.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            services.AddControllers();

            services.AddDbContext<AppDBContext>(options =>
                options.UseNpgsql(hostContext.Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
        });

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder =>
        {
            builder
                .WithOrigins("http://localhost:5010", "https://styleshare-frontend2-a9ab5.web.app")
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});
// Configure Database Context and Logging Levels
builder.Services.AddDbContext<AppDBContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseNpgsql(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseNpgsql(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();

    }
);
    

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "StyleShare BackEnd API",
                Version = "v1",
                Description = "StyleShare_Categories API Restful",
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
    });

// Configure Lowercase Urls
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Configure Dependency Injection

//Share Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Publishing Bounded Context Injection Configuration
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<ICategoryCommandService, CategoryCommandService>();
builder.Services.AddScoped<ICategoryQueryService, CategoryQueryService>();

var app = builder.Build();

//Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDBContext>();
    context.Database.EnsureCreated();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "StyleShare BackEnd API v1");
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
    
}

app.UseRouting();

app.UseCors("AllowLocalhost");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();       