using System;

namespace SmartFlow.Common
{
    public class ProductData : EventArgs
    {
        public string ProductName { get; set; }
        public string ProductMfr { get; set; }
        public int ProductId { get; set; }
        public float ProductPrice { get; set; }
        public string ProductUPC { get; set; }
        public string ProductBarcode { get; set; }

        public ProductData(int id, string mfr, string productname, float productPrice, string productUPC, string productBarcode)
        {
            ProductId = id;
            ProductMfr = mfr;
            ProductName = productname;
            ProductPrice = productPrice;
            ProductUPC = productUPC;
            ProductBarcode = productBarcode;
        }

    }
}
