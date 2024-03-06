# ETL Labs

## Overview

Learn time: Using Hangfire to scraping in background API.

## Context 

The goal of this PoC is to better understand the use of recurring services in background in ASP.NET Core APIs. As a result, a ETL was built that runs a service once a week and extracts the top 5 most listened music on youtube. In addition to the concept of services in the background, the construction of a Web Scraping using the selenium on the .NET platform is also explored.

**ETL:** Is a data integration process that Extracts, Transforms, and Loads data from various data storage sources;

**Scraping:** Is a process of extracting data from a specific source;

## Key Features

 - .NET 7.0
 - C#
 - [Hangfire](https://www.hangfire.io/)
 - [Selenium](https://www.selenium.dev/)

 
## TODO

- [ ] Implement logging in Hangfire dashboard
- [ ] Implement authentication for Hangfire dashboard

## Compatible IDEs

Tested on:

- VS Code

## Useful commands

From the terminal/shell/command line tool, use the following commands to build, test and run the API.

### Run the application

```shell
# Run the application.
dotnet run --project ./src/etl-labs.API
```

```shell
# Run the application on Docker
docker compose up -d
```
