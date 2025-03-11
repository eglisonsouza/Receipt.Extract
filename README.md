# Receipt Extract Service

## Overview

The Receipt Extract Service is a .NET 8 project designed to extract product information from HTML receipts and send the extracted data to an Azure Service Bus topic. It consists of an Azure Function that processes HTTP requests, a service that handles the extraction logic, and a service that sends messages to the Service Bus.

## Project Structure

- **Receipt.Extract/Services/ReceiptExtract/ReceiptExtractService.cs**: Contains the `ReceiptExtractService` class, which implements the `IReceiptExtractService` interface. This service is responsible for extracting product details from HTML receipts.
- **Receipt.Extract/Services/ServiceBus/ServiceBusProduct.cs**: Contains the `ServiceBusProduct` class, which extends the `ServiceBus` class and implements the `IServiceBus` interface. This service is responsible for sending product details to the Azure Service Bus.
- **Receipt.Extract/ReceiptExtractFunction.cs**: Contains the `ReceiptExtractFunction` class, which is an Azure Function that handles HTTP requests to extract receipt information and send it to the Service Bus.

## Technologies Used

- .NET 8
- C# 12.0
- Azure Functions
- Azure Service Bus
- HtmlAgilityPack
- System.Text.Json

## Installation

1. Clone the repository:
2. Navigate to the project directory:
3. Restore the dependencies:
    
## Configuration

Ensure the following environment variables are set:

- `UrlReceipt`: The base URL for the receipt.
- `CodeReceitp`: The code to append to the receipt URL.
- `NameespaceServiceBus`: The namespace for the Azure Service Bus.
- `TopicName`: The name of the topic in the Azure Service Bus.

## Usage

### Running the Azure Function

1. Start the Azure Function:
2. Make a GET request to the function endpoint with the `numReceipt` query parameter:

### Example
curl -X GET "http://localhost:7071/api/ReceiptExtract?numReceipt=12345"


## Code Overview

### ReceiptExtractService

The `ReceiptExtractService` class is responsible for:

- Fetching the HTML content of the receipt.
- Parsing the HTML to extract product details.
- Returning a list of `Product` objects.

### ServiceBusProduct

The `ServiceBusProduct` class is responsible for:

- Serializing `Product` objects to JSON.
- Sending the serialized product details to the Azure Service Bus.

### ReceiptExtractFunction

The `ReceiptExtractFunction` class is an Azure Function that:

- Handles HTTP GET requests.
- Validates the `numReceipt` query parameter.
- Uses the `ReceiptExtractService` to extract product details.
- Uses the `ServiceBusProduct` to send the extracted product details to the Azure Service Bus.
- Returns the extracted product details as a JSON response.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.


