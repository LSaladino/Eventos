using Data.Context;
using Data.Repository;
using EventApi.Configuration;
using EventManager.Interfaces.Managers;
using FluentValidation;
using FluentValidation.AspNetCore;
using Manager;
using Manager.Implementation.Manager;
using Manager.Interfaces.Managers;
using Manager.Interfaces.Repositories;
using Manager.Mappings;
using Manager.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "myPolicy",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});


// Add services to the container.
//var conn = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();

builder.Services.AddJWTConfiguration(builder.Configuration);

// dependency injection
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserManager, UserManager>();

builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventManager, EventtManager>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerManager, CustomerManager>();

builder.Services.AddDbContext<MyContext>(
    c => c.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection2"))
);


// validations
builder.Services
    .AddValidatorsFromAssemblyContaining(typeof(NewEventValidator))
    .AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();

builder.Services
    .AddValidatorsFromAssemblyContaining(typeof(NewUserValidator))
    .AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();

builder.Services
    .AddValidatorsFromAssemblyContaining(typeof(NewCustomerValidator))
    .AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();

// mapper
builder.Services.AddAutoMapper(typeof(NewEventMappingProfile), typeof(UpdateEventMappingProfile));
builder.Services.AddAutoMapper(typeof(NewUserMappingProfile), typeof(UpdateUserMappingProfile));
builder.Services.AddAutoMapper(typeof(NewCustomerMappingProfile), typeof(UpdateCustomerMappingProfile));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(g =>
{
    g.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Insert Token, please",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    g.AddSecurityRequirement(new OpenApiSecurityRequirement {
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
            new string[] { }
        }
    });
});

builder.Services.AddCors();

var app = builder.Build();

app.UseCors("myPolicy");
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();
app.UseJwtConfiguration();

app.MapControllers();

app.Run();
