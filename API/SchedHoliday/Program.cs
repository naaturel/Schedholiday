using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchedHoliday.Repo;
using SchedHoliday.Repo.User;
using SchedHoliday.Helpers;
using SchedHoliday.Services;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SchedHoliday.Repo.Activity;
using SchedHoliday.Infra;
using SchedHoliday.Repo.Holiday;
using SchedHoliday.Repo.Message;
using SchedHoliday.Repo.UserHoliday;
using SchedHoliday.Repo.Auth;
using SchedHoliday.Repo.Meteo;

var builder = WebApplication.CreateBuilder(args);
{
    var services = builder.Services;

    services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(o =>
    {
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true
        };
    });

    services.AddAuthorization();

    services.AddControllers();

    services.AddSignalR();

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(opt =>
    {
        opt.SwaggerDoc("v1", new OpenApiInfo() { Title = "MyAPI", Version = "v1" });
        opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });

        opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
    });

  
    services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
    services.Configure<AppSettings>(builder.Configuration.GetSection("DevConnectionString"));

    services.AddIdentityCore<DTOUser>(options =>
    {
        var lockoutOptions = new LockoutOptions()
        {
            AllowedForNewUsers = true,
            DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5),
            MaxFailedAccessAttempts = 5
        };
        options.Lockout = lockoutOptions;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<_DbContext>()
    .AddSignInManager<SignInManager<DTOUser>>();

    services.AddAuthentication("Identity.Application")
    .AddCookie("Identity.Application", options =>
    {
        // Configure cookie options if needed
    });

    services.AddScoped<IUserService, UserService>();
    services.AddScoped<IMailService, MailService>();
    services.AddScoped<IHolidayService, HolidayService>();
    services.AddScoped<IMessageService, MessageService>();
    services.AddScoped<IMeteoService, MeteoService>();
    services.AddScoped<IActivityService, ActivityService>();
    services.AddScoped<IAuthenticationService, AuthenticationService>();
    services.AddScoped<IUserHolidayService, UserHolidayService>();

    services.AddScoped<IAuthInfra, AuthInfra>();
    services.AddScoped<IUserInfra, UserInfra>();
    services.AddScoped<IHolidayInfra, HolidayInfra>();
    services.AddScoped<IMessageInfra, MessageInfra>();
    services.AddScoped<IMeteoInfra, MeteoInfra>();
    services.AddScoped<IActivtyInfra, ActivityInfra>();
    services.AddScoped<IUserHolidayInfra, UserHolidayInfra>();




    if (builder.Environment.IsDevelopment())
    {
        services.Configure<AppSettings>(builder.Configuration.GetSection("DevConnectionString"));
        services.AddDbContext<_DbContext>(options =>
                    options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SchedHoliday;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));

    }
    else
    {
        services.Configure<AppSettings>(builder.Configuration.GetSection("DevConnectionString"));
        services.AddDbContext<_DbContext>(options =>
                    options.UseSqlServer("Data Source=192.168.132.200,11433;Initial Catalog=Q210044;User ID=Q210044;Password=0044;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));
    }

}

var app = builder.Build();
{
    using (var scope = app.Services.CreateScope())
    {
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<DTOUser>>();
        await DataInitializer.Seed(userManager);
    }

    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors(c => c.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

    if (app.Environment.IsDevelopment())
    {
    };
}

app.Run();
