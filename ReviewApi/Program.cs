using Microsoft.Extensions.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();

builder.Host.UseSerilog((hostContext, services, configuration) => {
    configuration.ReadFrom.Configuration(hostContext.Configuration);
    configuration.WriteTo.Console();
});

builder.Services.AddControllers();

builder.Services.AddBLLServices(builder.Configuration);
builder.Services.AddDALServices(builder.Configuration);

var app = builder.Build();

app.UseDefaultFiles();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
