using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PickMeUp.User.Repository;
using PickMeUp.User.Repository.Implementations;
using PickMeUp.User.Repository.Interfaces;
using PickMeUp.User.Service.Implementations;
using PickMeUp.User.Service.Interfaces;
using System.Reflection;
using AutoMapper;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Register DbContext with connection string
builder.Services.AddDbContext<UserDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Repositories and Services
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

// AutoMapper — scans current assembly for profiles
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{
		options.RequireHttpsMetadata = false;
		options.SaveToken = true;
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = false,
			ValidateAudience = false,
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(
				Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Secret"]!))
		};
	});


// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new() { Title = "PickMeUp.User.API", Version = "v1" });
	c.AddServer(new Microsoft.OpenApi.Models.OpenApiServer
	{
		Url = "http://pickmeup-user-api:8080" // Match what you proxy through
	});
});

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAll", policy =>
	{
		policy.AllowAnyOrigin()
			  .AllowAnyMethod()
			  .AllowAnyHeader();
	});
});


var app = builder.Build();

app.Use(async (context, next) =>
{
	if (context.Request.Path.StartsWithSegments("/swagger"))
	{
		context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
		context.Response.Headers.Add("Access-Control-Allow-Headers", "*");
		context.Response.Headers.Add("Access-Control-Allow-Methods", "*");
	}

	await next();
});

app.UseCors("AllowAll");

// Use Swagger in all environments
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
	var db = scope.ServiceProvider.GetRequiredService<UserDbContext>();
	db.Database.Migrate(); // or db.Database.EnsureCreated(); for code-first without migrations
}

app.Run();
