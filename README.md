Stock Quotation API
A simple ASP.NET Core Web API for managing stock quotations with standard CRUD operations. The API allows users to create, retrieve, update, and delete stock quotations using RESTful endpoints.

Project Overview
This project provides a lightweight stock quotation service with:

In-memory data storage (persists during application lifetime)
API key authentication
Request/response logging
Swagger/OpenAPI documentation
Azure deployment support

Project Structure

StockQuotationApi/
├── Controllers/
│   └── StockQuotesController.cs    # API endpoints for CRUD operations
├── Models/
│   └── StockQuote.cs               # Stock quotation data model
├── Middleware/
│   ├── ApiKeyAuthMiddleware.cs     # API key authentication
│   └── RequestLoggingMiddleware.cs # Request logging
├── Services/
│   └── StockQuoteRepository.cs     # In-memory repository
├── Program.cs                      # Application configuration
└── appsettings.json                # Configuration settings

API Endpoints
Method	Endpoint	                Description
GET	    /api/StockQuotes/{symbol}	Get stock quote by symbol
POST	/api/StockQuotes	        Create a new stock quote
PUT	    /api/StockQuotes	        Update an existing stock quote
DELETE	/api/StockQuotes/{symbol}	Delete a stock quote by symbol

Data Model
A stock quote contains:

    Symbol: 2-4 character stock ticker symbol (required)
    Price: Current stock price (must be positive)
    Quantity: Number of shares (must be positive)
    Timestamp: Time when quote was created/updated (server-controlled)
    Id: Internal identifier (server-controlled)

Authentication
The API uses API key authentication. Include the API key in the request header:

Running Locally
    Clone the repository
    Navigate to the project directory
    Run dotnet restore
    Run dotnet build
    Run dotnet run
    Access Swagger UI at: https://localhost:7223/swagger
