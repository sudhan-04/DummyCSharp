using Task4.Model;
using ConsoleTables;
using Task4.Repository;

public class Program
{

    static void Main()
    {
        ProductRepository productRepository = new ProductRepository();

        productRepository.AddProduct(new Product("Story", 1, 200, "Books"));
        productRepository.AddProduct(new Product("Apple", 2, 20, "Food"));
        productRepository.AddProduct(new Product("AutoBiography", 3, 400, "Books"));
        productRepository.AddProduct(new Product("Comics", 4, 450, "Books"));
        productRepository.AddProduct(new Product("Ball", 5, 20, "Sports"));
        productRepository.AddProduct(new Product("Study", 6, 1000, "Books"));
        productRepository.AddProduct(new Product("Fiction", 7, 700, "Books"));
        productRepository.AddProduct(new Product("Pizza", 8, 120, "Food"));

        var booksCategoryProducts = productRepository.GetProductList().Where(product => product.ProductCategory.Equals("Books"))
            .OrderBy(books => books.ProductPrice);

        ConsoleTable filteredTable = new ConsoleTable("Product Name", "Product ID", "Product Price", "Product Category");
        foreach (var book in booksCategoryProducts)
        {
            filteredTable.AddRow(book.ProductName, book.ProductId, book.ProductPrice, book.ProductCategory);
        }
        filteredTable.Write();

        Console.ReadKey();
    }
}