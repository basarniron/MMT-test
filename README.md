# MMT-test

Setup
--------------------------
1. Restore nuget packages (unless they get triggered automatically)
2. Set up API Key and ConnectionString
Update appsettings.Development.json
```
  "MMT": {
    "ConnectionString": "",
    "ApiKey": ""
  },
```
OR

Add Environment variables
* Add user variables by going to System Properties->Environment Variables-> User variables

OR

* Go to MMT.Test.Order.API project's properties->Debug->Environment variables
```
Add MMT:ApiKey as a key and api key as a value
Add MMT:ConnectionString as a key and connection string as a value 
```

Development
---------------------------

* Unit tests should be added
* More exception handling and logging should be added
* Comments and method summaries needs to be added
* CORS->Allowed origins could be bound to a configuration

Production
----------------------------
1. Set ENV to Production
"environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Production"
      }

2. Set up API Key and ConnectionString for production

Add Environment variables
* Add user variables by going to System Properties->Environment Variables-> User variables
```
Add MMT:ApiKey as a key and api key as a value
Add MMT:ConnectionString as a key and connection string as a value 
```

