namespace RestCountriesFacade.Models
{
	public class CountryName : LocalizedName
	{
		public Dictionary<string, LocalizedName>? NativeName { get; set; }
	}
}
