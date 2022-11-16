namespace WTF_Delivery.Data;

public class ServiceContent
{
    public ServiceContent() { }

    public ServiceContent(string orderNumber, string orderDate, string deliveryDate, Status status, string itemName, int itemQuantity, int customerID)
    {
        OrderNumber = orderNumber;
        OrderDate = orderDate;
        DeliveryDate = deliveryDate;
        Status = status;
        ItemName = itemName;
        ItemQuantity = itemQuantity;
        CustomerID = customerID;
    }

    public string OrderNumber { get; set; }
    public string OrderDate { get; set; }
    public string DeliveryDate { get; set; }
    public Status Status { get; set; }
    public string ItemName { get; set; }
    public int ItemQuantity { get; set; }
    public int CustomerID { get; set; }
}

public enum Status { Scheduled = 1, EnRoute, Complete, Canceled }
