namespace Task4.Model
{
    /// <summary>
    /// To Store the Product Information
    /// </summary>
    public class Product
    {
        /// <summary>
        /// The name of the product
        /// </summary>
        public string ProductName;

        /// <summary>
        /// The ID of the Product
        /// </summary>
        public int ProductId;

        /// <summary>
        /// The price of the product
        /// </summary>
        public decimal ProductPrice;

        /// <summary>
        /// The category of the product
        /// </summary>
        public string ProductCategory;

        /// <summary>
        /// The constructor block
        /// </summary>
        /// <param name="productId">Id of the product</param>
        /// <param name="productName">Name of the product</param>
        /// <param name="productPrice">Price of the product</param>
        /// <param name="productCategory">Category of the product</param>
        public Product(string productName, int productId, decimal productPrice, string productCategory)
        {        
            ProductName = productName;
            ProductId = productId;
            ProductPrice = productPrice;
            ProductCategory = productCategory;
        }
    }
}
