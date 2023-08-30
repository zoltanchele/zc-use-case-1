namespace RestCountriesFacade.Models
{
	public class Country
	{
		public CountryName? Name { get; set; }

		public string[]? Tld { get; set; }

		public string? Cca2 { get; set; }

		public string? Ccn3 { get; set; }

		public string? Cca3 { get; set; }

		public string? Cioc { get; set; }

		public bool? Independent { get; set; }

		public string? Status { get; set; }

		public bool? UnMember { get; set; }

		public Dictionary<string, Currency>? Currencies { get; set; }

		public Idd? Idd { get; set; }

		public string[]? Capital { get; set; }

		public string[]? AltSpellings { get; set; }

		public string? Region { get; set; }

		public string? Subregion { get; set; }

		public Dictionary<string, string>? Languages { get; set; }
		
		public Dictionary<string, LocalizedName>? Translations { get; set; }

		public decimal[]? LatLng { get; set; }

		public bool? LandLocked { get; set; }

		public string[]? Borders { get; set; }

		public decimal? Area { get; set; }

		public Dictionary<string, Demonym>? Demonyms { get; set; }

		public string? Flag { get; set; }

		public Dictionary<string, string>? Maps { get; set; }

		public int Population { get; set; }

		public Dictionary<string, decimal>? Gini { get; set; }

		public string? Fifa { get; set; }

		public Car? Car { get; set; }

		public string[]? Timezones { get; set; }

		public string[]? Continents { get; set; }

		public Dictionary<string, string>? Flags { get; set; }

		public Dictionary<string, string>? CoatOfArms { get; set; }

		public string? StartOfWeek { get; set; }

		public CapitalInfo? CapitalInfo { get; set; }

		public PostalCode? PostalCode { get; set; }
	}
}
