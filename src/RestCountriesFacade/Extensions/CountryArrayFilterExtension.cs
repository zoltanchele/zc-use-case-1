using RestCountriesFacade.Models;

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
	}
}
