using QomNewsBase.Api.Middlewares;
using QomNewsBase.Application;
using QomNewsBase.Application.Utilities;
using QomNewsBase.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

#region DI

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

#endregion

#region CORS

var allowedOrigins = builder.Configuration
    .GetSection("CorsSettings:AllowedOrigins")
    .Get<string[]>() ?? Array.Empty<string>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
        policy =>
        {
            if (allowedOrigins.Any())
            {
                policy.WithOrigins(allowedOrigins)
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            }

        });
});


#endregion

builder.Services.AddSwaggerGen();

var baseUrl = builder.Configuration["BaseUrl"];
var thumbnailPath = builder.Configuration["ThumbnailUploadsFolder"];

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("AllowSpecificOrigins");

}

PathBuilder.Initialize(baseUrl!, thumbnailPath!);

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionMiddleware>();

app.Run();
