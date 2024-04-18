# Enviro365Assessment_Grad_DOTNET_version

## Overview

This is a RESTful API developed for Waste Management, a leading environmental consulting firm. The API facilitates waste
data processing for clients, enabling them to add, update, delete and retrieve waste data through simple API requests,
and save the data in the database.

## Technology Stack

- C#
- .NET Core
- Entity Framework Core
- JetBrains Rider 2024.1
- xUnit
- Postgres (PostgreSQL database)
- Docker
- Docker Compose
- Swagger

## Setup and Installation

1. Clone the repository.
2. Open the project in JetBrains Rider 2024.1 or any other .NET compatible IDE.
3. Run the application.

## API Endpoints

The API consists of several endpoints to facilitate waste data management. Detailed documentation for each endpoint,
including request and response formats, will be provided in the subsequent sections.


![img.png](img.png)



### Get a waste by id

- Method: GET
- Path: `/api/waste/{id}`
- Parameters: `id` (path parameter)
- Response: A `Waste` object

### Get list of wastes by category

- Method: GET
- Path: `/api/waste/category/{category}`
- Parameters: `category` (path parameter)
- Response: A list of `Waste` object

### Get all wastes

- Method: GET
- Path: `/api/waste`
- Response: A list of `Waste` objects

### Add a waste

- Method: POST
- Path: `/api/waste/save`
- Parameters: `waste` (request body)
- Response: A `Waste` object

### Update a waste

- Method: PUT
- Path: `/api/waste/update`
- Parameters: `waste` (request body)
- Response: A `Waste` object

### Delete a waste by id

- Method: DELETE
- Path: `/api/waste/{id}`
- Parameters: `id` (path parameter)
- Response: A string message indicating the deletion status

### Delete a list waste by category

- Method: DELETE
- Path: /api/waste/category/{category}
- Parameters: category (path parameter)
- Response: A string message indicating the deletion status

## Error Handling

The application has a global exception handler that handles all exceptions thrown by the application. It returns a
response with an appropriate HTTP status code and a message describing the error.

## Database

The application uses Entity Framework Core for data access and manipulation.

## Testing

Unit tests have been written to ensure the functionality, reliability, and performance of the API endpoints.

## Contributing

Please read CONTRIBUTING.md for details on our code of conduct, and the process for submitting pull requests to us.

## License

This project is licensed under the MIT License - see the LICENSE.md file for details