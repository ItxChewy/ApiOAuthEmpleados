using ApiOAuthEmpleados.Context;
using ApiOAuthEmpleados.Helpers;
using ApiOAuthEmpleados.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

HelperActionServicesOAuth helper =
    new HelperActionServicesOAuth(builder.Configuration);

builder.Services.AddSingleton<HelperActionServicesOAuth>(helper);
builder.Services.AddAuthentication(helper.GetAuthenticateSchema())
    .AddJwtBearer(helper.GetJwtBearerOptions());

HelperCryptography.Initialize(builder.Configuration);
builder.Services.AddHttpContextAccessor();

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("Sql");
builder.Services.AddTransient<RepositoryHospital>();
builder.Services.AddDbContext<HospitalContext>
    (options => options.UseSqlServer(connectionString));
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}
app.MapOpenApi();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseSwaggerUI(options => {

    options.SwaggerEndpoint("/openapi/v1.json", "Primera Api con Seguridad");
    options.RoutePrefix = "";
});

app.MapControllers();

app.Run();
