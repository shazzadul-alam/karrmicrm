//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LogisticManagement.Models
{
    using System;
    
    public partial class proc_SOBreakdownByDateRange_Result
    {
        public int ProductSale { get; set; }
        public Nullable<int> bKashCharge { get; set; }
        public int ExpressCharge { get; set; }
        public int CustomCharge { get; set; }
        public int CourierCharge { get; set; }
        public int SaleDiscount { get; set; }
    }
}