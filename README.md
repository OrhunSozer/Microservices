# Microservices

* In this project, an online course sales platform similar to udemy was developed with microservice architecture.

* In this project, Microservice architecture was established with .Net 5.

* Both synchronous and asynchronous communication was established between microservices.

* OAuth 2.0 and OpenID Connect protocols were used in this microservice architecture.

* The Eventual Consistency model was applied to ensure consistency in databases of microservices.

* Dockerize microservices by creating Docker Compose files.

* Various databases such as Mssql, PostgreSql and MongoDB were installed as containers.

# Catalog Microservice

Our microservice that will be responsible for holding and presenting information about our courses.
* MongoDb (Database)
* One-To-Many/One-To-One relationship
* MongoDb

# Basket Microservice

Our microservice that will be responsible for basket operations.
* RedisDB(Database)

# Discount Microservice

Our microservice that will be responsible for the discount coupons that will be defined to the user.
* PostgreSQL(Database)

# Order Microservice

Our microservice responsible for order processing. Domain Driven Design approach was used in this microservice. MediatR library was used to implement the CQRS design pattern in this microservice.

* Sql Server(Database)
* Domain Driven Design
* CQRS (MediatR Library)

# FakePayment Microservice

Our microservice responsible for payment processing.

# IdentityServer Microservice

Our microservice responsible for keeping user data, generating tokens and refreshtokens.
* Sql Server(Database)

# PhotoStock Microservice

Our microservice responsible for keeping and presenting course photos.

# API Gateway

* Ocelot Library

# Message Broker

* RabbitMQ was used as the message queue system.
* MassTransit library was used to communicate with RabbitMQ.
* RabbitMQ (MassTransit Library)

# Identity Server

* Generating Token / RefreshToken
* Protecting our microservices with Access Token
* Building a structure in accordance with OAuth 2.0 / OpenID Connect protocols

# Asp.Net Core MVC Microservice

The data she received from microservices was shown to the user and our UI microservice that will be responsible for interacting with the user.






