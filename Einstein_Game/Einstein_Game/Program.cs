using NLog;
using NLog.Web;


var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("Aplicación arrancada..");

try
{
    var builder = WebApplication.CreateBuilder(args);
    var Origins = "_Origins";

    // Add services to the container.
    
    builder.Services.AddControllers();

    builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: Origins,
                          builder =>
                          {
                              builder.WithOrigins("http://localhost:4200")
                                     .AllowAnyHeader()
                                     .AllowAnyMethod();
                          });
    });

    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    app.UseCors(Origins);

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "Error fatal..");
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}


