using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AgroSmart.Core.Application;
using AgroSmart.Infraestructure.Identity;
using AgroSmart.Infraestructure.Identity.Entities;
using AgroSmart.Infraestructure.Identity.Seeds;
using AgroSmart.Infraestructure.Shared;
using AgroSmart.WebApi.Extensions;
using AgroSmart.Infraestructure.Persistence;
using AgroSmart.Infraestructure.Persistence.Context;
using AgroSmart.Infraestructure.Persistence.Seeds;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ProducesAttribute("application/json"));
}).ConfigureApiBehaviorOptions(options =>
{
    options.SuppressInferBindingSourcesForParameters = true;
    options.SuppressMapClientErrors = true;
});

// Configuración de sesión
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddSharedInfrastructure(builder.Configuration); // Registro de EmailService
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddIdentityInfrastructureForApi(builder.Configuration);
builder.Services.AddApplicationLayer();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
builder.Services.AddSwaggerExtension();
builder.Services.AddApiVersioningExtension();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.ConfigureService(builder.Configuration);


var app = builder.Build();

// Inicialización de usuarios y roles por defecto
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        var context = services.GetRequiredService<ApplicationContext>();

        await DefaultRoles.SeedAsync(userManager, rolesManager);
        await DefaultAdminUser.SeedAsync(userManager, rolesManager);
        await DefaultClientUser.SeedAsync(userManager, rolesManager);
        await DefaultCategories.SeedAsync(context);
    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex, "Error al inicializar roles o usuarios por defecto");
        throw;
    }
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseSession();  // Mueve esto antes de UseAuthorization
app.UseAuthorization();

app.UseSwaggerExtension();
app.UseErrorHandlingMiddleware(); // Asegúrate de que esté implementado
app.UseHealthChecks("/health");
/*app.UseSession();*/

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();