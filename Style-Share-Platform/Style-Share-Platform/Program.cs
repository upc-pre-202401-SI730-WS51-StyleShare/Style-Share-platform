using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Style_Share_Platform.CategoryService.Application.Internal.CommandService;
using Style_Share_Platform.CategoryService.Application.Internal.QueryService;
using Style_Share_Platform.CategoryService.Domain.Repositories;
using Style_Share_Platform.CategoryService.Domain.Services;
using Style_Share_Platform.CategoryService.Infrastructure.Persistence.EFC.Repositories;
using Style_Share_Platform.Publications.Application.Internal.CommandServices;
using Style_Share_Platform.Publications.Application.Internal.QueryServices;
using Style_Share_Platform.Publications.Domain.Repositories;
using Style_Share_Platform.Publications.Domain.Services;
using Style_Share_Platform.Publications.Infrastructure.Persistence.EFC.Repositories;
using Style_Share_Platform.Rent.Application.Internal.CommandServices;
using Style_Share_Platform.Rent.Application.Internal.QueryServices;
using Style_Share_Platform.Rent.Domain.Repositories;
using Style_Share_Platform.Rent.Domain.Services;
using Style_Share_Platform.Rent.Infrastructure.Persistence.EFC.Repository;
using Style_Share_Platform.Shared.Domain.Repositories;
using Style_Share_Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using Style_Share_Platform.Shared.Infrastructure.Persistence.EFC.Repositories;
using Style_Share_Platform.Shared.Interfaces.ASP.Configuration;

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
// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

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

//Publishing Bounded Context Injection Configuration
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICommentCommandService, CommentCommandService>();
builder.Services.AddScoped<ICommentQueryService, CommentQueryService>();
builder.Services.AddScoped<IGarmentRepository, GarmentRepository>();
builder.Services.AddScoped<IGarmentCommandService, GarmentCommandService>();
builder.Services.AddScoped<IGarmentQueryService, GarmentQueryService>();
builder.Services.AddScoped<IPublicationRepository, PublicationRepository>();
builder.Services.AddScoped<IPublicationCommandService, PublicationCommandService>();
builder.Services.AddScoped<IPublicationQueryService, PublicationQueryService>();

//Publishing Bounded Context Injection Configuration
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<ICategoryCommandService, CategoryCommandService>();
builder.Services.AddScoped<ICategoryQueryService, CategoryQueryService>();

var app = builder.Build();
// Use CORS policy
app.UseCors("AllowAll");
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
