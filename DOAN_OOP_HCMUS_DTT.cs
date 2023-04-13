/*
MSSV: 218802**
Đồ án Lập trình hướng đối tượng (OOP) K2-2022-2023 (12/2022 - 04/2023)
*/

Do an LTHDT
Đồ án LTHDT


DEADLINE: 6:00 PM, 19/11/2022


Viết phần mềm quản lý cửa hàng với các chức năng sau:

Thêm, xóa, sửa và tìm kiếm các mặt hàng (mã, tên hàng, hạn dùng, công ty sản xuất, năm sản xuất, loại hàng).
Thêm, xóa, sửa và tìm kiếm các loại hàng.
Thêm, xóa, sửa và tìm kiếm các hóa đơn bán hàng
Thêm, xóa, sửa và tìm kiếm các hóa đơn nhập hàng
Thống kê số hàng còn lại trong kho theo từng mặt hàng
Thống kê số hàng cũ đã hết hạn sử dụng

Chú ý:

Làm với giao diện web
Các dữ liệu phải được lưu trữ trên tập tin
Phải tổ chức theo mô hình 3 lớp.
Không nộp chung mã nguồn với môn KTLT được.
File doc tự đánh giá


Hoàn thành

Chưa hoàn thành

Thêm, xóa, sửa và tìm kiếm các mặt hàng (mã, tên hàng, hạn dùng, công ty sản xuất, năm sản xuất, loại hàng)
Ghi rõ tính năng hoàn thành


...
#Add Item
public void AddItem(string code, string itemName, DateTime expiryDate, string manufacturingCompany, int yearOfManufacture, string productType)
{
    Item newItem = new Item();
    newItem.Code = code;
    newItem.ItemName = itemName;
    newItem.ExpiryDate = expiryDate;
    newItem.ManufacturingCompany = manufacturingCompany;
    newItem.YearOfManufacture = yearOfManufacture;
    newItem.ProductType = productType;

    // Call the ItemRepository class to add the new item to the database
    ItemRepository.AddItem(newItem);
}

#Delete Item
public void DeleteItem(int itemId)
{
    // Call the ItemRepository class to delete the item from the database
    ItemRepository.DeleteItem(itemId);
}

#E
public void EditItem(int itemId, string code, string itemName, DateTime expiryDate, string manufacturingCompany, int yearOfManufacture, string productType)
{
    // Call the ItemRepository class to get the item to edit
    Item itemToEdit = ItemRepository.GetItem(itemId);

    // Update the properties of the item with the new values
    itemToEdit.Code = code;
    itemToEdit.ItemName = itemName;
    itemToEdit.ExpiryDate = expiryDate;
    itemToEdit.ManufacturingCompany = manufacturingCompany;
    itemToEdit.YearOfManufacture = yearOfManufacture;
    itemToEdit.ProductType = productType;

    // Call the ItemRepository class to save the changes to the database
    ItemRepository.EditItem(itemToEdit);
}


public List<Item> SearchItems(string searchQuery)
{
    // Call the ItemRepository class to search for items that match the search query
    List<Item> searchResults = ItemRepository.SearchItems(searchQuery);

    return searchResults;
}

here are the functions for managing the row types

public void AddRowType(string rowTypeName, int rowCapacity)
{
    RowType newRowType = new RowType();
    newRowType.RowTypeName = rowTypeName;
    newRowType.RowCapacity = rowCapacity;

    // Call the RowTypeRepository class to add the new row type to the database
    RowTypeRepository.AddRowType(newRowType);
}

public void DeleteRowType(int rowTypeId)
{
    // Call the RowTypeRepository class to delete the row type from the database
    RowTypeRepository.DeleteRowType(rowTypeId);
}



public void DeleteRowType(int rowTypeId)
{
    // Call the RowTypeRepository class to delete the row type from the database
    RowTypeRepository.DeleteRowType(rowTypeId);
}


public void EditRowType(int rowTypeId, string rowTypeName, int rowCapacity)
{
    // Call the RowTypeRepository class to get the row type to edit
    RowType rowTypeToEdit = RowTypeRepository.GetRowType(rowTypeId);

    // Update the properties of the row type with the new values
    rowTypeToEdit.RowTypeName = rowTypeName;
    rowTypeToEdit.RowCapacity = rowCapacity;

    // Call the RowTypeRepository class to save the changes to the database
    RowTypeRepository.EditRowType(rowTypeToEdit);
}

public List<RowType> SearchRowTypes(string searchQuery)
{
    // Call the RowTypeRepository class to search for row types that match the search query
    List<RowType> searchResults = RowTypeRepository.SearchRowTypes(searchQuery);

    return searchResults;
}

here are the functions for managing sales invoices:

public void AddSalesInvoice(string customerName, DateTime invoiceDate, List<SalesInvoiceItem> invoiceItems)
{
    SalesInvoice newSalesInvoice = new SalesInvoice();
    newSalesInvoice.CustomerName = customerName;
    newSalesInvoice.InvoiceDate = invoiceDate;
    newSalesInvoice.InvoiceItems = invoiceItems;

    // Call the SalesInvoiceRepository class to add the new sales invoice to the database
    SalesInvoiceRepository.AddSalesInvoice(newSalesInvoice);
}


