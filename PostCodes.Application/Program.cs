using Microsoft.EntityFrameworkCore;
using PostCodes.Domain.Configurations;
using PostCodes.Domain.Interfaces;
using PostCodes.Domain.Services;
using PostCodes.Infrastructure.Context;
using PostCodes.Infrastructure.ExternalServices;
using PostCodes.Infrastructure.Repository;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PostCodes.Application.Test")]

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(
    x => x.UseSqlServer(builder.Configuration.GetConnectionString("connection"))
);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IPostCodeService, PostCodeService>();
builder.Services.AddScoped<IPostCodeRepository, PostCodeRepository>();
builder.Services.AddHttpClient<IPostCodeIoService, PostCodeIoService>();

builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();

public partial class Program { }; 
