using RestCountriesFacade.Constants;
using RestCountriesFacade.Extensions;
using RestCountriesFacade.Models;

namespace RestCountriesFacade.Tests.Extensions
{
	public class CountryCollectionExtensionsShould
	{
		[Fact]
		public void FilterByCommonNameCaseInsensitively()
		{
			// arrange
			var expectedLength = 2;
			var input = GetCountries();

			// act
			var result = input.FilterByCommonName("sT");

			// assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Equal(expectedLength, result.Count());
			Assert.True(result.ElementAt(0).Name?.Common == "Ivory Coast");
			Assert.True(result.ElementAt(1).Name?.Common == "Estonia");
		}

		[Fact]
		public void FilterByCommonNameAndReturnEmptyCollectionIfNotFound()
		{
			// arrange
			var input = GetCountries();

			// act
			var result = input.FilterByCommonName("bin");

			// assert
			Assert.NotNull(result);
			Assert.Empty(result);
		}

		[Fact]
		public void FilterByCommonNameAndReturnAllIfFilterExpressionIsNull()
		{
			// arrange
			var input = GetCountries();
			var expectedLength = input.Length;

			// act
			var result = input.FilterByCommonName(null);

			// assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Equal(expectedLength, result.Count());
		}

		[Fact]
		public void FilterByPopulation()
		{
			// arrange
			var input = GetCountries();
			var expectedLength = 1;
			var millionPeople = 2;
			var expectedName = "Estonia";

			// act
			var result = input.FilterByMaxPopulation(millionPeople);

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
			var input = GetCountries();
			var expectedLength = input.Length;

			// act
			var result = input.FilterByMaxPopulation(null);

			// assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Equal(expectedLength, result.Count());
		}

		[Fact]
		public void SortAscending()
		{
			// arrange
			var input = GetCountries();
			var expectedLength = input.Length;

			// act
			var result = input.SortByCommonName(SortDirection.Ascend);

			// assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Equal(expectedLength, result.Count());
			Assert.True(result.ElementAt(0).Name?.Common == "Albania");
			Assert.True(result.ElementAt(2).Name?.Common == "Croatia");
			Assert.True(result.ElementAt(input.Length - 1).Name?.Common == "Ivory Coast");
		}

		[Fact]
		public void SortDescending()
		{
			// arrange
			var input = GetCountries();
			var expectedLength = input.Length;

			// act
			var result = input.SortByCommonName(SortDirection.Descend);

			// assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Equal(expectedLength, result.Count());
			Assert.True(result.ElementAt(0).Name?.Common == "Ivory Coast");
			Assert.True(result.ElementAt(2).Name?.Common == "Croatia");
			Assert.True(result.ElementAt(input.Length - 1).Name?.Common == "Albania");
		}

		[Fact]
		public void NotSortWhenSortExpressionIsInvalid()
		{
			// arrange
			var input = GetCountries();
			var expectedLength = input.Length;

			// act
			var result = input.SortByCommonName("Anything");

			// assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Equal(expectedLength, result.Count());
			Assert.True(result.ElementAt(0).Name?.Common == "Albania");
			Assert.True(result.ElementAt(2).Name?.Common == "Ivory Coast");
			Assert.True(result.ElementAt(input.Length - 1).Name?.Common == "Estonia");
		}

		[Fact]
		public void NotSortWhenSortExpressionIsNull()
		{
			// arrange
			var input = GetCountries();
			var expectedLength = input.Length;

			// act
			var result = input.SortByCommonName(null);

			// assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Equal(expectedLength, result.Count());
			Assert.True(result.ElementAt(0).Name?.Common == "Albania");
			Assert.True(result.ElementAt(2).Name?.Common == "Ivory Coast");
			Assert.True(result.ElementAt(input.Length - 1).Name?.Common == "Estonia");
		}

		[Fact]
		public void LimitResultLength()
		{
			// arrange
			var input = GetCountries();
			var expectedLength = input.Length - 2;

			// act
			var result = input.TakeFirst(expectedLength);

			// assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Equal(expectedLength, result.Count());
			Assert.True(result.ElementAt(0).Name?.Common == "Albania");
			Assert.True(result.ElementAt(expectedLength - 1).Name?.Common == "Ivory Coast");
		}

		[Fact]
		public void NotLimitResultLengthIfDesiredLengthIsLonger()
		{
			// arrange
			var input = GetCountries();
			var expectedLength = input.Length;
			var desiredLength = expectedLength + 5;

			// act
			var result = input.TakeFirst(desiredLength);

			// assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Equal(expectedLength, result.Count());
			Assert.True(result.ElementAt(0).Name?.Common == "Albania");
			Assert.True(result.ElementAt(expectedLength - 1).Name?.Common == "Estonia");
		}

		[Fact]
		public void NotLimitResultLengthIfDesiredLengthIsNull()
		{
			// arrange
			var input = GetCountries();
			var expectedLength = input.Length;

			// act
			var result = input.TakeFirst(null);

			// assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Equal(expectedLength, result.Count());
			Assert.True(result.ElementAt(0).Name?.Common == "Albania");
			Assert.True(result.ElementAt(expectedLength - 1).Name?.Common == "Estonia");
		}

		private Country[] GetCountries()
		{
			return new[]
			{
				new Country{ Name = new CountryName { Common = "Albania" }, Population = 2837743 },
				new Country{ Name = new CountryName { Common = "Bangladesh" }, Population = 164689383 },
				new Country{ Name = new CountryName { Common = "Ivory Coast" }, Population = 26378275 },
				new Country{ Name = new CountryName { Common = "Croatia" }, Population = 4047200 },
				new Country{ Name = new CountryName { Common = "Estonia" }, Population = 1331057 }
			};
		}
	}
}