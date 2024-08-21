

using DocumentFormat.OpenXml.Bibliography;
using System;

namespace SmartFlow.Common
{
    public static class GlobalVariables
    {

        public static int currencyidglobal = 0;
        public static string currencynameglobal = null;
        public static string currencysymbolglobal = null;
        public static float currencyconversionrateglobal = 0;

        public static int saletypeidglobal = 0;
        public static string saletypenameglobal = null;
        public static bool saletypeistaxable = false;

        public static int purchasetypeidglobal = 0;
        public static string purchasetypenameglobal = null;
        public static bool purchasetypeistaxable = false;

        public static int salespersonidglobal = 0;
        public static string salespersonnameglobal = null;

        public static int warehouseidglobal = 0;
        public static string warehousenameglobal = null;

        public static int supplieridglobal = 0;
        public static string suppliernameglobal = null;
        public static string suppliercodeglobal = null;

        public static int accountidglobal = 0;
        public static int accountheadidglobal = 0;
        public static string accountnameglobal = null;

        public static int customeridglobal = 0;
        public static string customernameglobal = null;
        public static string customercodeglobal = null;
        public static string customermobileglobal = null;
        public static string customerrefrencegloba = null;

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
        public static bool productconditionglobal = false;

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
    }
}
