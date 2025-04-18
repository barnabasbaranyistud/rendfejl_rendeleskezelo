using System;

public class OrderDTO
{
    public string OrderId { get; set; }
    public string CustomerName { get; set; }
    public string Email { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; }
    public string ShippingAddress { get; set; }
    public decimal ShippingCost { get; set; }
    public decimal OrderTotal { get; set; }
    public string bvin { get; set; }

    // Constructor to initialize the DTO based on API response
    public OrderDTO(Hotcakes.CommerceDTO.v1.Orders.OrderSnapshotDTO order)
    {
        OrderId = order.Id.ToString();
        CustomerName = $"{order.BillingAddress.FirstName} {order.BillingAddress.LastName}";
        Email = order.UserEmail;
        OrderDate = order.TimeOfOrderUtc == DateTime.MinValue ? DateTime.Now : order.TimeOfOrderUtc;
        Status = order.StatusName;
        ShippingAddress = $"{order.ShippingAddress.Line1}, {order.ShippingAddress.City}, {order.ShippingAddress.CountryName}, {order.ShippingAddress.PostalCode}";
        ShippingCost = order.TotalShippingBeforeDiscounts; // or the relevant shipping cost field
        OrderTotal = order.TotalGrand;
        bvin = order.bvin;
    }
}