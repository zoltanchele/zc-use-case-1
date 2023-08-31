# REST Countries Façade

## Description
A little façade for the popular REST Countries API.

## Build
Before building this little web API locally, make sure you have the lates .NET 6 SDK installed. You can download it [here](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).
Perform the following steps to build and run the API:
* Open up your favorite terminal app.
* Clone or download the repository.
* Inside the repository directory, navigate into `src/RestCountriesFacade` directory in your terminal.
* Build and run the project via the `dotnet run` command. When you see `Content root path: ...` in the console, the API is up.
* You can send GET requests to the `https://localhost:7237/retrieve` endpoint or see the OpenAPI documentation at `https://localhost:7237/swagger` in your browser.

## Usage
The web API exposes only a single endpoint `/retrieve` that accepts GET requests with the following optional query parameters:

| Parameter name | Description | Example |
| -------------- | ----------- | ------- |
| `filter`       | Accepts a string and filters the result set to objects where the `name.common` property contains the filter expression case-insensitively. | GET `https://localhost:7237/retrieve?filter=rD` returns **Svalbard and Jan Mayen**, **Heard Island and McDonald Islands**, **Jordan**, and **Cape Verde**|
| `populationMillions` | Accepts a decimal number and reduces the result set to objects where the `population` property is less than the specified number multiplied by 1 million. The decimal separator must be a `.` otherwise the output will be unpredictable. In case if an invalid value is specified the API will return `400 Bad Request`. | GET `https://localhost:7237/retrieve?populationMillions=1` will return all countries where the population is less than 1 million. |
| `sort` | Accepts the following strings: 'ascend' and 'descend' and sorts the result set by the `name.common` property in ascending or descending order. If anything else than 'ascend' or 'descend' is specified the parameter will be ignored. | GET `https://localhost:7237/retrieve?sort=ascend` will return all countries in ascending order. <br>GET `https://localhost:7237/retrieve?sort=descend` will return all countries in descending order. |
| `take` | Accepts an integer and limits the returned result set length to the specified value. | GET `https://localhost:7237/retrieve?take=5` will return the first 5 countries |

Of course, the above parameters can be used in any combination and order. For example:
* GET `https://localhost:7237/retrieve?take=2&filter=republic` will return the first two country objects where the `name.common` property contains the word `republic`
* GET `https://localhost:7237/retrieve?sort=ascend&populationMillions=2` will return all countries with a population of less than 2 million sorted by their common name in ascending order.
* GET `https://localhost:7237/retrieve?filter=istan&sort=descend` will return all countries whose `name.common` property contains the `istan` search string in descending order.
* GET `https://localhost:7237/retrieve?filter=al&populationMillions=10&sort=ascend&take=2` returns the first two country objects whose `name.common` property contains the `al` search string and the population property is less than 10 millions in ascending order.

In case if no parameter is specified, all countries will be returned without filtering, sorting or limiting. For example:
* GET `https://localhost:7237/retrieve` will return the entire result set as it comes from the original REST Countries API.

## Known issues
Since the Swagger UI has significant performance degradation in case of large result sets, syntax highlighting in Swagger has been disabled.