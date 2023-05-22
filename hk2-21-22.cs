Certainly! Here's an example of a C# program using ASP.NET Razor Pages that allows you to enter information about a book and calculates its thickness based on the number of pages:

**Book.cs**
```csharp
public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int NumPages { get; set; }
    public double Thickness { get; set; }
}
```

**Index.cshtml.cs**
```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookThicknessCalculator.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Book Book { get; set; }

        public void OnPost()
        {
            double pageThickness = 0.1;  // Thickness of each page in millimeters
            Book.Thickness = Book.NumPages * pageThickness;
        }
    }
}
```

**Index.cshtml**
```html
@page
@model BookThicknessCalculator.Pages.IndexModel
<!DOCTYPE html>
<html>
<head>
    <title>Book Thickness Calculator</title>
</head>
<body>
    <h1>Book Thickness Calculator</h1>

    <form method="post">
        <label>Title:</label>
        <input asp-for="Book.Title" /><br />

        <label>Author:</label>
        <input asp-for="Book.Author" /><br />

        <label>Number of Pages:</label>
        <input asp-for="Book.NumPages" /><br />

        <input type="submit" value="Calculate" />
    </form>

    @if (Model.Book.Thickness > 0)
    {
        <h2>Book Information:</h2>
        <p><strong>Title:</strong> @Model.Book.Title</p>
        <p><strong>Author:</strong> @Model.Book.Author</p>
        <p><strong>Number of Pages:</strong> @Model.Book.NumPages</p>
        <p><strong>Thickness (mm):</strong> @Model.Book.Thickness</p>
    }
</body>
</html>
```

To run this program, create a new ASP.NET Razor Pages project in Visual Studio or your preferred C# development environment. Replace the contents of the respective files (`Book.cs`, `Index.cshtml.cs`, and `Index.cshtml`) with the provided code. Build and run the project, and you will be able to access the book thickness calculator through the generated web page.

On the web page, you can enter the book's title, author, and number of pages. Upon clicking the "Calculate" button, the form will be submitted to the server, and the `OnPost` method in the `IndexModel` class will calculate the book's thickness by multiplying the number of pages by 0.1mm (the thickness of each page). The result will be displayed on the page along with the book's information if the thickness is greater than 0.
