using ERCMS.Api.Exceptions;
using ERCMS.Api.Users;
using ERCMS.Application;
using ERCMS.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var api = app
    .MapGroup("/api")
    .AddEndpointFilter<ExceptionEndpointFilter>();

UserEndpoints.Map(api);

app.Run();