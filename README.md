# 1. Project overview

This project aims to integrate a Config Server and a Product Catalog using the .NET platform, together with a Eureka Server developed using Netflix OSS with Maven. The proposed architecture allows different microservices (such as the Product Catalog) to obtain their centralized configurations through the Config Server, while registering with Eureka for service discovery.


Software engineering:
- Architecture diagram;

# Technologies: 
- .NET 8
- Microservices;
- Steeltoe.ConfigServerBase;
- Steeltoe.Discovery.ClientCore;
- EurekaServer Netflix
- Docker
- 1 Microservice => 1 Container;


# 2. Project structure:
Main directories:
EurekaServer/: Contains the Eureka Server implementation based on Netflix OSS with Maven.
ConfigServer/: Implementation of Config Server in .NET.
ProductCatalog/: Product catalog service also developed in .NET.

Main files:
EurekaServer/application.properties: Maven configuration file for Eureka Server.
ConfigServer/Program.cs: Config Server entry point.
ProductCatalog/Program.cs: Entry point for the Product Catalog microservice.
appsettings.json: Common configuration file in .NET for both ConfigServer and ProductCatalog.

# 3. Setting up the environment

Prerequisites:
JDK: Required to run Eureka Server.
Maven: Build tool for Eureka Server.
.NET SDK 8: Required to compile and run the .NET projects (ConfigServer and ProductCatalog).
Docker (Optional): If you wish to run the microservices in containers.

Installation steps:

Clone the project repository: <https://github.com/adony-lagares/product-catalog-microservices>
Install the JDK and Maven:

Follow the instructions for installing the JDK and Maven according to your platform.
Install the .NET SDK 8:

Download and install the correct version of the .NET SDK from the official Microsoft website.


Configuring Eureka Server
Navigate to the DiscoveryServer/ folder and compile the project:

mvn clean install

Run Eureka Server:
mvn spring-boot:run

Eureka Server should be accessible at http://localhost:8761.

Configuring Config Server in .NET

Navigate to the ConfigServer/ folder.

Check the appsettings.json file:

Make sure that Eureka's serviceUrl is correctly set to http://localhost:8761/eureka/.
Create the configuration file productcatalog-development.yml:

In the path C:\Project\productcatalog-development.yml.
Add the desired settings for the Product Catalog.

Run the Config Server:
dotnet run

Configuring the Product Catalog
Navigate to the ProductCatalog/ folder.

Check the appsettings.json file:

Set the Config Server URL to http://localhost:5016 (or the configured port).
Run the Product Catalog:
dotnet run

# 5. Testing and Validation
Testing the Config Server
Access the Config Server health endpoint:

Go to http://localhost:5016/actuator/health.
It should return a health status.
Check the startup log:

Make sure that Config Server is logging correctly in Eureka.
Testing the Product Catalog
Check the Swagger UI:

Go to http://localhost:<port>/swagger to validate Swagger.
Make sure that the Product Catalog is registering in Eureka:

Check in the Eureka dashboard that the service is listed.
# 6. Possible errors and solutions
Error 404 when accessing /actuator/health: Check the appsettings.json settings and make sure that actuator endpoints are enabled.
Eureka registration problems: Check that Eureka is correctly configured and accessible at the URL provided.

#7. Final considerations
This architecture using .NET and Netflix's Eureka Server offers a robust solution for configuration management and service discovery in distributed environments. The implementation is modular, allowing you to easily add new services to the system and centralize configurations on the Config Server.
