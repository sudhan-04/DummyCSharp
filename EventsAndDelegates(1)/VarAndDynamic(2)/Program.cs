using Newtonsoft.Json;

public class Program
{
    static void Main()
    {
        var stringType = "This must be a string";
        //stringType = 123;

        dynamic dynamicType = "This must be a string";
        dynamicType = 123;

        //UseCase-1 
        //Creating a list of multiple datatype objects
        List<dynamic> dynamicList = new List<dynamic> { 123, "Dynamic List", 12.76, true, (long)123 };
        dynamicList.Add(dynamicType);
        dynamicList.Add((dynamic) stringType);

        //UseCase-2
        //Json File Handling
        List<Product> productList = new List<Product>();
        productList.Add(new Product("Product1",1,100.0));
        productList.Add(new Product("Product2",2,110.0));
        productList.Add(new Product("Product3",3,120.0));
        productList.Add(new Product("Product4",4,130.0));

        File.WriteAllText("TestFile.json", JsonConvert.SerializeObject(productList));
        var dataRead = File.ReadAllText("TestFile.json");

        //If during deserialization, datatype in the json file is not known.
        //Only the developers at the other end knows the datatype.
        //But only the data must be sent, and the file must not be accessible to other developers.
        var deserializedData = JsonConvert.DeserializeObject<dynamic>(dataRead);

        //Other user/Developer can access the data sent and perform operations on them.
        foreach (var item in deserializedData)
        {
            Console.WriteLine($"Name: {item.Name}, Id: {item.Id}, Price: {item.Price}");
        }

    }
}

public class Product
{
    public string Name { get; set; }
    public int Id { get; set; }
    public double Price { get; set; }

    public Product(string Name, int Id, double Price) 
    {
        this.Name = Name;
        this.Id = Id;
        this.Price = Price;
    }
}
