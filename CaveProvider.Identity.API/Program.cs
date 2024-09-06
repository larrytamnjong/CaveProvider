
using Microsoft.EntityFrameworkCore;
using CaveProvider.Identity.API;
using Microsoft.OpenApi.Models;
using CaveProvider.Identity.API.Database.Context;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using System;
using CaveProvider.Identity.API.Models;
using CaveProvider.Identity.API.Database.Context.Interface;
using AutoMapper;
using CaveProvider.Identity.API.Dto;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using CaveProvider.Identity.API.Helpers;
using CaveProvider.Core.Helpers.Enums;
using CaveProvider.Core.Helpers.Utils;
using CaveProvider.Identity.API.Interface;
using CaveProvider.Identity.API.Repository;
using CaveProvider.API.ExceptionHandler;





var builder = WebApplication.CreateBuilder(args); 

var jwtSettings = new JwtSettings();
builder.Configuration.Bind(JwtSettings.SectionName, jwtSettings);
builder.Services.AddSingleton(Options.Create(jwtSettings));


builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddCors(options =>
{
    options.AddPolicy("default", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
#region Exception Handlers

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
#endregion

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
});

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();


DataBaseProvider databaseProvider = DatabaseProviderUtil.Set(SettingsManager.AppSetting["Provider"]);

if (databaseProvider == DataBaseProvider.SqlServer)
{
    builder.Services.AddDbContext<ApplicationDbContext, SqlServerDbContext>();
    builder.Services.AddScoped<IApplicationDbContext, SqlServerDbContext>();

}
else if (databaseProvider == DataBaseProvider.Postgres)
{
    builder.Services.AddDbContext<ApplicationDbContext, PostgresDbContext>();
    builder.Services.AddScoped<IApplicationDbContext, PostgresDbContext>();

}


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(
    options => options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret!))
    });


builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("V1", new OpenApiInfo
    {
        Version = "v1",
        Title = "CaveProvider Identity API",
        Description = "Identity Server for the CaveProvider Application"
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                }
            },
            new List < string > ()
        }
    });
});



builder.Services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ClaimsPrincipalFactory>();
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();

var app = builder.Build();



using (var serviceScope = app.Services.CreateScope())
{
    var databaseContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    databaseContext.Database.Migrate();
}

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint("/swagger/V1/swagger.json", "Product CaveProvider");
    });
}

app.UseCors("default");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
