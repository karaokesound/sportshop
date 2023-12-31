using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Sportshop.Application.Commands.Authentication.Login;
using Sportshop.Application.Commands.Products.CreateProduct;
using Sportshop.Application.Extensions;
using Sportshop.Application.Queries.Product.GetProducts;
using Sportshop.Application.Repositories;
using Sportshop.Application.Services.Authentication;
using Sportshop.Application.Services.Product;
using Sportshop.Persistence;
using Sportshop.Persistence.Context;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddMediatR(x => x.AsScoped(), typeof(GetProductsQuery));
builder.Services.AddMediatR(x => x.AsScoped(), typeof(CreateProductCommand));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
    {
        Description = "Standard Authorization header Using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

// Database
builder.Services.AddDbContext<SportshopDbContext>(dbContextOptions =>
    dbContextOptions.UseSqlServer(builder.Configuration["ConnectionStrings:SportshopDBConnectionString"]));

// Authentication
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
        };
    });

// Services
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddTransient<GlobalExceptionsHandlingMiddleware>();
builder.Services.AddHttpContextAccessor();

// FluentValidation
builder.Services.AddFluentValidation(cfg =>
{
    cfg.RegisterValidatorsFromAssemblyContaining<LoginCommand>();
});

// Serilog for DI
builder.Services.AddScoped<Serilog.ILogger>(_ =>
{
    return new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .CreateLogger();
});

// Serilog Configuration
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

// Database seeding
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<SportshopDbContext>();
    await DbSeeder.Seed(context);
}

// HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionsHandlingMiddleware>();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();

});

app.Run();