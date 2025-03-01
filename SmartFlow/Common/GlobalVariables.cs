

namespace SmartFlow.Common
{
    public class GlobalVariables
    {
        public static decimal productitemwisevatpercentage = 0;
        public static decimal productitemwisevatamount = 0;
        public static decimal producttotalwithvatitemwise = 0;
        public static decimal productcostprice = 0;
        public static decimal productpriceglobal = 0;
        public static decimal productinmeterprice = 0;
        public static decimal productinmeterlength = 0;
        public static string productitemwisedescriptiongloabl = null;
        public static bool isproductdiscounted = false;
        public static bool productdiscounttype = false;
        public static decimal productdiscountamountitemwise = 0;
        public static decimal productfinalamountwithvatanddiscountitemwise = 0;
        public static string availabilitystatus = null;
        public static decimal discountpercentage = 0;
        public static int actualqtyordered = 0;


        //// UNIT VARIABLES
        ///
        public static string unitnameglobal = null;
        public static int unitidglobal = 0;


        //// WAREHOUSE VARIABLES
        ///
        public static int warehouseidglobal = 0;
        public static string warehousenameglobal = null;


        //// TRANSACTION VARIABLES
        ///
        public static bool iscreditglobal = false;
        public static bool isdebitglobal = false;
        public static string shortdescriptionglobal = null;
        public static string transactionsymbol = null;

    }
}
