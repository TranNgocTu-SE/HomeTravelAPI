using HomeTravelAPI.Common;
using HomeTravelAPI.EF;
using HomeTravelAPI.Entities;
using HomeTravelAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//sql server
builder.Services.AddDbContext<HomeTravelDbContext>(opstion => opstion.UseSqlServer(builder.Configuration.GetConnectionString("hometravel"), builder =>
{
    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
}));

    builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Identity
builder.Services.AddIdentity<AppUser, AppRole>()
               .AddEntityFrameworkStores<HomeTravelDbContext>()
               .AddDefaultTokenProviders() ;

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings
    options.Password.RequireDigit = false;
    //options.Password.RequiredLength = 10;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    //options.Password.RequiredUniqueChars = 6;

    // Lockout settings
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
    options.Lockout.MaxFailedAccessAttempts = 10;
    options.Lockout.AllowedForNewUsers = true;

    // User settings
    options.User.RequireUniqueEmail = true;
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}
).AddJwtBearer(option =>
{
    option.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        RequireExpirationTime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration.GetSection("Token:Issuer").Value,
        ValidAudience = builder.Configuration.GetSection("Token:Audience").Value,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:Key"]))
    };
});

builder.Services.Configure<AzureOption>(builder.Configuration.GetSection("Azure"));
builder.Services.Configure<EmailOption>(builder.Configuration.GetSection("SendGridEmailSettings"));
builder.Services.AddTransient<IImageService, ImageService>();
builder.Services.AddTransient<IMailService, EmailSender>();
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IHomeStayService, HomeStayService>();
builder.Services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();
builder.Services.AddTransient<RoleManager<AppRole>, RoleManager<AppRole>>();
builder.Services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();
builder.Services.AddTransient<ILocationService, LocationService>();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5173/",
                                              "http://localhost:5173",
                                              "https://hometravel.azurewebsites.net/").AllowAnyHeader().AllowAnyMethod();
                      });
});

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
); ;
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "HomeTravel", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"Example: 'Bearer token'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                        },
                        new List<string>()
                      }
                    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("v1/swagger.json", "WeatherForecast API V1");
    });
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
