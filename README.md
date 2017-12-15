# Mandaê API
The **(unnoficial)** Mandaê API client

[![Build status](https://ci.appveyor.com/api/projects/status/2et11cwujyfnsruj?svg=true)](https://ci.appveyor.com/project/guibranco/guistracini-mandae)
[![GuiStracini.Mandae NuGet Version](https://img.shields.io/nuget/v/GuiStracini.Mandae.svg)](https://www.nuget.org/packages/GuiStracini.Mandae/)
[![GuiStracini.Mandae NuGet Downloads](https://img.shields.io/nuget/dt/GuiStracini.Mandae.svg)](https://www.nuget.org/packages/GuiStracini.Mandae/)
[![Github All Releases](https://img.shields.io/github/downloads/guibranco/GuiStracini.Mandae/total.svg?style=plastic)](https://github.com/guibranco/GuiStracini.Mandae)

<img src="https://raw.githubusercontent.com/guibranco/GuiStracini.Mandae/master/Mandae.png" alt="GuiStracini.Mandae" width="150" height="150" />
This is an **unnoficial** client for the **Mandaê API** *V2*.
(https://dev.mandae.com.br/api/index.html)

----------

NuGet package: https://www.nuget.org/packages/GuiStracini.Mandae

```ps
Install-Package GuiStracini.Mandae
```

## Features ##

This client supports the following operations/features of the API:
 1. Get available vehicles for a collect location (pickup packages from collect location based on postal code) 
 2. Get rates for a delivery (postal code and package dimensions)
 3. Get the available hours to pickup order(s) in a selected date
 4. Schedule a collect (register a collect in the customer distribution center with one or more packages. Each package can have one or more items/skus)
 5. Cancel the whole collect schedule (Cancel a previous collect scheduler)
 6. Cancel a schedule item (Cancel a item/package from a collect order)
 7. Get tracking data of a shipment (Get all tracking data available from one package - tracking code is supplied via WebHook)
 8. WebHooks schema ready (The web hooks models/schemas)
 9. Collect builder (gets a builder for schedule a collect, allowing add items on-demand)

 All operations supports sync and async!

----------


## Setup the MandaeClient ##

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

## Get available vehicles ##

Get all available vehicles for a pickup in a source postal code (distribution center / origin location).

Example:
```csharp
//The MandaeClient
var client = new MandaeClient("my API token");

var vehicles = client.GetVehicles("03137020");
if(vehicles.Any(v=>v.CAR))
{
    //Car is available for the pickup in this postal code!
}
```

## Get rates for a package/delivery ##

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

## Get available hours for pickup ##

Gets the available hours for pickup/collect packages in the distribuiton center for a specified date.

Example:
```csharp
//The MandaeClient
var client = new MandaeClient("my API token");

//Check the available hours for tomorrow
var date= DateTime.Now.AddDays(1);

//The list os avaiable hours for pickup tomorrow
var avaiableHours = client.GetAvaiableHours(date);
```

## Schedule a collect request ##

Schedule a collect request (pickup in distribution center / origin location).

Inform which type of Vehicle (GetVehicles), when (GetAvailableHours), which rate (Rapido | Economico) and the order items (a.k.a packages or clients orders).

Each package means a order/volume, that can have one or more items (SKUs).

Example: **[TODO]**

## Get the latest order collect request status ##

Gets the last order collect request for a customer (by customerId).

Example:
```csharp
//The MandaeClient
var client = new MandaeClient("my API token");

//The customerId 
var customerId = "sampleCustomerId";
var status = client.GetLatestOrderCollectStatus(customerId);

//Tracking url for the order collect request
var url = status.Url;

```

## Cancel a schedule collect request ##

Example: **[TODO]**

## Cancel a schedule item (package) collect request ##

Example:
```csharp
//The MandaeClient
var client = new MandaeClient("my API token");

//The order identifier 
var orderId = 1;
var canceled = client.CancelOrderCollectRequest(orderId);

//if(canceled)
//  Debug.WriteLine("order canceled");

```

## Get tracking of a package ##

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

## Collect Builder

Example: **[TODO]**
