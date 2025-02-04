using Task2.Model;

namespace Task2.Repository
{
    public class SupplierRepository
    {
        private List<Supplier> _supplierList = new List<Supplier>();

        public void AddSupplier(Supplier supplier)
        {
            _supplierList.Add(supplier);
        }

        public List<Supplier> GetSupplierList() => _supplierList;
    }
}
