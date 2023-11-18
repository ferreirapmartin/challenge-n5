using ChallengeN5.Infr.DataAccess;
using ChallengeN5.Infr.AnalyticsStore;
using ChallengeN5.Application;
using ChallengeN5.Infr.EventStore;
using ChallengeN5.Infr.EventStore.Config;
using ChallengeN5.Infr.DataAccess.Core;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<EventStoreConfig>(builder.Configuration.GetSection(nameof(EventStoreConfig)));
builder.Services.AddInfrEventStore();
builder.Services.AddInfrAnalytics(builder.Configuration.GetValue<string>("ElasticSearchConfig:Uri"));
builder.Services.AddApplication();
builder.Services.AddInfrDataAccess();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true));

// FIXME: Las migraciones lo las debería manejar así, pero lo realizo para simplificar el startup de todos los servicios
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<DatabaseContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}

app.Run();
