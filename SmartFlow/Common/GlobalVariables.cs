using System;
using System.Collections.Generic;

namespace SmartFlow.Common
{
    public static class GlobalVariables
    {
        public static int currencyidglobal = 0;
        public static string currencynameglobal = null;
        public static string currencysymbolglobal = null;
        public static float currencyconversionrateglobal = 0;

        public static int warehouseidglobal = 0;
        public static string warehousenameglobal = null;

        public static int supplieridglobal = 0;
        public static string suppliernameglobal = null;
        public static string suppliercodeglobal = null;
        public static string suppliercompanyName = null;

        public static int accountidglobal = 0;
        public static int accountheadidglobal = 0;
        public static string accountnameglobal = null;
        public static string accountcodeglobal = null;

        public static int customeridglobal = 0;
        public static string customernameglobal = null;
        public static string customercodeglobal = null;
        public static string customermobileglobal = null;
        public static string customercompanyname = null;

        public static int productidglobal = 0;
        public static string productnameglobal = null;
        public static string productserialnoglobal = null;
        public static int productserialnoidglobal = 0;
        public static string productmfrglobal = null;
        public static float productpriceglobal = 0;
        public static string productupcglobal = null;
        public static string productbarcodeglobal = null;
        public static string productitemwisedescriptiongloabl = null;
        public static decimal productitemwisevatpercentage = 0;
        public static decimal productitemwisevatamount = 0;
        public static decimal producttotalwithvatitemwise = 0;
        public static bool productdiscounttype = false;
        public static bool isproductdiscounted = false;
        public static decimal productdiscountamountitemwise = 0;
        public static decimal productfinalamountwithvatanddiscountitemwise = 0;
        public static decimal productinmeterprice = 0;
        public static decimal productinmeterlength = 0;
        public static decimal productUnitPrice = 0;
        public static decimal productcostprice = 0;
        public static decimal productstandardprice = 0;
        public static decimal productlowestlength = 0;
        public static decimal productsaleprice = 0;

        public static int unitidglobal = 0;
        public static string unitnameglobal = null;

        public static string invoicespecialnote = null;
            
        public static int stocklocationidglobal = 0;
        public static string stocklocationnameglobal = null;
        public static string stockracknumber = null;

        public static int productinventoryglobal = 0;
        public static string availabilitystatus = null;

        public static bool isdebitglobal = false;
        public static bool iscreditglobal = false;
        public static string shortdescriptionglobal = null;

        public static string employeeNationalityGlobal = null;
        public static string employeeEducationGlobal = null;
        public static DateTime employeedateofjoiningGlobal = DateTime.Now;
        public static string employeeDesignationGlobal = null;
        public static string employeeDepartmentGlobal = null;
        public static string employeeContractTypeGlobal = null;
        public static DateTime employeeContractExpiryGlobal = DateTime.Now;

        public static int roleidglobal = 0;
        public static string rolenameglobal = null;

        public static int currentRowIndex;
        public static int currentCellIndex;
    }

    public class InvoiceItem
    {
        public decimal unitPrice { get; set; }
        public int quantity { get; set; }
        public decimal netAmount { get; set; }
        public decimal vatAmount { get; set; }
        public decimal grossAmount { get; set; }
        public string description { get; set; }
        public string code { get; set; }
        public string serialNumber { get; set; }
        public int vatCode { get; set; }
    }

    public class Invoice
    {
        public string Date { get; set; }
        public string InvoiceNo { get; set; }
        public decimal AmountWithoutTax { get; set; }
        public decimal Tax { get; set; }
        public decimal AmountWithTax { get; set; }
        public List<InvoiceItem> items { get; set; }
    }
}