public void DeleteSalesInvoice(int salesInvoiceId)
{
    // Call the SalesInvoiceRepository class to delete the sales invoice from the database
    SalesInvoiceRepository.DeleteSalesInvoice(salesInvoiceId);
}

public void EditSalesInvoice(int salesInvoiceId, string customerName, DateTime invoiceDate, List<SalesInvoiceItem> invoiceItems)
{
    // Call the SalesInvoiceRepository class to get the sales invoice to edit
    SalesInvoice salesInvoiceToEdit = SalesInvoiceRepository.GetSalesInvoice(salesInvoiceId);

    // Update the properties of the sales invoice with the new values
    salesInvoiceToEdit.CustomerName = customerName;
    salesInvoiceToEdit.InvoiceDate = invoiceDate;
    salesInvoiceToEdit.InvoiceItems = invoiceItems;

    // Call the SalesInvoiceRepository class to save the changes to the database
    SalesInvoiceRepository.EditSalesInvoice(salesInvoiceToEdit);
}

public List<SalesInvoice> SearchSalesInvoices(string searchQuery)
{
    // Call the SalesInvoiceRepository class to search for sales invoices that match the search query
    List<SalesInvoice> searchResults = SalesInvoiceRepository.SearchSalesInvoices(searchQuery);

    return searchResults;
}



here are the functions for managing incoming invoices

public void AddIncomingInvoice(string supplierName, DateTime invoiceDate, List<IncomingInvoiceItem> invoiceItems)
{
    IncomingInvoice newIncomingInvoice = new IncomingInvoice();
    newIncomingInvoice.SupplierName = supplierName;
    newIncomingInvoice.InvoiceDate = invoiceDate;
    newIncomingInvoice.InvoiceItems = invoiceItems;

    // Call the IncomingInvoiceRepository class to add the new incoming invoice to the database
    IncomingInvoiceRepository.AddIncomingInvoice(newIncomingInvoice);
}
  
  public void DeleteIncomingInvoice(int incomingInvoiceId)
{
    // Call the IncomingInvoiceRepository class to delete the incoming invoice from the database
    IncomingInvoiceRepository.DeleteIncomingInvoice(incomingInvoiceId);
}


public void DeleteIncomingInvoice(int incomingInvoiceId)
{
    // Call the IncomingInvoiceRepository class to delete the incoming invoice from the database
    IncomingInvoiceRepository.DeleteIncomingInvoice(incomingInvoiceId);
}

public void EditIncomingInvoice(int incomingInvoiceId, string supplierName, DateTime invoiceDate, List<IncomingInvoiceItem> invoiceItems)
{
    // Call the IncomingInvoiceRepository class to get the incoming invoice to edit
    IncomingInvoice incomingInvoiceToEdit = IncomingInvoiceRepository.GetIncomingInvoice(incomingInvoiceId);

    // Update the properties of the incoming invoice with the new values
    incomingInvoiceToEdit.SupplierName = supplierName;
    incomingInvoiceToEdit.InvoiceDate = invoiceDate;
    incomingInvoiceToEdit.InvoiceItems = invoiceItems;

    // Call the IncomingInvoiceRepository class to save the changes to the database
    IncomingInvoiceRepository.EditIncomingInvoice(incomingInvoiceToEdit);
}

public List<IncomingInvoice> SearchIncomingInvoices(string searchQuery)
{
    // Call the IncomingInvoiceRepository class to search for incoming invoices that match the search query
    List<IncomingInvoice> searchResults = IncomingInvoiceRepository.SearchIncomingInvoices(searchQuery);

    return searchResults;
}


 #Statistics of remaining goods in stock by item
 public List<ItemStock> GetRemainingStockByItem()
{
    // Call the ItemRepository class to retrieve all items
    List<Item> allItems = ItemRepository.GetAllItems();

    // Create a new list to store the remaining stock of each item
    List<ItemStock> remainingStockByItem = new List<ItemStock>();

    // Loop through all items and calculate the remaining stock for each one
    foreach (Item item in allItems)
    {
        // Call the StockRepository class to get the total quantity of this item in stock
        int totalQuantityInStock = StockRepository.GetTotalQuantityInStockByItem(item.ItemCode);

        // Calculate the remaining stock of this item
        int remainingStock = totalQuantityInStock - item.MinimumStockLevel;

        // Create a new ItemStock object to store the remaining stock of this item
        ItemStock itemStock = new ItemStock();
        itemStock.ItemCode = item.ItemCode;
        itemStock.ItemName = item.ItemName;
        itemStock.RemainingStock = remainingStock;

        // Add the itemStock object to the list of remaining stock by item
        remainingStockByItem.Add(itemStock);
    }

    // Return the list of remaining stock by item
    return remainingStockByItem;
}



  
