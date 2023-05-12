public class StoreManager
{
    private List<Product> products;

    public StoreManager()
    {
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public void DeleteProduct(int code)
    {
        products.RemoveAll(p => p.Code == code);
    }

    public void EditProduct(int code, Product product)
    {
        int index = products.FindIndex(p => p.Code == code);
        if (index != -1)
        {
            products[index] = product;
        }
    }

    public List<Product> SearchProducts(Func<Product, bool> predicate)
    {
        return products.Where(predicate).ToList();
    }

    public void SaveToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (Product product in products)
            {
                writer.WriteLine($"{product.Code},{product.Name},{product.ExpiryDate},{product.ManufacturingCompany},{product.YearOfManufacture},{product.ProductType}");
            }
        }
    }

    public void LoadFromFile(string fileName)
    {
        using (StreamReader reader = new StreamReader(fileName))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] parts = line.Split(',');
                Product product = new Product
                {
                    Code = int.Parse(parts[0]),
                    Name = parts[1],
                    ExpiryDate = DateTime.Parse(parts[2]),
                    ManufacturingCompany = parts[3],
                    YearOfManufacture = int.Parse(parts[4]),
                    ProductType = parts[5]
                };
                products.Add(product);
            }
        }
    }
}
