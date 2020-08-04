<img src="https://raw.githubusercontent.com/halomademeapc/TenorClient/master/docfx_project/logo.png" alt="TenorClient Logo" width="128"/>

# Tenor Client
[![Build Status](https://img.shields.io/travis/halomademeapc/TenorClient?style=flat-square)](https://travis-ci.org/github/halomademeapc/TenorClient) [![GitHub issues](https://img.shields.io/github/issues/halomademeapc/TenorClient?style=flat-square)](https://github.com/halomademeapc/TenorClient/issues) [![Nuget](https://img.shields.io/nuget/dt/TenorClient?style=flat-square)](https://www.nuget.org/packages/TenorClient/) [![Nuget](https://img.shields.io/nuget/v/TenorClient?style=flat-square)](https://www.nuget.org/packages/TenorClient/)

Client for interacting with the Tenor API targetting .NET Standard 2.0.  Includes async support and pretty models.  

## Quick Start
You can get TenorClient from [NuGet](https://www.nuget.org/packages/TenorClient/).

```bash
dotnet add package TenorClient
```

```csharp
var config = new TenorConfiguration {
    ApiKey = "MY_API_KEY",
    Locale = CultureInfo.GetCultureInfo("en"),
    ContentFilter = ContentFilter.Medium,
    MediaFilter = MediaFilter.Minimal,
    AspectRatio = AspectRatio.All
};
var client = new TenorClient(config);
var searchResults = await client.SearchAsync("potato", limit: 20);
var categories = await client.GetCategoriesAsync();
var suggestions = await client.GetSearchSuggestionsAsync("potato");
```