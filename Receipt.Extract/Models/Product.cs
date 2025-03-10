namespace Receipt.Extract.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Quantity { get; set; }
        public string Unity { get; set; }
        public string Value { get; set; }

        public Product(string name, string code, string quantity, string unity, string value)
        {
            Name = name;
            Code = code;
            Quantity = quantity;
            Unity = unity;
            Value = value;
        }
    }
}
