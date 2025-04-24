using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PickMeUp.User.Repository;
using PickMeUp.User.Repository.Implementations;
using PickMeUp.User.Repository.Interfaces;
using PickMeUp.User.Service.Implementations;
using PickMeUp.User.Service.Interfaces;
using System.Text;
using Microsoft.OpenApi.Models;
using PickMeUp.Auth.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<UserDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
	sql => sql.MigrationsAssembly("PickMeUp.User.Repository")));
builder.Services.AddDbContext<AuthDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
	sql => sql.MigrationsAssembly("PickMeUp.Auth.Repository")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserAddressRepository, UserAddressRepository>();
builder.Services.AddScoped<IUserSessionRepository, UserSessionRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserAddressService, UserAddressService>();
builder.Services.AddScoped<IUserSessionService, UserSessionService>();
builder.Services.AddScoped<AuthDbContext>();

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

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "PickMeUp.User.API", Version = "v1" });
	c.AddServer(new OpenApiServer
	{
		Url = "/user"
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

app.UseCors("AllowAll");
app.UseSwagger();
app.UseSwaggerUI(c =>
{
	c.SwaggerEndpoint("/swagger/v1/swagger.json", "PickMeUp.User.API v1");
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
	var retryCount = 0;
	var maxRetries = 10;
	var delay = TimeSpan.FromSeconds(5);

	while (retryCount < maxRetries)
	{
		try
		{
			var db = scope.ServiceProvider.GetRequiredService<UserDbContext>();
			db.Database.Migrate();
			break;
		}
		catch (Exception ex)
		{
			retryCount++;
			if (retryCount >= maxRetries) throw;
			Thread.Sleep(delay);
		}
	}
}


app.Run();
