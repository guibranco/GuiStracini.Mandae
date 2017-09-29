# Mandaê API
The **(unnoficial)** Mandaê API client

[![Build status](https://ci.appveyor.com/api/projects/status/2et11cwujyfnsruj?svg=true)](https://ci.appveyor.com/project/guibranco/guistracini-mandae)
[![GuiStracini.Mandae NuGet Version](https://img.shields.io/nuget/v/GuiStracini.Mandae.svg)](https://www.nuget.org/packages/GuiStracini.Mandae/)
[![GuiStracini.Mandae NuGet Downloads](https://img.shields.io/nuget/dt/GuiStracini.Mandae.svg)](https://www.nuget.org/packages/GuiStracini.Mandae/)
[![Github All Releases](https://img.shields.io/github/downloads/guibranco/GuiStracini.Mandae/total.svg?style=plastic)](https://github.com/guibranco/GuiStracini.Mandae)


This is an **unnoficial** client for the **Mandaê API** *V2*.
(https://dev.mandae.com.br/api/index.html)

----------

NuGet package: https://www.nuget.org/packages/GuiStracini.Mandae

```ps
Install-Package GuiStracini.Mandae
```
----------

## Features ##

This client supports the following operations/features of the API:
 1. Register customer (collect location - distribution center)
 2. Get available vehicles for a collect location (pickup packages from collect location based on postal code) 
 3. Get rates for a delivery (postal code and package dimensions)
 4. Get the available hours to pickup order(s) in a selected date
 5. Schedule a collect (register a collect in the customer distribution center with one or more packages. Each package can have one or more items/skus)
 5. Cancel the whole collect schedule (Cancel a previous collect scheduler)
 6. Cancel a schedule item (Cancel a package from a collect order)
 7. Get tracking data of a shipment (Get all tracking data available from one package - tracking code is supplied via WebHook)
 8. WebHooks schema ready (The web hooks models/schemas)

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
//var client = new MandaeClient(apiTOken); //<= Environment.SANDBOX is the default environment.
var client = new MandaeClient(apiToken, Environment.PRODUCTION);
```

## Register a customer (pickup/collect location) ##

How to register a customer (pickup/collect location).

Example:
```csharp
//The MandaeClient
var clieent = new MandaeClient("my API token")

//The CustomerModel
var model = new CustomerModel 
{
    Document = "00000000000191", //CPF or CNPJ
    Email = "example@example.com",
    FullName = "Guilherme Branco Stracini",
    Phone = new Phone 
    {
        AreaCode = "11",
        Number = "33445566"
    },
    Store = new Store 
    {
        Name = "Sample store",
        Url = "https://example.com"
    }
};

//The response id should be stored anywhere for future use (where the packages will be collected). This id is used in the RegisterOrder method
var customer = client.RegisterCustomer(model);   
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

Example: [TODO: Pending test result]

## Get the latest order collect request status ##

Gets the last order collect request for a customer (by customerId).

Example:
```csharp
//The MandaeClient
var client = new MandaeClient("my API token");

//The customerId 
var customerId = "";
var status = client.GetLatestOrderCollectStatus(customerId);

//Tracking url for the order collect request
var url = status.Url;

```

## Cancel a schedule collect request ##

Example: [TODO | Pending test result]

## Cancel a schedule item (package) collect request ##

Example: [TODO | Pending test result]

## Get tracking of a package ##

Example: [TODO | Pending test result]
