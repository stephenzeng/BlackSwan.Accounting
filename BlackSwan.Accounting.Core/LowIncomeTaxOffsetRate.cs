﻿namespace BlackSwan.Accounting.Core
{
    public class LowIncomeTaxOffsetRate
    {
        public decimal Rate { get; set; }
        public decimal StartAmount { get; set; }
        public decimal FullTaxOffsetAmount { get; set; }
    }
}