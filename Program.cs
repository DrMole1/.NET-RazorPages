using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplicationRazor.Data;
using WebApplicationRazor.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Ajout du contexte en utilisant la connectionString présente dans appsettings.json
builder.Services.AddDbContext<WebApplicationRazorContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApplicationRazorContext") ?? throw new InvalidOperationException("Connection string 'WebApplicationRazorContext' not found.")));

var app = builder.Build();

// Ajout de données dans la db à l'initialisation
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

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

app.UseAuthorization();

// L'application fonctionnera avec le modèle RazorPages
app.MapRazorPages();

// Lance l'application
app.Run();
