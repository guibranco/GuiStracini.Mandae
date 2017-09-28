# Mandaê API
The **(unnoficial)** Mandaê API client

[![GuiStracini.Mandae NuGet Version](https://img.shields.io/nuget/v/GuiStracini.Mandae.svg)](https://nuget.com/GuiStracini.Mandae/)
[![GuiStracini.Mandae NuGet Downloads](https://img.shields.io/nuget/dt/GuiStracini.Mandae.svg)](https://nuget.com/GuiStracini.Mandae/)

This is an **unnoficial** client for the **Mandaê API** *V2*.
(https://dev.mandae.com.br/api/index.html)

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

How to create a new MandaeClient instance:

Example:
```csharp
//Request your API token to ti@mandae.com.br 
//Each environment has it's own API token!
var apiToken = "my API token";

//Call the constructor with the API token and de API environment (SANDBOX | PRODUCTION).
var client = new MandaeClient(apiToken,Environment.SANDBOX);
```

## Register a customer (pickup/collect location) ##

How to register a customer (pickup/collect location):

Example:
```csharp
//The MandaeClient
var clieent = new MandaeClient("my API token", Environment.SANDBOX)

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

Get all available vehicles for a pickup in a source postal code (distribution center / origin location)

Example:
```csharp
//The MandaeClient
var client = new MandaeClient("my API token", Environment.SANDBOX);

var vehicles = client.GetVehicles("03137020");
if(vehicles.Any(v=>v.CAR))
{
    //Car is available for the pickup in this postal code!
}
```

## Get rates for a package/delivery ##

Get the rates (Rápido & Econômico) values and delivery time for a specified postal code and package dimensions

Example:
```csharp
//The MandaeClient
var client = new MandaeClient("my API token", Environment.SANDBOX);

//The RatesModel
var delivery = new RatesModel {
	PostalCode = "22041080",
	...
}
var rates = client.GetRates(delivery);
var fast = rates.ShippingServices.Single(s => s.Id == "Rápido");
var economic = rates.ShippingServices.Single(s => s.Id == "Econômico");
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
var client = new MandaeClient("my API token", Environment.SANDBOX);

//Check the available hours for tomorrow
var date= DateTime.Now.AddDays(1);

//The list os avaiable hours for pickup tomorrow
var avaiableHours = client.GetAvaiableHours(date);
```

## Schedule a collect request ##

Schedule a collect request (pickup in distribution center / origin location).

Inform which type of Vehicle (GetVehicles), when (GetAvailableHours), which rate (Rapido | Economico) and the order items (a.k.a packages or clients orders).

Each package means a order/volume, that can have one or more items (SKUs)

Example: [[TODO]]

## Cancel a schedule collect request ##

[TODO]

## Cancel a schedule item (package) collect request ##

[TODO]

## Get tracking of a package ##

[TODO]