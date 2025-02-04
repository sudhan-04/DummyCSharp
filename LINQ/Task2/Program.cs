using Task2.Model;
using ConsoleTables;
using Task2.Repository;

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

        var groupProductsByCategory = productRepository.GetProductList().GroupBy(product => product.ProductCategory);

        var productCountInEachCategory = groupProductsByCategory.Select(product => 
            (product.First().ProductCategory,
            product.Count()));

        ConsoleTable categoryDetails = new ConsoleTable("Product Category", "Product Count");
        foreach (var categoryJoins in productCountInEachCategory)
        {
            categoryDetails.AddRow(categoryJoins.Item1,categoryJoins.Item2 );
        }

        Console.WriteLine("\nThe number of products in each category :");
        categoryDetails.Write();

        var expensiveProductInEachCategory = groupProductsByCategory
            .Select(product => 
            (product.First().ProductCategory, 
            product.MaxBy(product => product.ProductPrice).ProductName, 
            product.MaxBy(product => product.ProductPrice).ProductPrice));

        ConsoleTable expensiveProductDetails = new ConsoleTable("Product Category", "Most Expensive Product Name", "Most Expensive Product Price");
        foreach(var expensiveProduct in expensiveProductInEachCategory)
        {
            expensiveProductDetails.AddRow(expensiveProduct.ProductCategory, expensiveProduct.ProductName, expensiveProduct.ProductPrice);
        }

        Console.WriteLine("\nThe most expensive product details present in each category :");
        expensiveProductDetails.Write();

        SupplierRepository supplierRepository = new SupplierRepository();

        supplierRepository.AddSupplier(new Supplier ("Supplier1", 10, 1) );
        supplierRepository.AddSupplier(new Supplier ("Supplier2", 11, 2) );
        supplierRepository.AddSupplier(new Supplier ("Supplier3", 12, 6) );
        supplierRepository.AddSupplier(new Supplier ("Supplier4", 13, 1) );
        supplierRepository.AddSupplier(new Supplier ("Supplier5", 14, 5) );
        supplierRepository.AddSupplier(new Supplier ("Supplier6", 15, 6) );
        supplierRepository.AddSupplier(new Supplier ("Supplier7", 15, 7) );
        supplierRepository.AddSupplier(new Supplier ("Supplier8", 16, 8) );
        supplierRepository.AddSupplier(new Supplier ("Supplier9", 17, 4) );
        supplierRepository.AddSupplier(new Supplier ("Supplier10", 18, 3) );
        supplierRepository.AddSupplier(new Supplier ("Supplier11", 19, 4) );

        var productAndSupplierJoin = productRepository.GetProductList()
            .GroupJoin(supplierRepository.GetSupplierList(), 
            product => product.ProductId, 
            supplier => supplier.ProductId,
            (product , supplier) => new { supplierName = supplier ,productName = product.ProductName, commonId = product.ProductId });

        Console.WriteLine("\nThe correlation between supplier and products : ");
        foreach (var product in productAndSupplierJoin)
        {
            Console.WriteLine("\nProduct Name : "+product.productName);
            Console.WriteLine("Product ID : "+product.commonId);
            Console.Write("Suppliers : ");
            foreach (var supplier in product.supplierName)
            {
                Console.Write(supplier.SupplierName+", ");
            }
            Console.WriteLine("\n-----------------------------------");
        }
        
        Console.ReadKey();
    }
}
