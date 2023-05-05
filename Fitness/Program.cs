using Fitness.Data;
using Fitness.IService;
using Fitness.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<ITypeOfMembership, TypeOfMembershipService>();
builder.Services.AddScoped<IGymService, GymService>();
builder.Services.AddScoped<IClientsMembershipsService, ClientsMembershipsService>();
builder.Services.AddScoped<ICheckInService, CheckInService>();

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
