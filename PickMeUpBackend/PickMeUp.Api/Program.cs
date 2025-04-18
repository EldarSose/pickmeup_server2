using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Yarp.ReverseProxy;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddReverseProxy()
	.LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

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
app.UseSwaggerUI(options =>
{
	options.SwaggerEndpoint("/user/swagger/v1/swagger.json", "PickMeUp.User.API");
	options.SwaggerEndpoint("/auth/swagger/v1/swagger.json", "PickMeUp.Auth.API");
	options.SwaggerEndpoint("/driver/swagger/v1/swagger.json", "PickMeUp.Driver.API");
	options.SwaggerEndpoint("/ride/swagger/v1/swagger.json", "PickMeUp.Ride.API");
	options.SwaggerEndpoint("/payment/swagger/v1/swagger.json", "PickMeUp.Payment.API");
	options.SwaggerEndpoint("/rating/swagger/v1/swagger.json", "PickMeUp.Rating.API");
	options.SwaggerEndpoint("/notification/swagger/v1/swagger.json", "PickMeUp.Notification.API");
	options.RoutePrefix = string.Empty;
});

app.MapReverseProxy();

app.Run();
