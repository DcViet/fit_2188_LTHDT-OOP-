using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Initialize the store manager
        var storeManager = new StoreManager();

        // Add some products
        storeManager.AddProduct(new Product("P001", "Product 1", new DateTime(2023, 12, 31), "Manufacturer 1", 2023, "Type A", 10));
        storeManager.AddProduct(new Product("P002", "Product 2", new DateTime(2023, 12, 31), "Manufacturer 2", 2023, "Type B", 20));
        storeManager.AddProduct(new Product("P003", "Product 3", new DateTime(2024, 6, 30), "Manufacturer 3", 2022, "Type A", 5));

        // Search for a product
        var product = storeManager.SearchProductByCode("P001");
        Console.WriteLine(product);

        // Edit a product
        var editedProduct = new Product("P001", "New Product 1", new DateTime(2023, 12, 31), "Manufacturer 1", 2023, "Type A", 15);
        storeManager.EditProduct("P001", editedProduct);

        // Delete a product
        storeManager.DeleteProduct("P003");

        // Add some sales invoices
        storeManager.AddSalesInvoice(new SalesInvoice("INV001", new DateTime(2023, 5, 1), new List<SalesInvoiceItem> {
            new SalesInvoiceItem("P001", 5),
            new SalesInvoiceItem("P002", 10)
        }));

        // Add some incoming invoices
        storeManager.AddIncomingInvoice(new IncomingInvoice("INV001", new DateTime(2023, 5, 1), new List<IncomingInvoiceItem> {
            new IncomingInvoiceItem("P002", 5),
            new IncomingInvoiceItem("P003", 10)
        }));

        // Get the remaining stock by product
        var remainingStockByProduct = storeManager.GetRemainingStockByProduct();
        Console.WriteLine("Remaining stock by product:");
        foreach (var item in remainingStockByProduct)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }

        // Get the number of expired products
        var expiredProductsCount = storeManager.GetExpiredProductsCount();
        Console.WriteLine($"Expired products count: {expiredProductsCount}");
    }
}
