using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Receipt.Extract.Services;

namespace Receipt.Extract
{
    public class ReceiptExtractFunction
    {
        private readonly ILogger<ReceiptExtractFunction> _logger;
        private readonly IInvoiceExtractService _invoiceExtractService;

        public ReceiptExtractFunction(ILogger<ReceiptExtractFunction> logger, IInvoiceExtractService invoiceExtractService)
        {
            _logger = logger;
            _invoiceExtractService = invoiceExtractService;
        }

        [Function("ReceiptExtract")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
        {
            _logger.LogInformation("Starting extract of the receipt");
            var numReceipt = req.Query["numReceipt"];

            if (NumReceiptIsInvalid(numReceipt))
                return new BadRequestObjectResult("numReceipt is required.");

            return new OkObjectResult(_invoiceExtractService.Extract(numReceipt));
        }

        private static bool NumReceiptIsInvalid(string? numReceipt)
        {
            if (string.IsNullOrWhiteSpace(numReceipt))
                return true;

            return false;
        }
    }
}
