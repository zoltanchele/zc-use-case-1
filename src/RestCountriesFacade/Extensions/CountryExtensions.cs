﻿using RestCountriesFacade.Constants;
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

		public static IEnumerable<Country> FilterByMaxPopulation(this IEnumerable<Country> countries, int? maxPopulationMillions)
		{
			if (maxPopulationMillions == null) 
				return countries;

			return countries.Where(e => e.Population < maxPopulationMillions * 1000000);
		}

		public static IEnumerable<Country> SortByCommonName(this IEnumerable<Country> countries, string? sortDirection)
		{
			if(sortDirection == null)
				return countries;

			if(sortDirection == SortDirection.Ascend)
				return countries.OrderBy(e => e.Name?.Common);
			if(sortDirection == SortDirection.Descend)
				return countries.OrderByDescending(e => e.Name?.Common);

			return countries;
		}
	}
}
