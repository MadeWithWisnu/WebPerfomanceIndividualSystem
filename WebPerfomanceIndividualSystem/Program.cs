using PerformanceIndividualDataAccess;
using WebPerfomanceIndividualSystem.Configurations;

var builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;

// Add services to the container.
builder.Services.AddControllersWithViews();
services.AddBusinessService();
Dependencies.ConfigureService(builder.Configuration, builder.Services);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Dashboard/Index");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}");

app.Run();
