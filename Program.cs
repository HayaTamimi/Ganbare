using System.Text;
using System.Text.Json.Serialization;
using ganbare.src.Database;
using ganbare.src.Entity;
using ganbare.src.Middlewares;
using ganbare.src.Repository;
using ganbare.src.Services.leaderboard;
using ganbare.src.Services.question;
using ganbare.src.Services.quiz;
using ganbare.src.Services.result;
using ganbare.src.Services.user;
using ganbare.src.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Npgsql;
using static ganbare.src.Entity.Question;

var builder = WebApplication.CreateBuilder(args);

var dataSourceBuilder = new NpgsqlDataSourceBuilder(
builder.Configuration.GetConnectionString("Local")
);

builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

dataSourceBuilder.MapEnum<Role>();
dataSourceBuilder.MapEnum<QuestionLevel>();
dataSourceBuilder.MapEnum<QuizLevel>(); 



builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseNpgsql(dataSourceBuilder.Build());
    options.EnableSensitiveDataLogging();
});

builder.Services.AddScoped<ILeaderboardService, LeaderboardService>().AddScoped<LeaderboardRepository, LeaderboardRepository>();

builder.Services.AddScoped<IUserService, OptionService>().AddScoped<OptionRepository, OptionRepository>();

builder.Services.AddScoped<IQuestionService, QuestionService>().AddScoped<QuestionRepository, QuestionRepository>();

builder.Services.AddScoped<IQuizService, QuizService>().AddScoped<QuizRepository, QuizRepository>();

builder.Services.AddScoped<IResultService, ResultService>().AddScoped<ResultRepository, ResultRepository>();

builder.Services.AddScoped<IUserService, UserService>().AddScoped<UserRepository, UserRepository>();


builder
    .Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])
            ),
        };
    });

builder.Services.AddControllersWithViews().AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
    );

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

    try
    {
        if (dbContext.Database.CanConnect())
        {
            Console.WriteLine("Database is connected");
        }
        else
        {
            Console.WriteLine("Unable to connect to the database.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Database connection failed: {ex.Message}");
    }
}

app.UseMiddleware<LoggingMiddleware>();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();