using API.Exceptions;
using Application.Extensions;
using Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddControllers();

// ======== Infrastructure Services ========
builder.Services.AddInfrastructure(builder.Configuration);

// ======== Application Services ========
builder.Services.AddAppliction();


var app = builder.Build();

app.UseExceptionHandler();

app.MapControllers();

app.Run();
