using Task5.Model;

namespace Task5.Repository
{
    public class ProductRepository<T>
    {
        private List<T> _productList = new List<T>();

        public void AddProduct(T product)
        {
            _productList.Add(product);
        }

        public List<T> GetProductList() => _productList;
    }
}
