using AspireFun.Server.Infrastructure;
using AspireFun.Server.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyLocalDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
    app.MapOpenApi();
}

// TODO: add a controller to get data from the local DB and replace this setup with 
// api.MapControllers();
var api = app.MapGroup("/api");
api.MapGet("get-test-one", TestResponse.CreateTestResponse).WithName("GetTestOne");
api.MapGet("get-test-two", TestResponse.CreateTestResponse).WithName("GetTestTwo");

app.UseHttpsRedirection();
app.MapDefaultEndpoints();

app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseCors(corsPolicyName);
}

app.UseFileServer();
app.Run();