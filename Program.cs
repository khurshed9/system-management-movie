using SystemManagementMovie.Common.Base.DI;
using SystemManagementMovie.Common.DataAccess;
using SystemManagementMovie.Common.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddServices();
builder.AddDbContext();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseExceptionHandler("/error");

app.MapControllers();

app.Run();
