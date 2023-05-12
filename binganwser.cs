using System;
using System.Collections.Generic;

namespace StoreManagement
{
    public class Item
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Company { get; set; }
        public int Year { get; set; }
        public string ProductType { get; set; }

        public Item(string code, string name, DateTime expiryDate, string company, int year, string productType)
        {
            Code = code;
            Name = name;
            ExpiryDate = expiryDate;
            Company = company;
            Year = year;
            ProductType = productType;
        }
    }

    public class Store
    {
        private List<Item> items;

        public Store()
        {
            items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public void DeleteItem(string code)
        {
            items.RemoveAll(x => x.Code == code);
        }

        public void EditItem(string code, Item newItem)
        {
            var index = items.FindIndex(x => x.Code == code);
            if (index != -1)
                items[index] = newItem;
        }

        public List<Item> SearchItems(Func<Item, bool> predicate)
        {
            return items.FindAll(predicate);
        }
    }
}

Sure! Here's an example of how you can organize your store management software in a 3-layer model with a web interface and data stored on a file:

1. **Data Access Layer**: This layer is responsible for reading and writing data to and from the file. You can use a library like `System.IO` to read and write data to a file in C#.

```csharp
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace StoreManagement
{
    public class DataAccess
    {
        private string filePath;

        public DataAccess(string filePath)
        {
            this.filePath = filePath;
        }

        public List<Item> LoadData()
        {
            if (!File.Exists(filePath))
                return new List<Item>();

            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Item>>(json);
        }

        public void SaveData(List<Item> items)
        {
            var json = JsonConvert.SerializeObject(items);
            File.WriteAllText(filePath, json);
        }
    }
}
```

2. **Business Logic Layer**: This layer is responsible for implementing the business logic of your application, such as adding, deleting, editing and searching for items.

```csharp
using System;
using System.Collections.Generic;

namespace StoreManagement
{
    public class Store
    {
        private DataAccess dataAccess;
        private List<Item> items;

        public Store(string filePath)
        {
            dataAccess = new DataAccess(filePath);
            items = dataAccess.LoadData();
        }

        public void AddItem(Item item)
        {
            items.Add(item);
            dataAccess.SaveData(items);
        }

        public void DeleteItem(string code)
        {
            items.RemoveAll(x => x.Code == code);
            dataAccess.SaveData(items);
        }

        public void EditItem(string code, Item newItem)
        {
            var index = items.FindIndex(x => x.Code == code);
            if (index != -1)
                items[index] = newItem;

            dataAccess.SaveData(items);
        }

        public List<Item> SearchItems(Func<Item, bool> predicate)
        {
            return items.FindAll(predicate);
        }
    }
}
```

3. **Presentation Layer**: This layer is responsible for presenting the data to the user through a web interface. You can use a web framework like ASP.NET to create a web interface for your application.

Here's an example of how you can create a simple web page to add an item to the store:

```html
<!DOCTYPE html>
<html>
<head>
    <title>Add Item</title>
</head>
<body>
    <h1>Add Item</h1>
    <form action="/addItem" method="post">
        <label for="code">Code:</label><br>
        <input type="text" id="code" name="code"><br>
        <label for="name">Name:</label><br>
        <input type="text" id="name" name="name"><br>
        <label for="expiryDate">Expiry Date:</label><br>
        <input type="date" id="expiryDate" name="expiryDate"><br>
        <label for="company">Company:</label><br>
        <input type="text" id="company" name="company"><br>
        <label for="year">Year:</label><br>
        <input type="number" id="year" name="year"><br>
        <label for="productType">Product Type:</label><br>
        <input type="text" id="productType" name="productType"><br><br>
        <input type="submit" value="Submit">
    </form> 
</body>
</html>
```

In your ASP.NET application, you can handle the form submission in your controller:

```csharp
using Microsoft.AspNetCore.Mvc;
using StoreManagement;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private Store store;

        public HomeController()
        {
            store = new Store("data.json");
