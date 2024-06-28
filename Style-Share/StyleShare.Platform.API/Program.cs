using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using StyleShare.Platform.API.Publications.Application.Internal.CommandServices;
using StyleShare.Platform.API.Publications.Application.Internal.QueryServices;
using StyleShare.Platform.API.Publications.Domain.Repositories;
using StyleShare.Platform.API.Publications.Domain.Services;
using StyleShare.Platform.API.Publications.Infrastructure.Persistence.EFC.Repositories;
using StyleShare.Platform.API.Shared.Domain.Repositories;
using StyleShare.Platform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using StyleShare.Platform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using StyleShare.Platform.API.Shared.Interfaces.ASP.Configuration;
using StyleShare.Platform.API.Transactions.Application.Internal.CommandServices;
using StyleShare.Platform.API.Transactions.Application.Internal.QueryServices;
using StyleShare.Platform.API.Transactions.Domain.Repositories;
using StyleShare.Platform.API.Transactions.Domain.Services;
using StyleShare.Platform.API.Transactions.Infrastructure.Persistence.EFC.Repositories;

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
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICommentCommandService, CommentCommandService>();
builder.Services.AddScoped<ICommentQueryService, CommentQueryService>();
builder.Services.AddScoped<IGarmentRepository, GarmentRepository>();
builder.Services.AddScoped<IGarmentCommandService, GarmentCommandService>();
builder.Services.AddScoped<IGarmentQueryService, GarmentQueryService>();
builder.Services.AddScoped<IPublicationRepository, PublicationRepository>();
builder.Services.AddScoped<IPublicationCommandService, PublicationCommandService>();
builder.Services.AddScoped<IPublicationQueryService, PublicationQueryService>();
//Transaction Bounded Context Injection Configuration
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<ITransactionCommandService, TransactionCommandService>();
builder.Services.AddScoped<ITransactionQueryService, TransactionQueryService>();
builder.Services.AddScoped<ITransactionHistoryRepository, TransactionHistoryRepository>();
builder.Services.AddScoped<ITransactionHistoryCommandService, TransactionHistoryCommandService>();
builder.Services.AddScoped<ITransactionHistoryQueryService, TransactionHistoryQueryService>();


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