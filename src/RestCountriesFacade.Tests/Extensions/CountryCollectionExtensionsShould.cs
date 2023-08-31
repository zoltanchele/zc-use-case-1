using RestCountriesFacade.Constants;
using RestCountriesFacade.Extensions;
using RestCountriesFacade.Models;

namespace RestCountriesFacade.Tests.Extensions
{
	public class CountryCollectionExtensionsShould
	{
		private readonly Country[] _countries;

		public CountryCollectionExtensionsShould()
		{
			_countries = new[]
			{
				new Country{ Name = new CountryName { Common = "Albania" }, Population = 2837743 },
				new Country{ Name = new CountryName { Common = "Bangladesh" }, Population = 164689383 },
				new Country{ Name = new CountryName { Common = "Ivory Coast" }, Population = 26378275 },
				new Country{ Name = new CountryName { Common = "Croatia" }, Population = 4047200 },
				new Country{ Name = new CountryName { Common = "Estonia" }, Population = 1331057 }
			};
		}

		[Fact]
		public void FilterByCommonNameCaseInsensitively()
		{
			// arrange
			var filterExpression = "sT";
			var firstCountry = "Ivory Coast";
			var secondCountry = "Estonia";
			var expectedLength = 2;

			// act
			var result = _countries.FilterByCommonName(filterExpression);

			// assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Equal(expectedLength, result.Count());
			Assert.True(result.ElementAt(0).Name?.Common == firstCountry);
			Assert.True(result.ElementAt(1).Name?.Common == secondCountry);
		}

		[Fact]
		public void FilterByCommonNameAndReturnEmptyCollectionIfNotFound()
		{
			// arrange
			var filterExpression = "bin";

			// act
			var result = _countries.FilterByCommonName(filterExpression);

			// assert
			Assert.NotNull(result);
			Assert.Empty(result);
		}

		[Fact]
		public void FilterByCommonNameAndReturnAllIfFilterExpressionIsNull()
		{
			// arrange
			var expectedLength = _countries.Length;

			// act
			var result = _countries.FilterByCommonName(null);

			// assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Equal(expectedLength, result.Count());
		}

		[Fact]
		public void FilterByPopulation()
		{
			// arrange
			var expectedLength = 1;
			var millionPeople = 2;
			var expectedName = "Estonia";

			// act
			var result = _countries.FilterByMaxPopulation(millionPeople);

			// assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Equal(expectedLength, result.Count());
			Assert.True(result.ElementAt(0).Name?.Common == expectedName);
		}

		[Fact]
		public void FilterByPopulationAndReturnAllIfCriteriaIsNull()
		{
			// arrange
			var expectedLength = _countries.Length;

			// act
			var result = _countries.FilterByMaxPopulation(null);

			// assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Equal(expectedLength, result.Count());
		}

		[Fact]
		public void SortAscending()
		{
			// arrange
			var expectedLength = _countries.Length;
			var firstCountry = "Albania";
			var thirdCountry = "Croatia";
			var lastCountry = "Ivory Coast";

			// act
			var result = _countries.SortByCommonName(SortDirection.Ascend);

			// assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Equal(expectedLength, result.Count());
			Assert.True(result.ElementAt(0).Name?.Common == firstCountry);
			Assert.True(result.ElementAt(2).Name?.Common == thirdCountry);
			Assert.True(result.ElementAt(expectedLength - 1).Name?.Common == lastCountry);
		}

		[Fact]
		public void SortDescending()
		{
			// arrange
			var expectedLength = _countries.Length;
			var firstCountry = "Ivory Coast";
			var thirdCountry = "Croatia";
			var lastCountry = "Albania";

			// act
			var result = _countries.SortByCommonName(SortDirection.Descend);

			// assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Equal(expectedLength, result.Count());
			Assert.True(result.ElementAt(0).Name?.Common == firstCountry);
			Assert.True(result.ElementAt(2).Name?.Common == thirdCountry);
			Assert.True(result.ElementAt(expectedLength - 1).Name?.Common == lastCountry);
		}

		[Fact]
		public void NotSortWhenSortExpressionIsInvalid()
		{
			// arrange
			var expectedLength = _countries.Length;
			var firstCountry = "Albania";
			var thirdCountry = "Ivory Coast";
			var lastCountry = "Estonia";

			// act
			var result = _countries.SortByCommonName("Anything");

			// assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Equal(expectedLength, result.Count());
			Assert.True(result.ElementAt(0).Name?.Common == firstCountry);
			Assert.True(result.ElementAt(2).Name?.Common == thirdCountry);
			Assert.True(result.ElementAt(expectedLength - 1).Name?.Common == lastCountry);
		}

		[Fact]
		public void NotSortWhenSortExpressionIsNull()
		{
			// arrange
			var expectedLength = _countries.Length;
			var firstCountry = "Albania";
			var thirdCountry = "Ivory Coast";
			var lastCountry = "Estonia";

			// act
			var result = _countries.SortByCommonName(null);

			// assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Equal(expectedLength, result.Count());
			Assert.True(result.ElementAt(0).Name?.Common == firstCountry);
			Assert.True(result.ElementAt(2).Name?.Common == thirdCountry);
			Assert.True(result.ElementAt(expectedLength - 1).Name?.Common == lastCountry);
		}

		[Fact]
		public void LimitResultLength()
		{
			// arrange
			var expectedLength = _countries.Length - 2;
			var firstCountry = "Albania";
			var lastCountry = "Ivory Coast";

			// act
			var result = _countries.TakeFirst(expectedLength);

			// assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Equal(expectedLength, result.Count());
			Assert.True(result.ElementAt(0).Name?.Common == firstCountry);
			Assert.True(result.ElementAt(expectedLength - 1).Name?.Common == lastCountry);
		}

		[Fact]
		public void NotLimitResultLengthIfDesiredLengthIsLonger()
		{
			// arrange
			var expectedLength = _countries.Length;
			var desiredLength = expectedLength + 5;
			var firstCountry = "Albania";
			var lastCountry = "Estonia";

			// act
			var result = _countries.TakeFirst(desiredLength);

			// assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Equal(expectedLength, result.Count());
			Assert.True(result.ElementAt(0).Name?.Common == firstCountry);
			Assert.True(result.ElementAt(expectedLength - 1).Name?.Common == lastCountry);
		}

		[Fact]
		public void NotLimitResultLengthIfDesiredLengthIsNull()
		{
			// arrange
			var expectedLength = _countries.Length;
			var firstCountry = "Albania";
			var lastCountry = "Estonia";

			// act
			var result = _countries.TakeFirst(null);

			// assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Equal(expectedLength, result.Count());
			Assert.True(result.ElementAt(0).Name?.Common == firstCountry);
			Assert.True(result.ElementAt(expectedLength - 1).Name?.Common == lastCountry);
		}
	}
}