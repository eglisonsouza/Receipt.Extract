using HtmlAgilityPack;
using Receipt.Extract.Extensions;
using Receipt.Extract.Models;

namespace Receipt.Extract.Services.ReceiptExtract
{
    public class ReceiptExtractService : IReceiptExtractService
    {
        private readonly List<Product> Products;
        private readonly string UrlReceitp;
        private readonly string CodeReceitp;

        public ReceiptExtractService()
        {
            Products = [];
            UrlReceitp = Environment.GetEnvironmentVariable("UrlReceipt") ?? string.Empty;
            CodeReceitp = Environment.GetEnvironmentVariable("CodeReceitp") ?? string.Empty;
        }

        public List<Product> Extract(string numReceipt)
        {
            HtmlDocument htmlDoc = RequestHtml($"{UrlReceitp}{numReceipt}{CodeReceitp}");

            foreach (var product in IgnoreText(GetProducts(htmlDoc)))
            {
                var AttributesProduct = IgnoreText(GetAtributesProduct(product)).ToList();

                var nameProduct = AttributesProduct[0].InnerText;
                var codeProduct = AttributesProduct[1].InnerText.CleanCode();
                var quantityProduct = AttributesProduct[2].InnerText.CleanQuantity();
                var unityProduct = AttributesProduct[3].InnerText.CleanUnity();
                var valueProduct = AttributesProduct[4].InnerText.CleanValue();

                Products.Add(new Product(nameProduct, codeProduct, quantityProduct, unityProduct, valueProduct));
            }

            return Products;
        }

        private static HtmlDocument RequestHtml(string url)
        {
            return new HtmlWeb().Load(url);
        }

        private static IEnumerable<HtmlNode> GetProducts(HtmlDocument html)
        {
            var tbody = html.GetElementbyId("tabResult");

            return tbody.ChildNodes.ToList().Where(n => n.Name.Equals("tr")).ToList();
        }

        private static IEnumerable<HtmlNode> IgnoreText(IEnumerable<HtmlNode> nodes)
        {
            return nodes.ToList().Where(n => !n.Name.Equals("#text"));
        }

        private static IEnumerable<HtmlNode> GetAtributesProduct(HtmlNode product)
        {
            return IgnoreTextAndBr(IgnoreText(product.ChildNodes).First().ChildNodes);
        }

        private static IEnumerable<HtmlNode> IgnoreTextAndBr(IEnumerable<HtmlNode> nodes)
        {
            return nodes.ToList().Where(n => !n.Name.Equals("br"));
        }
    }
}
