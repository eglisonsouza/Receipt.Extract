using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Receipt.Extract.Services.ReceiptExtract;
using Receipt.Extract.Services.ServiceBus;

namespace Receipt.Extract
{
    public class ReceiptExtractFunction
    {
        private readonly ILogger<ReceiptExtractFunction> _logger;
        private readonly IReceiptExtractService _invoiceExtractService;
        private readonly IServiceBus _serviceBus;

        public ReceiptExtractFunction(ILogger<ReceiptExtractFunction> logger, IReceiptExtractService invoiceExtractService, IServiceBus serviceBus)
        {
            _logger = logger;
            _invoiceExtractService = invoiceExtractService;
            _serviceBus = serviceBus;
        }

        [Function("ReceiptExtract")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
        {
            _logger.LogInformation("Starting extract of the receipt");
            var numReceipt = req.Query["numReceipt"];

            if (string.IsNullOrWhiteSpace(numReceipt))
                return new BadRequestObjectResult("numReceipt is required.");

            var products = _invoiceExtractService.Extract(numReceipt);

            _logger.LogInformation("Sending products to topic");

            products.ForEach(product => _serviceBus.SendMessage(product));

            return new OkObjectResult(products);
        }
    }
}
