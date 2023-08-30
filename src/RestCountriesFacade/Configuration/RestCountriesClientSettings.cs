namespace RestCountriesFacade.Configuration
{
	public class RestCountriesClientSettings
	{
		public const string ConfigurationSection = "RestCountriesClientSettings";
		public string? BaseAddress { get; set; }
		public int RequestTimeoutSec { get; set; }
	}
}
