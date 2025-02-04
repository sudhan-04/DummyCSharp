namespace Task2.Model
{
    public class Supplier
    {      
        public string SupplierName;
        public int SupplierId;
        public int ProductId;

        public Supplier( string supplierName, int supplierId, int productId)
        {         
            this.SupplierName = supplierName;
            this.SupplierId = supplierId;
            this.ProductId = productId;
        }   
    }
}
