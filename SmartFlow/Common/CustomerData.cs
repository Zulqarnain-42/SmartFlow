using System;

namespace SmartFlow.Common
{
    public class CustomerData : EventArgs
    {
        public string CustomerName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerMobile { get; set; }

        public string CustomerCompanyName { get; set; }

        public CustomerData(int id, string name, string code, string companyName,string mobile)
        {
            CustomerId = id;
            CustomerName = name;
            CustomerCode = code;
            CustomerCompanyName = companyName;
            CustomerMobile = mobile;
        }
    }
}
