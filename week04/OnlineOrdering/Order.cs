using System.Collections.Generic;
using System.Text;

namespace OrderSystem
{
    public class Order
    {
        private readonly List<Product> _products;
        private readonly Customer _customer;

        private const decimal UsaShipping = 5m;
        private const decimal InternationalShipping = 35m;

        public Order(Customer customer)
        {
            _customer = customer;
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public decimal CalculateTotalCost()
        {
            decimal total = 0;

            foreach (Product product in _products)
            {
                total += product.GetTotalCost();
            }

            total += _customer.LivesInUSA()
                ? UsaShipping
                : InternationalShipping;

            return total;
        }

        public string GetPackingLabel()
        {
            StringBuilder label = new StringBuilder();

            label.AppendLine("PACKING LABEL");
            label.AppendLine("-------------");

            foreach (Product product in _products)
            {
                label.AppendLine(
                    $"{product.Name} (ID: {product.ProductId})");
            }

            return label.ToString();
        }

        public string GetShippingLabel()
        {
            StringBuilder label = new StringBuilder();

            label.AppendLine("SHIPPING LABEL");
            label.AppendLine("--------------");
            label.AppendLine(_customer.Name);
            label.AppendLine(_customer.Address.GetFullAddress());

            return label.ToString();
        }
    }
}