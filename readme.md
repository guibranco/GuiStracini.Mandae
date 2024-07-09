# Mandaê SDK .NET

🇧🇷🚚 Mandaê API .NET client wrapper

Para a versão em português, por favor [siga me](/README.pt-br.md).

[![GitHub license](https://img.shields.io/github/license/guibranco/GuiStracini.Mandae)](https://github.com/guibranco/GuiStracini.Mandae)
[![Time tracker](https://wakatime.com/badge/github/guibranco/GuiStracini.Mandae.svg)](https://wakatime.com/badge/github/guibranco/GuiStracini.Mandae)
[![GitHub issues by-label](https://img.shields.io/github/issues/guibranco/guistracini.mandae/help%20wanted.svg)](https://github.com/guibranco/guistracini.mandae/issues?q=is%3Aissue+is%3Aopen+label%3A%22help+wanted%22)

![Mandae logo](https://raw.githubusercontent.com/guibranco/GuiStracini.Mandae/main/logo.png)

This is an **unofficial** client for the [Mandaê API V2](https://dev.mandae.com.br/api/index.html)

---

## CI/CD

| Build status | Last commit | Tests | Coverage | Code Smells | LoC |
|--------------|-------------|-------|----------|-------------|-----|
## Querying Occurrences API Usage
| [![Build status](https://ci.appveyor.com/api/projects/status/hgtsg00sd3ahykdw/branch/main?svg=true)](https://ci.appveyor.com/project/guibranco/guistracini-mandae/branch/main) | [![GitHub last commit](https://img.shields.io/github/last-commit/guibranco/GuiStracini.Mandae/main)](https://github.com/guibranco/GuiStracini.Mandae) | [![AppVeyor tests (branch)](https://img.shields.io/appveyor/tests/guibranco/GuiStracini-Mandae/main?compact_message)](https://ci.appveyor.com/project/guibranco/guistracini-mandae) | [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=guibranco_GuiStracini.Mandae&metric=coverage&branch=main)](https://sonarcloud.io/dashboard?id=guibranco_GuiStracini.Mandae) | [![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=guibranco_GuiStracini.Mandae&metric=code_smells&branch=main)](https://sonarcloud.io/dashboard?id=guibranco_GuiStracini.Mandae) | [![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=guibranco_GuiStracini.Mandae&metric=ncloc&branch=main)](https://sonarcloud.io/dashboard?id=guibranco_GuiStracini.Mandae) |

## Code Quality (main branch)

[![Codacy Badge](https://app.codacy.com/project/badge/Grade/727443824fe244be840dc6ba2e444c9e)](https://www.codacy.com/gh/guibranco/GuiStracini.Mandae/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=guibranco/GuiStracini.Mandae&amp;utm_campaign=Badge_Grade)
[![Codacy Badge](https://app.codacy.com/project/badge/Coverage/727443824fe244be840dc6ba2e444c9e)](https://www.codacy.com/gh/guibranco/GuiStracini.Mandae/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=guibranco/GuiStracini.Mandae&amp;utm_campaign=Badge_Grade)

[![codecov](https://codecov.io/gh/guibranco/GuiStracini.Mandae/branch/main/graph/badge.svg)](https://codecov.io/gh/guibranco/GuiStracini.Mandae)
[![CodeFactor](https://www.codefactor.io/repository/github/guibranco/GuiStracini.Mandae/badge)](https://www.codefactor.io/repository/github/guibranco/GuiStracini.Mandae)

[![Maintainability](https://api.codeclimate.com/v1/badges/5e1cd09aba4cc90d08d5/maintainability)](https://codeclimate.com/github/guibranco/GuiStracini.Mandae/maintainability)
[![Test Coverage](https://api.codeclimate.com/v1/badges/5e1cd09aba4cc90d08d5/test_coverage)](https://codeclimate.com/github/guibranco/GuiStracini.Mandae/test_coverage)

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=guibranco_GuiStracini.Mandae&metric=alert_status)](https://sonarcloud.io/dashboard?id=guibranco_GuiStracini.Mandae)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=guibranco_GuiStracini.Mandae&metric=sqale_rating)](https://sonarcloud.io/dashboard?id=guibranco_GuiStracini.Mandae)

[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=guibranco_GuiStracini.Mandae&metric=sqale_index)](https://sonarcloud.io/dashboard?id=guibranco_GuiStracini.Mandae)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=guibranco_GuiStracini.Mandae&metric=duplicated_lines_density)](https://sonarcloud.io/dashboard?id=guibranco_GuiStracini.Mandae)

[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=guibranco_GuiStracini.Mandae&metric=reliability_rating)](https://sonarcloud.io/dashboard?id=guibranco_GuiStracini.Mandae)
### Example
```csharp
var request = new OccurrenceRequest {
    // Set request properties
};
var response = await client.QueryOccurrencesAsync(request);
```
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=guibranco_GuiStracini.Mandae&metric=security_rating)](https://sonarcloud.io/dashboard?id=guibranco_GuiStracini.Mandae)

[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=guibranco_GuiStracini.Mandae&metric=bugs)](https://sonarcloud.io/dashboard?id=guibranco_GuiStracini.Mandae)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=guibranco_GuiStracini.Mandae&metric=vulnerabilities)](https://sonarcloud.io/dashboard?id=guibranco_GuiStracini.Mandae)

[![DeepSource](https://app.deepsource.com/gh/guibranco/GuiStracini.Mandae.svg/?label=active+issues&show_trend=true&token=IeLgGedanFVCj0wxFnPqF3V4)](https://app.deepsource.com/gh/guibranco/GuiStracini.Mandae/?ref=repository-badge)

---

## Installation

### Github Releases

[![GitHub last release](https://img.shields.io/github/release-date/guibranco/GuiStracini.Mandae.svg?style=flat)](https://github.com/guibranco/GuiStracini.Mandae) [![Github All Releases](https://img.shields.io/github/downloads/guibranco/GuiStracini.Mandae/total.svg?style=flat)](https://github.com/guibranco/GuiStracini.Mandae)

Download the latest zip file from the [Release](https://github.com/GuiBranco/GuiStracini.Mandae/releases) page.

### Nuget package manager

| Package | Version | Downloads |
|------------------|:-------:|:-------:|
| **GuiStracini.Mandae** | [![GuiStracini.Mandae NuGet Version](https://img.shields.io/nuget/v/GuiStracini.Mandae.svg?style=flat)](https://www.nuget.org/packages/GuiStracini.Mandae/) | [![GuiStracini.Mandae NuGet Downloads](https://img.shields.io/nuget/dt/GuiStracini.Mandae.svg?style=flat)](https://www.nuget.org/packages/GuiStracini.Mandae/) |

---

## Features

This client supports the following operations/features of the API:

 1. Get rates for a delivery (postal code and package dimensions)
 2. Schedule a collect (register a collect in the customer distribution centre with one or more packages. Each package can have one or more items/SKU)
 3. Get tracking data of a shipment (Get all tracking data available from one package - tracking code is set by the customer or provided by webhook)
 4. WebHooks schema ready (The webhooks models, ready for implementation)
 5. **Experimental** Querying orders (API V1 - non-public API)
 6. **Experimental** Querying occurrences (API V1 - non-public API). [Issue #1](https://github.com/guibranco/GuiStracini.Mandae/issues/1) ![GitHub labels](https://img.shields.io/github/labels/guibranco/BancosBrasileiros/help%20wanted)
 7. **Experimental** Querying reverses (API V1 - non-public API). [Issue #2](https://github.com/guibranco/GuiStracini.Mandae/issues/2) ![GitHub labels](https://img.shields.io/github/labels/guibranco/BancosBrasileiros/help%20wanted)
 8. **Experimental** Request reverse (API V1 - non-public API). [Issue #3](https://github.com/guibranco/GuiStracini.Mandae/issues/3) ![GitHub labels](https://img.shields.io/github/labels/guibranco/BancosBrasileiros/help%20wanted)

---

## Usage

### Setup the MandaeClient

Initializes a new instance of **MandaeClient** class.

Example:

```csharp
//Request your API token to ti@mandae.com.br 
//Each environment has its own API token!
var apiToken = "my API token";

//Call the constructor with the API token and the API environment (SANDBOX | PRODUCTION).
//var client = new MandaeClient(apiToken); //<= Environment.SANDBOX is the default environment.
var client = new MandaeClient(apiToken, Environment.PRODUCTION);
```

### Get rates for a package/delivery

Get the rates (Rápido & Econômico) values and delivery time for a specified postal code and package dimensions.

Example:

```csharp
//The MandaeClient
var client = new MandaeClient("my API token");

//The RatesModel
var delivery = new RatesModel {
    PostalCode = "22041080",
    ...
}
var rates = client.GetRates(delivery);
var fast = rates.ShippingServices.Single(s => s.Name == "Rápido");
var economic = rates.ShippingServices.Single(s => s.Name == "Econômico");
var option = ShippingService.ECONOMICO;
if(fast.Price < economic.Price)
    option = ShippingService.RAPIDO;

//The OrderModel (order collect request model)
var order = new OrderModel { ... };
order.Items = new [] {
    new NewItem 
    {
        ....
        ShippingService = option
    }
};
var order = client.RegisterOrderCollectRequest(order);
```

### Schedule a collect request

Schedule a collect request (pickup in a distribution center/origin location).

Inform which type of Vehicle, when, which rate (Rapido | Economico) and the order items (a.k.a packages or clients orders).

Each package means an order/volume, that can have one or more items (SKUs).

Example:

```csharp
//The MandaeClient
var client = new MandaeClient("my API token");

//The OrderModel (order collect request model)
var order = new OrderModel { ... };
order.Items = new [] {
    new NewItem 
    {
        ....
        ShippingService = option
    }
};

//Makes the request
var order = client.RegisterOrderCollectRequest(order);
**
//order.Id is the id for further use (maybe cancel the request ?)
```

### Get tracking of a package

Example:

```csharp
//The MandaeClient
var client = new MandaeClient("my API token");

//The tracking identifier (Generated by the Mandae or sent by the order collection request
var trackingId = "MyCompany-00001";
var tracking = client.GetTracking(tracking);
//tracking.CarrierName;
//tracking.CarrierCode;
//tracking.Events;
```

### Querying orders (API V1 - Search) EXPERIMENTAL/NON-PUBLIC API

For the V1 you'll need to use the e-mail/password combination of the Mandaê panel to log in V1 API.

Example:

```csharp
//The MandaeClient
var client = new MandaeClient("V2 API token");
client.ConfigureV1Authentication("myEmail@example.com", "password");
var trackingCode = "XYZ000001";//The tracking code of some order
var result = client.Search(SearchMethod.TRACKING_CODE, trackingCode);
if(result.Total == 1)
    Console.WriteLine(result.Orders.Single().SituationDescription);    
```

---

## Release notes

- Release v6.0.0 and higher DEPRECATED methods: Get Latest Order
- Release v5.0.0 and higher DEPRECATED methods: Large Request, Cancel Request, Cancel Item Request
- Release v3.0.0 and higher changes the V1 authentication method. Now use your e-mail/password of the Mandaê panel to log in to the V1 API.
- Release v1.4.1 and higher also includes an experimental (non-public) V1 endpoint for search/querying orders (the same interface as available through the Mandaê administration panel).

> **Warning**
>
> The API V1 is not officially public, so there is no warranty that it will still be working

---
