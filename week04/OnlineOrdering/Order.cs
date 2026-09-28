using System;
using System.Collections.Generic;

namespace OnlineOrdering
{
    // Integrates line item objects, tracking codes, and global location constraints
    public class Order
    {
        private List<Product> _products;
        private Customer _customer;

        public Order(Customer customer)
        {
            _customer = customer;
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public double CalculateTotalCost()
        {
            double subtotal = 0;
            foreach (Product product in _products)
            {
                subtotal += product.GetTotalCost();
            }

            double shippingCost = _customer.IsCustomerInUSA() ? 5.00 : 35.00;
            return subtotal + shippingCost;
        }

        public string GetPackingLabel()
        {
            string label = "--- PACKING LABEL ---\n";
            foreach (Product product in _products)
            {
                label += $"- Item: {product.GetName()} (ID: {product.GetProductId()})\n";
            }
            return label.TrimEnd();
        }

        public string GetShippingLabel()
        {
            string label = "--- SHIPPING LABEL ---\n";
            label += $"Customer Name: {_customer.GetName()}\n";
            label += $"Address:\n{_customer.GetAddress().GetFormattedAddress()}";
            return label;
        }
    }
}
