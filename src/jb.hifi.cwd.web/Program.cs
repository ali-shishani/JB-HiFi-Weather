using AspNetCoreRateLimit;
using jb.hifi.core.Interfaces;
using jb.hifi.core.Models;
using jb.hifi.cwd.web.Config;
using jb.hifi.cwd.web.Extensions;
using jb.hifi.service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

// initialise ApiSettings
builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));

// Register interface and classes
builder.Services.AddTransient<ICurrentWeatherDataService, CurrentWeatherDataService>();
builder.Services.AddTransient<IOpenWeatherClient, OpenWeatherClient>();

// AspNetCoreRateLimit
builder.Services.AddRateLimiting(builder.Configuration);

// Auto Mapp
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// swagger
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Use Rate Limiting
app.UseRateLimiting();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// This middleware serves generated Swagger document as a JSON endpoint
app.UseSwagger();

// This middleware serves the Swagger documentation UI
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Current Weather Data - API V1");
});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
