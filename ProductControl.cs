public class ProductsController : Controller
{
    private StoreManager storeManager;

    public ProductsController()
    {
        storeManager = new StoreManager();
        storeManager.LoadFromFile("products.txt");
    }

    public IActionResult Index()
    {
        List<Product> products = storeManager.SearchProducts(p => true);
        return View(products);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Product product)
    {
        storeManager.AddProduct(product);
        storeManager.SaveToFile("products.txt");
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int code)
    {
        Product product = storeManager.SearchProducts(p => p.Code == code).FirstOrDefault();
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    [HttpPost]
    public IActionResult Edit(int code, Product product)
    {
        storeManager.EditProduct(code, product);
        storeManager.SaveToFile("products.txt");
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int code)
    {
        Product product = storeManager.SearchProducts(p => p.Code == code).FirstOrDefault();
        if (product == null)
