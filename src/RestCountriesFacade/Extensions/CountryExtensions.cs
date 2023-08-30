using RestCountriesFacade.Models;
using System.Collections.Specialized;

namespace RestCountriesFacade.Extensions
{
	public static class CountryArrayFilterExtension
	{
		public static IEnumerable<Country> FilterByCommonName(this IEnumerable<Country> countries, string? filterExpression)
		{
			if (filterExpression == null)
				return countries;

			return countries.Where(e => e.Name?.Common?.Contains(filterExpression, StringComparison.OrdinalIgnoreCase) ?? false);
		}

		public static IEnumerable<Country> FilterByMaxPopulation(this IEnumerable<Country> countries, int? maxPopulationMillions)
		{
			if (maxPopulationMillions == null) 
				return countries;

			return countries.Where(e => e.Population < maxPopulationMillions * 1000000);
		}


	}
}
