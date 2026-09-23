using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;
using PropertyManagementProject.Clasess.Permission;
using PropertyManagementProject.Data;
using PropertyManagementProject.Middlewares;
using PropertyManagementProject.Services.Block;
using PropertyManagementProject.Services.BoardMembers;
using PropertyManagementProject.Services.OfficialExperts;
using PropertyManagementProject.Services.Plot;
using PropertyManagementProject.Services.Token;
using PropertyManagementProject.Services.TownShip;
using PropertyManagementProject.Services.Users;
using System.Reflection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


#region ConnectionString
string connectionString = builder.Configuration.GetConnectionString("PropertyManagement")
    ?? throw new InvalidOperationException("ConnectionString Is Not Exists.");

DbConnectionFactory.Initialize(connectionString);
#endregion

#region Configuration

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

#endregion

#region Authentication

builder.Services
    .AddAuthentication("CustomToken")
    .AddScheme<AuthenticationSchemeOptions, CustomTokenHandler>("CustomToken", null);

#endregion

#region Authorization

builder.Services.AddAuthorization();


builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:85")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

#endregion

#region Controllers

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });

builder.Services.AddEndpointsApiExplorer();

#endregion

#region Swagger

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition
    (
        "Bearer",
        new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            In = ParameterLocation.Header,
            Description = "Enter Custom Token"
        }
    );

    options.AddSecurityDefinition
    (
        "ApiKey",
        new OpenApiSecurityScheme
        {
            Name = "ApiKey",
            Type = SecuritySchemeType.ApiKey,
            In = ParameterLocation.Header,
            Description = "Enter ApiKey"
        }
    );

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        },
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                }
            },
            Array.Empty<string>()
        }
    });

    foreach (string xmlFile in Directory.GetFiles(AppContext.BaseDirectory, "*.xml"))
        options.IncludeXmlComments(xmlFile);

});

#endregion

#region Dependency Injection

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUsersService, UserServices>();
builder.Services.AddScoped<ITownShipServices, TownShipService>();
builder.Services.AddScoped<IBlockServices, BlockService>();
builder.Services.AddScoped<IPlotServices, PlotServices>();
builder.Services.AddScoped<IOfficialExperts, OfficialExpertsServices>();
builder.Services.AddScoped<IBoardMembers, BoardMembersServices>();
builder.Services.AddScoped<PasswordService>();

#endregion

WebApplication app = builder.Build();

#region Pipeline

//TODO: در لحظه نهایی برداشته شود.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.EnablePersistAuthorization();
        //c.DefaultModelsExpandDepth(-1);
    });
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ApiKeyMiddleware>();

app.MapControllers();

#endregion

app.Run();