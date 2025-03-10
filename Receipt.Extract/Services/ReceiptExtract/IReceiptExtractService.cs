using Receipt.Extract.Models;

namespace Receipt.Extract.Services.ReceiptExtract
{
    public interface IReceiptExtractService
    {
        List<Product> Extract(string numReceipt);
    }
}