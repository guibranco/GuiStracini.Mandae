# Mandaê API
The (unnoficial) Mandaê API wrapper

[![GuiStracini.Mandae NuGet Version](https://img.shields.io/nuget/v/GuiStracini.Mandae.svg)](https://nuget.com/GuiStracini.Mandae/)
[![GuiStracini.Mandae NuGet Downloads](https://img.shields.io/nuget/dt/GuiStracini.Mandae.svg)](https://nuget.com/GuiStracini.Mandae/)
[![guistracini-mandae MyGet Build Status](https://www.myget.org/BuildSource/Badge/guistracini-mandae?identifier=ee13534c-dc61-4d46-8935-52268ffe148a)](https://www.myget.org/)

This is an unnoficial wrapper for the **Mandaê API** *V2*.
(https://dev.mandae.com.br/api/index.html)

 1. Register customer (collect location - distribution center)
 2. Get available vehicles for a collect location (pickup packages from collect location based on postal code) 
 3. Get rates for a delivery (postal code and package dimensions)
 4. Schedule a collect (register a collect in the customer distribution center with one or more packages. Each package can have one or more items/skus)
 5. Cancel the whole collect schedule (Cancel a previous collect scheduler)
 6. Cancel a schedule item (Cancel a package from a collect order)
 7. Get tracking data of a shipment (Get all tracking data available from one package - tracking code is supplied via WebHook)
 8. WebHooks schema ready (The web hooks models/schemas)


----------


## Setup the MandaeClient ##

How to create a new MandaeClient instance:

```csharp
	//Request your API token to ti@mandae.com.br 
	//Each environment has it's own API token!
    var apiToken = "";
	
	//Call the constructor with the API token and de API environment (SANDBOX | PRODUCTION).
    var client = new MandaeClient(apiToken,Environment.SANDBOX);
    
	//Consume the API with the client
    //var orderResponse = client.RegisterOrder(new OrderModel {...});
```

## Register a customer ##

How to register a customer (collect location):

```csharp
    //Assuming you already has a MandaeClient instance
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
    var customer = client.RegisterCustomer(model);
    //The response id should be stored anywhere for future use (where the packages will be collected). This id is used in the RegisterOrder method
    
```

