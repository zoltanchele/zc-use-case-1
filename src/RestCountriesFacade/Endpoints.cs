using RestCountriesFacade.Clients;

namespace RestCountriesFacade
{
	public static class Endpoints
	{
		public static void MapEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapGet("/retrieve", async ( 
				string? filter, 
				int? population, 
				string? sort, 
				int? take,
				RestCountriesClient client) =>
			{
				var countries = await client.GetAll();
				return countries;
			})
			.WithName("Retrieve");
		}
	}
}
