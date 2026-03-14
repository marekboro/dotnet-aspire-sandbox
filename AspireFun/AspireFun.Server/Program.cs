using AspireFun.Server.Extensions;
using AspireFun.Server.Infrastructure;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyLocalDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IMyRepository, MyRepository>();
builder.Services.AddTransient<ISeeder, Seeder>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMySwaggerGen();

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add CORS for local dev.
const string corsPolicyName = "local";
var corsPolicy = new CorsPolicyBuilder().AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin().Build();
builder.Services.AddCors(options => options.AddPolicy(corsPolicyName, corsPolicy));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    Console.WriteLine("- --> --> |---------| <-- <-- -");
    Console.WriteLine("= == ===> DEVELOPMENT <=== == =");
    Console.WriteLine("- --> --> |---------| <-- <-- -");
    
    app.MapOpenApi();
    app.UseSwagger();
    // TODO: add outh.
    // app.MapSwagger().RequireAuthorization();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.MapControllers();

app.UseHttpsRedirection();
app.MapDefaultEndpoints();

app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseCors(corsPolicyName);
}

app.UseFileServer();

var seeder = app.Services.GetRequiredService<ISeeder>();
await seeder.Seed();

app.Run();

