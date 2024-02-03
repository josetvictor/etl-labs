using System.Net.Mime;
using System.Text.Json;

using etl_labs.API.Domain.Interfaces;
using etl_labs.API.Integration;
using etl_labs.API.Integration.Interfaces;
using etl_labs.API.Jobs;
using etl_labs.API.Queue;
using etl_labs.API.Scrapings;

using Hangfire;
using Hangfire.MemoryStorage;

using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHealthChecks();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<ToFiveMusicsYoutubeScraping>();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll",
            builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
    });

// Inicio da configuração no service - HANGFIRE
builder.Services.AddHangfire(config => config.UseMemoryStorage());
// Fim da Configuração no service - HANGFIRE

// Configuração da injeção de dependencia de Jobs, Queues e Integrations
builder.Services.AddScoped<ITopFiveIntegration, TopFiveIntegration>();
builder.Services.AddScoped<ITopFiveQueue, TopFiveQueue>();
builder.Services.AddScoped<IJobTopFive, FiveJob>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseHealthChecks("/", new HealthCheckOptions()
    {
        ResponseWriter = async (context, report) =>
        {
            var result = JsonSerializer.Serialize(new
            {
                currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                statusApplication = report.Status.ToString(),
            });

            context.Response.ContentType = MediaTypeNames.Application.Json;
            await context.Response.WriteAsync(result);
        }
    });

    // Inicio da configuração no APP - HANGFIRE
    app.UseHangfireServer();

    app.UseHangfireDashboard("/hangfire", new DashboardOptions()
    {
        AppPath = null,
        DashboardTitle = "Hangfire Dashboard Sample teste"
    });
    // Fim da configuração no App - HANGFIRE
}

// Execução do Job - Inicio
var jobFive = builder.Services.BuildServiceProvider().GetService<IJobTopFive>();

RecurringJob.AddOrUpdate(() => jobFive.StartJob(), Cron.Daily, TimeZoneInfo.Utc);
// Execução do Job - Fim

// app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
