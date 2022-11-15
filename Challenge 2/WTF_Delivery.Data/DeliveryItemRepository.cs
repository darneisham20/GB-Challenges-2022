using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class DeliveryItemRepository
{
    protected readonly List<ServiceContent> _contentDirectory = new List<ServiceContent>();

    // Create Delivery
    public bool AddDeliveryToDirectory(ServiceContent content)
    {
        int prevCount = _contentDirectory.Count;

        _contentDirectory.Add(content);

        return prevCount < _contentDirectory.Count ? true : false;
    }

    // List All Deliveries
    public List<ServiceContent> GetAllContent()
    {
        return _contentDirectory;
    }

    // // Update Status in Delivery
    public bool UpdateStatus(string OrderNumber, ServiceContent newContent)
    {
        ServiceContent oldContent = GetDeliveryByON(OrderNumber);

        if (oldContent != null)
        {
            oldContent.Status = newContent.Status != 0 ? newContent.Status : oldContent.Status;

            return true;
        }
        else
        {
            return false;
        }
    }

    // One Delivery
    public ServiceContent GetDeliveryByON(string orderNumber)
    {
        return _contentDirectory.Find(content => content.OrderNumber == orderNumber);
    }

    // Cancel Delivery 
    public bool DeleteDelivery(string OrderNumber)
    {
        ServiceContent deliveryToDelete = GetDeliveryByON(OrderNumber);

        bool deleteResult = _contentDirectory.Remove(deliveryToDelete);

        return deleteResult;
    }
}
