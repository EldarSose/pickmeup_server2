using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using PickMeUp.Auth.Repository;
using PickMeUp.Auth.Repository.Implementations;
using PickMeUp.Auth.Repository.Interfaces;
using PickMeUp.Auth.Service.Implementations;
using PickMeUp.Auth.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AuthDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
	sql => sql.MigrationsAssembly("PickMeUp.Auth.Repository")));



builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// REPOSITORIES
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
builder.Services.AddScoped<IAuthTokenRepository, AuthTokenRepository>();

// SERVICES
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<IAuthTokenService, AuthTokenService>();

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
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "PickMeUp.Auth.API", Version = "v1" });
	c.AddServer(new OpenApiServer
	{
		Url = "/auth"
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
	c.SwaggerEndpoint("/swagger/v1/swagger.json", "PickMeUp.Auth.API v1");
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
			var db = scope.ServiceProvider.GetRequiredService<AuthDbContext>();
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
