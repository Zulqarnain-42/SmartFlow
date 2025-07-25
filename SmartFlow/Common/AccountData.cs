﻿using System;


namespace SmartFlow.Common
{
    public class AccountData : EventArgs
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public int AccountHeadId { get; set; }
        public string AccountCode { get; set; }
        public decimal OpeningBalance { get; set; }

        public AccountData(int id, string name, int headid, string accountCode, decimal openingBalance)
        {
            AccountId = id;
            AccountName = name;
            AccountHeadId = headid;
            AccountCode = accountCode;
            OpeningBalance = openingBalance;
        }
    }
}
