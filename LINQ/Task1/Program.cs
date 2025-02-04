using Task1.Model;
using ConsoleTables;
using Task1.Repository;

public class Program
{
    
    static void Main()
    {
        ProductRepository productRepository = new ProductRepository();

        productRepository.AddProduct(new Product("Phone", 1, 200, "Electronics"));
        productRepository.AddProduct(new Product("Apple", 2, 20, "Food"));
        productRepository.AddProduct(new Product("Tablet", 3, 400, "Electronics"));
        productRepository.AddProduct(new Product("Laptop", 4, 450, "Electronics"));
        productRepository.AddProduct(new Product("Ball", 5, 20, "Sports"));
        productRepository.AddProduct(new Product("Play Station", 6, 1000, "Electronics"));
        productRepository.AddProduct(new Product("Gaming Laptop", 7, 700, "Electronics"));
        productRepository.AddProduct(new Product("Pizza", 8, 120, "Food"));

        var products = productRepository.GetProductList().Where((product) => product.ProductPrice < 500 && product.ProductCategory.Equals("Electronics") );
        
        var productsNameAndPrice = products.Select(product => (product.ProductName,product.ProductPrice))
            .OrderByDescending(product => product.ProductPrice);
        
        ConsoleTable filteredTable = new ConsoleTable("Product Name", "Product Price");
        foreach (var product in productsNameAndPrice)
        {
            filteredTable.AddRow(product.ProductName, product.ProductPrice);         
        }

        Console.WriteLine("The products after filtering in descending order of Product Price : ");
        filteredTable.Write();

        var avgPrice = productsNameAndPrice.Average(product => product.ProductPrice);
        Console.WriteLine($"\nThe average of the product prices is equal to {avgPrice}.");

        Console.ReadKey();
    }
}
