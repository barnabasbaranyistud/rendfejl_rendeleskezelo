using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendeleskezelo
{
    public class OrderDTO
    {
        public class OrderResponse
        {
            public List<Coupon> Coupons { get; set; }
            public List<OrderItem> Items { get; set; }
            public List<Notes> Notes { get; set; }
            public List<Package> Packages { get; set; }
            public OrderDetails Content { get; set; }
        }

        public class Coupon
        {
            // Add properties if Coupons has data in the future
        }

        public class OrderItem
        {
            public int Id { get; set; }
            public int StoreId { get; set; }
            public DateTime LastUpdatedUtc { get; set; }
            public decimal BasePricePerItem { get; set; }
            public string OrderBvin { get; set; }
            public string ProductId { get; set; }
            public string VariantId { get; set; }
            public string ProductName { get; set; }
            public string ProductSku { get; set; }
            public string ProductShortDescription { get; set; }
            public int Quantity { get; set; }
            public int QuantityReturned { get; set; }
            public int QuantityShipped { get; set; }
            public decimal ShippingPortion { get; set; }
            public string StatusCode { get; set; }
            public string StatusName { get; set; }
            public decimal TaxRate { get; set; }
            public decimal TaxPortion { get; set; }
            public bool IsNonShipping { get; set; }
            public int TaxSchedule { get; set; }
            public decimal ProductShippingWeight { get; set; }
            public decimal ProductShippingLength { get; set; }
            public decimal ProductShippingWidth { get; set; }
            public decimal ProductShippingHeight { get; set; }
            public List<OptionSelection> OptionSelection { get; set; }
            public List<CustomProperty> CustomProperties { get; set; }
            public int ShipFromMode { get; set; }
            public string ShipFromNotificationId { get; set; }
            public Address ShipFromAddress { get; set; }
            public bool ShipSeparately { get; set; }
            public decimal ExtraShipCharge { get; set; }
        }

        public class OptionSelection
        {
            public string OptionBvin { get; set; }
            public string SelectionData { get; set; }
        }

        public class CustomProperty
        {
            public string DeveloperId { get; set; }
            public string Key { get; set; }
            public string Value { get; set; }
        }

        public class Address
        {
            public string Bvin { get; set; }
            public DateTime LastUpdatedUtc { get; set; }
            public int StoreId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Company { get; set; }
            public string Line1 { get; set; }
            public string Line2 { get; set; }
            public string Line3 { get; set; }
            public string City { get; set; }
            public string RegionName { get; set; }
            public string PostalCode { get; set; }
            public string CountryName { get; set; }
            public string Phone { get; set; }
            public string Fax { get; set; }
            public string WebSiteUrl { get; set; }
            public string UserBvin { get; set; }
            public int AddressType { get; set; }
        }

        public class Notes
        {
            public int Id { get; set; }
            public int StoreId { get; set; }
            public DateTime LastUpdatedUtc { get; set; }
            public string OrderID { get; set; }
            public DateTime AuditDate { get; set; }
            public string Note { get; set; }
            public bool IsPublic { get; set; }
        }

        public class Package
        {
            // Add properties if packages data is available in the future
        }

        public class OrderDetails
        {
            public int Id { get; set; }
            public string Bvin { get; set; }
            public int StoreId { get; set; }
            public DateTime LastUpdatedUtc { get; set; }
            public DateTime TimeOfOrderUtc { get; set; }
            public string OrderNumber { get; set; }
            public string ThirdPartyOrderId { get; set; }
            public string UserEmail { get; set; }
            public string UserID { get; set; }
            public List<CustomProperty> CustomProperties { get; set; }
            public int PaymentStatus { get; set; }
            public int ShippingStatus { get; set; }
            public bool IsPlaced { get; set; }
            public string StatusCode { get; set; }
            public string StatusName { get; set; }
            public Address BillingAddress { get; set; }
            public Address ShippingAddress { get; set; }
            public string AffiliateID { get; set; }
            public decimal FraudScore { get; set; }
            public string Instructions { get; set; }
            public string ShippingMethodId { get; set; }
            public string ShippingMethodDisplayName { get; set; }
            public string ShippingProviderId { get; set; }
            public string ShippingProviderServiceCode { get; set; }
            public decimal TotalTax { get; set; }
            public decimal ItemsTax { get; set; }
            public decimal ShippingTax { get; set; }
            public decimal ShippingTaxRate { get; set; }
            public decimal TotalShippingBeforeDiscounts { get; set; }
            public decimal TotalHandling { get; set; }
            public List<OrderDiscount> OrderDiscountDetails { get; set; }
            public List<ShippingDiscount> ShippingDiscountDetails { get; set; }
        }

        public class OrderDiscount
        {
            // Add properties if discount details are available
        }

        public class ShippingDiscount
        {
            // Add properties if shipping discount details are available
        }

    }
}
