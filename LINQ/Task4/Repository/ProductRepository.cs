using Task4.Model;

namespace Task4.Repository
{
    public class ProductRepository
    {
        private List<Product> _productList = new List<Product>();

        public void AddProduct(Product product)
        {
            _productList.Add(product);
        }

        public List<Product> GetProductList() => _productList;
    }
}
