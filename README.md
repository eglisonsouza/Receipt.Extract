# Receipt Extract Service

## Overview

The Receipt Extract Service is a .NET 8 project designed to extract product information from HTML receipts. It consists of an Azure Function that processes HTTP requests and a service that handles the extraction logic.

## Project Structure

- **Receipt.Extract/Services/InvoiceExtractService.cs**: Contains the `InvoiceExtractService` class, which implements the `IInvoiceExtractService` interface. This service is responsible for extracting product details from HTML receipts.
- **Receipt.Extract/ReceiptExtractFunction.cs**: Contains the `ReceiptExtractFunction` class, which is an Azure Function that handles HTTP requests to extract receipt information.

## Technologies Used

- .NET 8
- C# 12.0
- Azure Functions
- HtmlAgilityPack

## Installation

1. Clone the repository:
2. Navigate to the project directory:
3. Restore the dependencies:
    
## Configuration

Ensure the following environment variables are set:

- `UrlReceipt`: The base URL for the receipt.
- `CodeReceitp`: The code to append to the receipt URL.

## Usage

### Running the Azure Function

1. Start the Azure Function:
2. Make a GET request to the function endpoint with the `numReceipt` query parameter:

### Example
curl -X GET "http://localhost:7071/api/ReceiptExtract?numReceipt=12345"


## Code Overview

### InvoiceExtractService

The `InvoiceExtractService` class is responsible for:

- Fetching the HTML content of the receipt.
- Parsing the HTML to extract product details.
- Returning a list of `Product` objects.

### ReceiptExtractFunction

The `ReceiptExtractFunction` class is an Azure Function that:

- Handles HTTP GET requests.
- Validates the `numReceipt` query parameter.
- Uses the `InvoiceExtractService` to extract product details.
- Returns the extracted product details as a JSON response.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
