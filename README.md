# REST-Countries-API-data-processing
REST Countries API Data Processing is a robust and efficient application designed to handle, analyze, and manipulate data fetched from the public REST Countries API. This application provides an intuitive interface and powerful functionalities to extract, process, and visualize country-related data. 

Users can filter and sort data based on different parameters like population, area, languages, and more, enabling data-driven insights and decisions. It's an invaluable tool for researchers, data scientists, statisticians, and anyone interested in global data analysis.

# Getting Started
## Prerequisites
To run the application locally you need the following tools installed on your computer
* .NET 7 SDK
* Visual Studio 2022

## Steps to run the application locally
1. Clone the repo
```bash
git clone https://github.com/YurasNazar/REST-Countries-API-data-processing.git
```
2. Open the solution in the REST-Countries-API-data-processing\DataProcessingAPI folder, and select DataProcessingAPI as the startup project
3. Build the solution
4. Run the application, it will open the application in the browser on https://localhost:44364/swagger/index.html URL
5. Enjoy 😀

## Usage Examples 
This API provides an endpoint for querying country data with various parameters such as country name, population, order direction, and number of records to take. 
Here are some examples of how you can use this endpoint:

1. ### Filter by Country Name: ###
   Users can get data for a specific country by filtering by the country's name. For example, a GET request to /api/countries?name=Canada will return data for Canada.

2. ###  Filter by Population:  ###
   Users can filter countries based on population. For example, a GET request to /api/countries?population=1 will return data for countries with a population of at least 1 million.

3. ### Combining Name and Population: ###
   The endpoint can be used to get data for countries that meet both name and population filters. For example, /api/countries?name=Canada&population=1 will return data for Canada if its population is at least 1 million.

4. ### Order by Name: ###
   Users can order the country's data by name in ascending or descending order. For example, /api/countries?orderDirection=asc will return data for countries ordered by name in ascending order.

5. ### Pagination: ###
   Users can limit the number of records returned by the API using the take parameter. For example, /api/countries?take=10 will return data for the first 10 countries only.

6. ### Combined Query: ###
   Users can combine all parameters to make a complex query. For example, /api/countries?name=Canada&population=1&orderDirection=desc&take=10 will return data for up to 10 countries named 'Canada' with a population of at least 1 million, ordered by name in       
   descending order.

7. ### Filtering by Population and Ordering: ###
   Users can get data for countries with a certain population and order the results. For example, /api/countries?population=5&orderDirection=desc will return countries with a population of at least 5 million, ordered by name in descending order.

8. ### Filtering by Name and Limiting Results: ###
   Users can get data for countries with a specific name and limit the number of results. For example, /api/countries?name=India&take=5 will return data for up to 5 'India' entries.

9. ### Ordering and Pagination: ###
   Users can order the countries' data and also limit the number of results. For example, /api/countries?orderDirection=asc&take=20 will return data for the first 20 countries, ordered by name in ascending order.

10. ### No Parameters: ###
    Users can get data for all countries without applying any filters, sorting or pagination by making a GET request to /api/countries. This will return all available data.
