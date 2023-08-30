using RestCountriesFacade.Models;

namespace RestCountriesFacade.Clients
{
	public class RestCountriesClient
	{
		private readonly HttpClient _client;

		public RestCountriesClient(HttpClient client)
		{
			_client = client;
		}

		public async Task<Country[]?> GetAll()
		{
			var countries = await _client.GetFromJsonAsync<Country[]?>("/v3.1/all");
			return countries;
		}
	}
}
