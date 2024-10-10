using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Encuba.Exam.Api.Configurations.AutofacConfig;
using Encuba.Exam.Domain.Seed;
using Encuba.Exam.Infrastructure;
using Encuba.Exam.Infrastructure.Middlewares;
using Encuba.Exam.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Exceptions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers()
    .AddNewtonsoftJson(opt =>
        opt.SerializerSettings.ContractResolver = new PrivateSetterContractResolver());

// Load the configuration from appsettings.json and environment variables
builder.Configuration.AddEnvironmentVariables();

var connectionString = builder.Configuration.GetConnectionString("Security") 
                       ?? Environment.GetEnvironmentVariable("ConnectionStrings__Security");

builder.Services.AddDbContext<SecurityDbContext>(options =>
    options.UseSqlServer(connectionString));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Encuba Test",
        Description = "Api rest microservice for security",
        Contact = new OpenApiContact
        {
            Name = "Andrés Noboa",
            Email = "andres.noboa95@outlook.com"
        }
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});
builder.Services.AddControllers();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    containerBuilder.RegisterModule(new RepositoryModule()));
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    containerBuilder.RegisterModule(new MediatorModule()));

builder.Services.AddOptions<JWT>()
    .BindConfiguration("JWT")
    .ValidateDataAnnotations();

builder.Services.AddAuthentication("JWT")
    .AddScheme<JwtAuthenticationSchemaOptions, JwtAuthenticationHandler>("JWT", null);


//Add serilog
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .MinimumLevel.Verbose()
    .Enrich.WithProperty("SecurityDbContext", "Encuba.Exam.Api")
    .Enrich.FromLogContext()
    .Enrich.WithExceptionDetails()
    .WriteTo.Console()
    .CreateLogger();
builder.Host.UseSerilog(logger);

var app = builder.Build();

app.UseMiddleware<RequestResponseLoggingMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder =>
{
    builder.WithOrigins("http://10.0.2.2:5000")
        .AllowAnyMethod()
        .AllowAnyHeader();
});
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();