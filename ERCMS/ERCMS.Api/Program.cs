using ERCMS.Api;
using ERCMS.Api.Exceptions;
using ERCMS.Api.Users;
using ERCMS.Application;
using ERCMS.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

var api = app
    .MapGroup("/api")
    .AddEndpointFilter<ExceptionEndpointFilter>();

UserEndpoints.Map(api);

app.Run();