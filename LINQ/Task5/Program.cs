using Task5;
using Task5.Model;
using Task5.Repository;
using ConsoleTables;

public class Program
{
    static void Main()
    {
        ProductRepository<Product> productRepository = new ProductRepository<Product> ();
        QueryBuilder<Product> queryBuilder = new QueryBuilder<Product> (productRepository.GetProductList());

        productRepository.AddProduct(new Product("Phone", 7, 200, "Electronics"));
        productRepository.AddProduct(new Product("Apple", 5, 20, "Food"));
        productRepository.AddProduct(new Product("Tablet", 3, 400, "Electronics"));
        productRepository.AddProduct(new Product("Laptop", 4, 450, "Electronics"));
        productRepository.AddProduct(new Product("Ball", 2, 20, "Sports"));
        productRepository.AddProduct(new Product("Play Station", 6, 1000, "Electronics"));
        productRepository.AddProduct(new Product("Gaming Laptop", 1, 700, "Electronics"));
        productRepository.AddProduct(new Product("Pizza", 8, 120, "Food"));

        Product product1 = new Product("Pizza", 8, 120, "Food");
        var filteredList = queryBuilder.
            SortBy<int>(p => p.ProductId).
            Filter(p => p.ProductName.Contains('a')).
            Execute();
        //Console.WriteLine(product1.ProductName.GetType());

        ConsoleTable filteredTable = new ConsoleTable("Product Name", "Product ID", "Product Price", "Product Category");
        foreach (var filteredProduct in filteredList)
        {
            filteredTable.AddRow(filteredProduct.ProductName, filteredProduct.ProductId, filteredProduct.ProductPrice, filteredProduct.ProductCategory);
        }
        filteredTable.Write();

        ConsoleTable filteredTable1 = new ConsoleTable("Product Name", "Product ID", "Product Price", "Product Category");
        //foreach (var filteredProduct in filteredList1)
        //{
        //    filteredTable1.AddRow(filteredProduct.ProductName, filteredProduct.ProductId, filteredProduct.ProductPrice, filteredProduct.ProductCategory);
        //}
        //filteredTable1.Write();

        Console.ReadKey();
    }
}