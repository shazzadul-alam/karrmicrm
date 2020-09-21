using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogisticManagement.DataModels
{
    public class SaleOrderDto
    {
        public string RelatedSaleReqNumber { get; set; }
        public int SupplierId { get; set; }
        public int ServiceId { get; set; }
        public int ClientId { get; set; }
        public string ConsumerCode { get; set; }

        public int ProductCode { get; set; }
        public Nullable<int> ProductColorId { get; set; }
        public string RelatedRefCode { get; set; }
        public string ProductSize { get; set; }
        public string ProductRemarks { get; set; }

        public Nullable<int> SaleOrderedQty { get; set; }
        public Nullable<double> SaleUnitPrice { get; set; }

        public int SaleBillAmount { get; set; }
      
    }

    public class SaleOrderBillingDto
    {
        public Nullable<double> ShippingCharge { get; set; }
        public Nullable<double> PriceInCurrency { get; set; }
        public Nullable<int> ProductQty { get; set; }
        public Nullable<double> PriceInBDT { get; set; }
        public Nullable<double> BkashCharge { get; set; }
        public Nullable<double> CalcAmount { get; set; }
        public Nullable<double> Weight { get; set; }
        public Nullable<double> ExpressRate { get; set; }
        public Nullable<double> FinalAmount { get; set; }
        public Nullable<double> DiscountAmount { get; set; }
        public Nullable<double> PayableAmount { get; set; }
        public Nullable<double> SaleConversionRate { get; set; }

        public Nullable<double> PurchaseDiscountAmount { get; set; }
        public Nullable<double> PurchaseConversionRate { get; set; }
      

    }
}