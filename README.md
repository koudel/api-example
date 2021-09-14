# Product.Service (api-example)

API example with part of **CQRS model**. Application is not using any DB, data are mocked id **Domain** layer.<br>
Changes in PUT endpoint are not stored. Data are reloaded for every call.<br>
API has 5 hardcoded rows of **Product** object class.

## Endpoints
[GET] /v1/Product/GetAll
[GET] /v1/Product/Get/{id}
[PUT] ​/v1​/Product​/UpdateDescription

## Prerequisites

Recomended: Visual Studio 2019 (or Community) or dotnet in command line

### Edit
Edit can be done in every text editor (Visual studio recommended). For build is **Visual Studio or MSBuild** needed.

### Execute
**With Visual Studio**:<br>
Open solution **Product.Service.sln** (placed in folder *\Product.Service\*). Service can be run in debug mode directly from visual studio without any changes. <br>
Service will run at *http://localhost:29144/* and Visual Studio will automatically start window at **Swagger documentation** (http://localhost:29144/swagger/index.html) <br><br>

**With command line**:<br>
Navigate into folder with **Product.Service.Main.csproj** (placed in folder *\Product.Service\Product.Service.Main\*). <br>
Run command **dotnet run**. API is placed in address *http://localhost:5000* (for swagger documentation add */swagger* into address) <br>

## Tests
**With Visual Studio**:<br>
Open solution **Product.Service.sln** (placed in folder *\Product.Service\*). Open folder **Tests** in Solution Explorer. Right click on project **Product.Service.UnitTests** and click *Run Tests*<br><br>

**With command line**:<br>
Navigate into folder with **Product.Service.UnitTests.csproj** (placed in folder *\Product.Service\Product.Service.UnitTests\*). <br>
Run command **dotnet test**. Results will be printed into console.