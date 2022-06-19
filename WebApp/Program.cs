using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using InfluxDB.Client;
using ServiceLayer.Dto;
using ServiceLayer;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();

builder.Services.AddTransient<InfluxDBClientOptions.Builder>(b => new InfluxDBClientOptions.Builder()
                                                             .Url(builder.Configuration.GetValue<string>("influx:url"))
                                                             .AuthenticateToken(builder.Configuration.GetValue<string>("influx:token"))
                                                            );

builder.Services.AddTransient<IMeasurementService<Temprature>, MeasurementService<Temprature>>(s => new MeasurementService<Temprature>(s.GetRequiredService<InfluxDBClientOptions.Builder>(), builder.Configuration.GetValue<string>("influx:org"), builder.Configuration.GetValue<string>("influx:bucket")));
builder.Services.AddTransient<IMeasurementService<Humidity>, MeasurementService<Humidity>>(s => new MeasurementService<Humidity>(s.GetRequiredService<InfluxDBClientOptions.Builder>(), builder.Configuration.GetValue<string>("influx:org"), builder.Configuration.GetValue<string>("influx:bucket")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
