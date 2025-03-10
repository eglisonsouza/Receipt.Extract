using Receipt.Extract.Models;

namespace Receipt.Extract.Services
{
    public interface IInvoiceExtractService
    {
        List<Product> Extract(string numReceipt);
    }
}