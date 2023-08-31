using RestCountriesFacade.Clients;
using RestCountriesFacade.Extensions;

namespace RestCountriesFacade
{
	public static class Endpoints
	{
		public static void MapEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapGet("/retrieve", async ( 
				string? filter, 
				int? populationMillions, 
				string? sort, 
				int? take,
				RestCountriesClient client) =>
			{
				var countries = await client.GetAll();
				return countries?
					.FilterByCommonName(filter)
					.FilterByMaxPopulation(populationMillions)
					.SortByCommonName(sort)
					.TakeFirst(take);
			})
			.WithName("Retrieve");
		}
	}
}
