namespace OrderSystem
{
    public class Product
    {
        public string Name { get; }
        public string ProductId { get; }
        public decimal PricePerUnit { get; }
        public int Quantity { get; }

        public Product(
            string name,
            string productId,
            decimal pricePerUnit,
            int quantity)
        {
            Name = name;
            ProductId = productId;
            PricePerUnit = pricePerUnit;
            Quantity = quantity;
        }

        public decimal GetTotalCost()
        {
            return PricePerUnit * Quantity;
        }
    }
}