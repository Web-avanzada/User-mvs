using System.Text;
using DataDataContext.DataContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ModelsUsers.Users;
using RepositoriesIAuthenticate.IAuthenticate;
using RepositoriesIAuthenticate.IGenericService;
using Service.SUserService;
using ServicesSAuthenticate.SAuthenticate;



var builder = WebApplication.CreateBuilder(args);

// Add controllers and Swagger services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Load configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json");

// Add and configure DbContext with SQL Server
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register services
builder.Services.AddScoped<IAuthenticate, SAuthenticate>();
builder.Services.AddScoped<IGenericService<User>,SUserService>();
builder.Services.AddScoped<IGenericService<UserProfile>,SUserProfile>();
builder.Services.AddScoped<IGenericService<UserSchedule>,SUserSchedule>();
builder.Services.AddScoped<IGenericService<Theme>,STheme>();
builder.Services.AddScoped<IGenericService<ThemeUser>,SThemeUser>();
builder.Services.AddScoped<IGenericService<Occupation>,SOccupation>();
builder.Services.AddScoped<IGenericService<OccupationUser>,SOccupationUser>();

// JWT configuration
string? secretkey = builder.Configuration.GetSection("settings").GetSection("secretkey").ToString();
var keyBytes = Encoding.UTF8.GetBytes(secretkey ?? "");

builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ValidateIssuer = true,
        ValidIssuer = "backend",
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

// CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("NewPolicy", app =>
    {
        app.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod();
    });
});

var app = builder.Build();

// Enable middleware for Swagger only in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable CORS
app.UseCors("NewPolicy");

// Enable authentication and routing
app.UseAuthentication();
app.UseAuthorization();
app.UseRouting();

// Map endpoints
app.MapControllers();

// Run the app
app.Run();
