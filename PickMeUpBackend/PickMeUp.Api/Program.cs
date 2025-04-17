using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Yarp.ReverseProxy;

var builder = WebApplication.CreateBuilder(args);

// Enable Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Reverse Proxy from appsettings.json
builder.Services.AddReverseProxy()
	.LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

// Allow CORS from any origin
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


app.UseSwagger();
app.UseSwaggerUI(options =>
{
	options.SwaggerEndpoint("http://pickmeup-user-api:8080/swagger/v1/swagger.json", "PickMeUp.User.API");
	options.SwaggerEndpoint("http://pickmeup-auth-api:8080/swagger/v1/swagger.json", "PickMeUp.Auth.API");
	options.SwaggerEndpoint("http://pickmeup-driver-api:8080/swagger/v1/swagger.json", "PickMeUp.Driver.API");
	options.SwaggerEndpoint("http://pickmeup-ride-api:8080/swagger/v1/swagger.json", "PickMeUp.Ride.API");
	options.SwaggerEndpoint("http://pickmeup-payment-api:8080/swagger/v1/swagger.json", "PickMeUp.Payment.API");
	options.SwaggerEndpoint("http://pickmeup-rating-api:8080/swagger/v1/swagger.json", "PickMeUp.Rating.API");
	options.SwaggerEndpoint("http://pickmeup-notification-api:8080/swagger/v1/swagger.json", "PickMeUp.Notification.API");

	options.RoutePrefix = string.Empty;
});


app.UseHttpsRedirection();

app.MapReverseProxy();

app.Run();
