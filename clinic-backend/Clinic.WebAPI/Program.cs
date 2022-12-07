using Clinic.Repository;
using Clinic.Services;
using Clinic.WebAPI.AppConfiguration;
using Clinic.WebAPI.AppConfiguration.ApplicationExtensions;
using Clinic.WebAPI.AppConfiguration.ServicesExtensions;
using Serilog;

var configuration = new ConfigurationBuilder()
.AddJsonFile("appsettings.json", optional: false)
.Build();

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilogConfiguration();
builder.Services.AddDbContextConfiguration(configuration);
builder.Services.AddVersioningConfiguration();
builder.Services.AddMapperConfiguration(); //presentation profile mapper
builder.Services.AddControllers();
builder.Services.AddSwaggerConfiguration(configuration);
builder.Services.AddRepositoryConfiguration(); // DI for repository layer
builder.Services.AddBusinessLogicConfiguration(); //DI for services layer
builder.Services.AddAuthorizationConfiguration(configuration); //1

var app = builder.Build();

await RepositoryInitializer.InitializeRepository(app.Services);

app.UseSerilogConfiguration();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguration();
}

app.UseHttpsRedirection();
app.UseAuthorizationConfiguration(); //2
app.UseMiddleware(typeof(ExceptionsMiddleware));
app.MapControllers();

try
{
    Log.Information("Application starting...");

    app.Run();
}
catch (Exception ex)
{
    Log.Error("Application finished with error {error}", ex);
}
finally
{
    Log.Information("Application stopped");
    Log.CloseAndFlush();
}
