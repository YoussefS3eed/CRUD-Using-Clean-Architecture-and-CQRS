using API.Exceptions;
using Application.Common;
using Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddControllers();

// ======== Infrastructure Services ========
builder.Services.AddInfrastructureServices(builder.Configuration);

// ======== Application Services ========
builder.Services.AddApplictionServices();


var app = builder.Build();

app.UseExceptionHandler();

app.MapControllers();

app.Run();
