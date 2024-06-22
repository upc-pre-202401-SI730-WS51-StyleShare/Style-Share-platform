using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using StyleShare.Platform.API.Rent.Application.Internal.CommandServices;
using StyleShare.Platform.API.Rent.Application.Internal.QueryServices;
using StyleShare.Platform.API.Rent.Domain.Repositories;
using StyleShare.Platform.API.Rent.Domain.Services;
using StyleShare.Platform.API.Rent.Infrastructure.Persistence.EFC.Repository;
using StyleShare.Platform.API.Shared.Domain.Repositories;
using StyleShare.Platform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using StyleShare.Platform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using StyleShare.Platform.API.Shared.Interfaces.ASP.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Levels
builder.Services.AddDbContext<AppDBContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
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
                Title = "StyleShare.API",
                Version = "v1",
                Description = "Style Share API",
                TermsOfService = new Uri("https://StyleShare.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = "StyleShare",
                    Email = "contact@StyleShare.com"
                },
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

builder.Services.AddScoped<IRentCommandService, RentCommandService>();
builder.Services.AddScoped<IRentRepository, RentRepository>();
builder.Services.AddScoped<IRentQueryService, RentQueryServices >();

builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICartCommandService, CartCommandServices>();
builder.Services.AddScoped<ICartQueryService, CartQueryService>();

builder.Services.AddScoped<IProductCartRepository, ProductCartRepository>();
builder.Services.AddScoped<IProductCartCommandService, ProductCartCommandServices>();
builder.Services.AddScoped<IProductCartQueryService, ProductCartQueryService>();

var app = builder.Build();

//Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDBContext>();
    context.Database.EnsureCreated();
}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
