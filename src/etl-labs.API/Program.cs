using etl_labs.API;
using etl_labs.API.Scrapings;

using Hangfire;
using Hangfire.MemoryStorage;

using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<TopFiveMusicService>();
builder.Services.AddSingleton<ToFiveMusicsYoutubeScraping>();
builder.Services.AddSwaggerGen();

// Inicio da configuração no service - HANGFIRE
builder.Services.AddHangfire(config => config.UseMemoryStorage());

builder.Services.AddHangfireServer();
builder.Services.AddHostedService<TopFiveMusicService>();
// Fim da Configuração no service - HANGFIRE

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
// Inicio da configuração no APP - HANGFIRE
//app.UseHangfireServer();

app.UseHangfireDashboard("/hangfire", new DashboardOptions()
{
    AppPath = null,
    DashboardTitle = "Hangfire Dashboard Sample teste"
});
// Fim da configuração no App - HANGFIRE

app.UseAuthorization();

app.MapControllers();

app.Run();
