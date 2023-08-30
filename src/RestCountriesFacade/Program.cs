using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.Options;
using RestCountriesFacade.Clients;
using RestCountriesFacade.Configuration;
using System.Text.Json.Serialization;

namespace RestCountriesFacade
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddAuthorization();

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddOptions<RestCountriesClientSettings>()
				.BindConfiguration(RestCountriesClientSettings.ConfigurationSection)
				.ValidateDataAnnotations()
				.ValidateOnStart();

			builder.Services.Configure<JsonOptions>(options =>
			{
				options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
			});
			
			builder.Services.AddHttpClient<RestCountriesClient>((serviceProvider, httpClient) =>
			{
				var inventoryOptions = serviceProvider.GetRequiredService<IOptions<RestCountriesClientSettings>>().Value;
				httpClient.BaseAddress = new Uri(inventoryOptions?.BaseAddress ?? string.Empty);
				httpClient.Timeout = TimeSpan.FromSeconds(inventoryOptions?.RequestTimeoutSec ?? 5);
			});

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapEndpoints();

			app.Run();
		}
	}
}