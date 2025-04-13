Project Overview
AnimalClinicAPI is an ASP.NET Core Web API project that manages animal data and their associated visit records for a veterinary clinic. It follows the traditional hosting pattern by separating the application configuration into a Program file and a Startup class.

File and Folder Explanations
Project File (AnimalClinicAPI.csproj):
This file contains the overall project configuration. It specifies that the project uses the ASP.NET Core Web SDK, targets .NET 9.0 preview, and includes package references needed by the project. It also configures features such as implicit usings and nullable reference types.

Program File (Program.cs):
This file serves as the entry point of the application. It builds and runs the web host by invoking the Startup class. The main responsibility here is to set up the hosting environment using a default builder and to connect the configuration defined in Startup.

Startup Class (Startup.cs):
The Startup class is responsible for configuring services and the HTTP request pipeline. In its services configuration method, it registers essential services like controllers. In the pipeline configuration method, it sets up middleware components such as routing, error handling (in development), and endpoint mapping for controllers.

Controllers Folder:
This folder contains the API controllers.

AnimalController: Manages endpoints related to creating, retrieving, updating, and deleting animal records.

VisitController: Manages endpoints related to accessing and creating visit records for the animals.
These controllers process incoming HTTP requests and interact with the in-memory data store.

Models Folder:
This folder holds the data models that represent the domain entities.

Animal Model: Represents animals with properties such as an identifier, name, category, weight, fur color, and a list of visits.

Visit Model: Represents visits, including details like the visit date, a description, the cost, and a link to the associated animal.

Data Folder (FakeDatabase.cs):
The FakeDatabase class simulates a database by storing animals and visits in static lists. This in-memory data store is useful for testing and demonstrating API functionality without a real database.
