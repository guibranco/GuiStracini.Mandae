# Mandaê API Client

The **(unofficial)** Mandaê API client

[![Build status](https://ci.appveyor.com/api/projects/status/2et11cwujyfnsruj?svg=true)](https://ci.appveyor.com/project/guibranco/guistracini-mandae)
[![GuiStracini.Mandae NuGet Version](https://img.shields.io/nuget/v/GuiStracini.Mandae.svg?style=flat)](https://www.nuget.org/packages/GuiStracini.Mandae/)
[![GuiStracini.Mandae NuGet Downloads](https://img.shields.io/nuget/dt/GuiStracini.Mandae.svg?style=flat)](https://www.nuget.org/packages/GuiStracini.Mandae/)
[![Github All Releases](https://img.shields.io/github/downloads/guibranco/GuiStracini.Mandae/total.svg?style=flat)](https://github.com/guibranco/GuiStracini.Mandae)
![Last release](https://img.shields.io/github/release-date/guibranco/guistracini.mandae.svg?style=flat)

[![Mandaê logo]](https://raw.githubusercontent.com/guibranco/GuiStracini.Mandae/master/Mandae.png)


This is an **unnoficial** client for the **Mandaê API** *V2*.
(https://dev.mandae.com.br/api/index.html)

----------
Release v1.4.1 and higher also includes a experimental (non-public) V1 endpoint for search/querying orders (the same interface as available through the Mandaê administration panel).

**The API V1 is not officially public, so there is no warranty that it will still working**

**Release v3.0.0 and higher changes the V1 authentication method. Now use your e-mail/password of the Mandaê painel to login in the V1 API.**

**Release v5.0.0 and higher DEPRECATED methods: Large Request, Cancel Request, Cancel Item Request**

**Release v6.0.0 and higher DEPRECATED methods: Get Latest Order**

----------

NuGet package: https://www.nuget.org/packages/GuiStracini.Mandae

```ps

Install-Package GuiStracini.Mandae

```

## Features

This client supports the following operations/features of the API:
 1. Get rates for a delivery (postal code and package dimensions)
 2. Schedule a collect (register a collect in the customer distribution center with one or more packages. Each package can have one or more items/skus)
 4. Get tracking data of a shipment (Get all tracking data available from one package - tracking code is set by the customer or provided by webhook)
 5. WebHooks schema ready (The web hooks models, ready for implementation)
 6. **Experimental** Querying orders (API V1 - non-public API)
 7. **Experimental** Querying ocurrences (API V1 - non-public API) **[TODO]**
 8. **Experimental** Querying reverses (API V1 - non-public API) **[TODO]**
 9. **Experimental** Request reverse (API V1 - non-public API) **[TODO]**


 All operations supports sync and async!

----------

## Setup the MandaeClient

Initializes a new instance of **MandaeClient** class.

Example:

```csharp

//Request your API token to ti@mandae.com.br 
//Each environment has it's own API token!
var apiToken = "my API token";

//Call the constructor with the API token and de API environment (SANDBOX | PRODUCTION).
//var client = new MandaeClient(apiToken); //<= Environment.SANDBOX is the default environment.
var client = new MandaeClient(apiToken, Environment.PRODUCTION);

```

## Get rates for a package/delivery

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

## Schedule a collect request

Schedule a collect request (pickup in distribution center / origin location).

Inform which type of Vehicle, when, which rate (Rapido | Economico) and the order items (a.k.a packages or clients orders).

Each package means a order/volume, that can have one or more items (SKUs).

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

//order.Id is the id for futher use (maybe cancel the request ?)

```

## Get tracking of a package

Example:

```csharp

//The MandaeClient
var client = new MandaeClient("my API token");

//The tracking identifier (Generate by the Mandae or sent by the order collect request
var trackingId = "MyCompany-00001";
var tracking = client.GetTracking(trackingId);
//tracking.CarrierName;
//tracking.CarrierCode;
//tracking.Events;

```
## Querying orders (API V1 - Search) EXPERIMENTAL/NON-PUBLIC API

For the V1 you'll need to use the e-mail/password combination of t he Mandaê painel to login in V1 API.

Example:

```csharp

//The MandaeClient
var client = new MandaeClient("V2 API token");
client.ConfigureV1Authentication("myEmail@example.com", "mypassword");
var trackingCode = "XYZ000001";//The tracking code of some order
var result = client.Search(SearchMethod.TRACKING_CODE, trackingCode);
if(result.Total == 1)
	Console.WriteLine(result.Orders.Single().SituationDescription);    

```
