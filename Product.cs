public class Product
{
    public int Code { get; set; }
    public string Name { get; set; }
    public DateTime ExpiryDate { get; set; }
    public string ManufacturingCompany { get; set; }
    public int YearOfManufacture { get; set; }
    public string ProductType { get; set; }
}

public class RowType
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public Dictionary<string, int> GetRemainingStockByProduct()
{
    var remainingStock = products.GroupBy(p => p.Name)
                                  .ToDictionary(g => g.Key, g => g.Sum(p => p.Quantity));
    return remainingStock;
}

public int GetExpiredProductsCount()
{
    var expiredProductsCount = products.Count(p => p.ExpiryDate < DateTime.Now);
    return expiredProductsCount;
}
