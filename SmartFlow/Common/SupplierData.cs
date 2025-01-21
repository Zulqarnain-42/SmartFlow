using System;

namespace SmartFlow.Common
{
    public class SupplierData : EventArgs
    {
        public string SupplierName { get; set; }
        public int SupplierId { get; set; }
        public string SupplierCode {  get; set; }
        public string SupplierCompanyName { get; set; }

        public SupplierData(int id, string name, string code, string companyName)
        {
            SupplierId = id;
            SupplierName = name;
            SupplierCode = code;
            SupplierCompanyName = companyName;
        }
    }
}
