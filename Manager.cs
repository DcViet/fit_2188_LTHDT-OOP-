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

public class StoreManager
{
    private List<Product> products;
    private List<RowType> rowTypes;

    public StoreManager()
    {
        products = new List<Product>();
        rowTypes = new List<RowType>();
    }

    // Methods for managing products

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

    // Methods for managing row types

    public void AddRowType(RowType rowType)
    {
        rowTypes.Add(rowType);
    }

    public void DeleteRowType(int id)
    {
        rowTypes.RemoveAll(r => r.Id == id);
    }

    public void EditRowType(int id, RowType rowType)
    {
        int index = rowTypes.FindIndex(r => r.Id == id);
        if (index != -1)
        {
            rowTypes[index] = rowType;
        }
    }

    public List<RowType> SearchRowTypes(Func<RowType, bool> predicate)
    {
        return rowTypes.Where(predicate).ToList();
    }

    // Methods for saving and loading data to/from file

    public void SaveToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (Product product in products)
            {
                writer.WriteLine($"{product.Code},{product.Name},{product.ExpiryDate},{product.ManufacturingCompany},{product.YearOfManufacture},{product.ProductType}");
            }
        }
        using (StreamWriter writer = new StreamWriter("rowtypes.txt"))
        {
            foreach (RowType rowType in rowTypes)
            {
                writer.WriteLine($"{rowType.Id},{rowType.Name}");
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
        using (StreamReader reader = new StreamReader("rowtypes.txt"))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] parts = line.Split(',');
                RowType rowType = new RowType
                {
                    Id = int.Parse(parts[0]),
                    Name = parts[1]
                };
                rowTypes.Add(rowType);
            }
        }
    }
}

public class StoreManager
{
    private List<Product> products;
    private List<RowType> rowTypes;
    private List<SalesInvoice> salesInvoices;

    public StoreManager()
    {
        products = new List<Product>();
        rowTypes = new List<RowType>();
        salesInvoices = new List<SalesInvoice>();
    }

    // Methods for managing products

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

    // Methods for managing row types

    public void AddRowType(RowType rowType)
    {
        rowTypes.Add(rowType);
    }

    public void DeleteRowType(int id)
    {
        rowTypes.RemoveAll(r => r.Id == id);
    }

    public void EditRowType(int id, RowType rowType)
    {
        int index = rowTypes.FindIndex(r => r.Id == id);
        if (index != -1)
        {
            rowTypes[index] = rowType;
        }
    }

    public List<RowType> SearchRowTypes(Func<RowType, bool> predicate)
    {
        return rowTypes.Where(predicate).ToList();
    }

    // Methods for managing sales invoices

    public void AddSalesInvoice(SalesInvoice salesInvoice)
    {
        salesInvoices.Add(salesInvoice);
    }

    public void DeleteSalesInvoice(int invoiceNumber)
    {
        salesInvoices.RemoveAll(si => si.InvoiceNumber == invoiceNumber);
    }

    public void EditSalesInvoice(int invoiceNumber, SalesInvoice salesInvoice)
    {
        int index = salesInvoices.FindIndex(si => si.InvoiceNumber == invoiceNumber);
        if (index != -1)
        {
            salesInvoices[index] = salesInvoice;
        }
    }

    public List<SalesInvoice> SearchSalesInvoices(Func<SalesInvoice, bool> predicate)
    {
        return salesInvoices.Where(predicate).ToList();
    }

    // Methods for saving and loading data to/from file

    public void SaveToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (Product product in products)
            {
                writer.WriteLine($"{product.Code},{product.Name},{product.ExpiryDate},{product.ManufacturingCompany},{product.YearOfManufacture},{product.ProductType}");
            }
        }
        using (StreamWriter writer = new StreamWriter("rowtypes.txt"))
        {
            foreach (RowType rowType in rowTypes)
            {
                writer.WriteLine($"{rowType.Id},{rowType.Name}");
            }
        }
        using (StreamWriter writer = new StreamWriter("salesinvoices.txt"))
        {
            foreach (SalesInvoice salesInvoice in salesInvoices)
            {
                writer.WriteLine($"{salesInvoice.InvoiceNumber},{salesInvoice.CustomerName},{salesInvoice.InvoiceDate}");
                foreach (SalesInvoiceItem item in salesInvoice.Items)
                {
                    writer.WriteLine($"{item.ProductCode},{item.Quantity}");
                }
                writer.WriteLine("END");
            }
        }
    }

    public void LoadFromFile(string fileName)
    {
        using (StreamReader reader = new StreamReader(fileName))
        {
            while (!reader.EndOfStream)
            {
                string

