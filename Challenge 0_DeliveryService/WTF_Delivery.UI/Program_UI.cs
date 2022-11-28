using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Program_UI
{
    private DeliveryItemRepository _repo = new DeliveryItemRepository();

    public void Run()
    {
        Seed();
        RunApplication();
    }

    public void RunApplication()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();

            System.Console.WriteLine("Welcome to the Warner Transit Federal Tracking System\n"
            + "Please select from the following delivery tracking options:\n"
            +"1. Add new delivery\n"
            + "2. List all deliveries\n"
            + "3. List all en route / completed deliveries\n"
            + "4. Update the status of a delivery\n"
            + "5. Cancel a delivery\n"
            + "6. Exit system");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CreateNewDelivery();
                    break;
                case "2":
                    ListAllDeliveries();
                    break;
                case "3":
                    ViewEnRouteOrComplete();
                    break;
                case "4":
                    UpdateStatus();
                    break;
                case "5":
                    CancelDelivery();
                    break;
                case "6":
                    System.Console.WriteLine("System has been exited!");

                    isRunning = false;
                    break;
                default:
                    System.Console.WriteLine("Option picked is not available. Please choose from one of the options listed above.");
                    break;
            }

            System.Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    // Create
    private void CreateNewDelivery()
    {
        Console.Clear();

        ServiceContent newContent = new ServiceContent();

        System.Console.WriteLine("Please enter the new order number (numbers only)...");
        newContent.OrderNumber = Console.ReadLine();

        System.Console.WriteLine("Please enter the order date in 00/00/0000 formatting...");
        newContent.OrderDate = Console.ReadLine();

        System.Console.WriteLine("Please enter the delivery date in 00/00/0000 formatting, if not available enter N/A...");
        newContent.DeliveryDate = Console.ReadLine();

        System.Console.WriteLine("Please select the order status from the following options\n"
        + "1. Scheduled\n"
        + "2. EnRoute\n"
        + "3. Complete\n"
        + "4. Canceled");
        string statusString = Console.ReadLine();
        int statusInt = int.Parse(statusString);
        newContent.Status = (Status)statusInt;

        System.Console.WriteLine("Please enter the item name being ordered...");
        newContent.ItemName = Console.ReadLine();

        System.Console.WriteLine("Please enter the item quantity (1-50) being ordered...");
        string itemQuantityString = Console.ReadLine();
        newContent.ItemQuantity = int.Parse(itemQuantityString);

        System.Console.WriteLine("Please enter the customer ID (numbers only)...");
        string customerIDString = Console.ReadLine();
        newContent.CustomerID = int.Parse(customerIDString);

        bool addResult = _repo.AddDeliveryToDirectory(newContent);
        if (addResult)
        {
            Console.Clear();
            System.Console.WriteLine("Delivery information added successfully!");
        }
        else
        {
            Console.Clear();
            System.Console.WriteLine("There was an issue adding in the new delivery...please try again.");
        }
    }

    // List all Deliveries
    private void ListAllDeliveries()
    {
        List<ServiceContent> contentList = _repo.GetAllContent();

        if (contentList.Count > 0)
        {
            foreach (ServiceContent content in contentList)
            {
                DisplayDeliveries(content);
            }
        }
        else
        {
            System.Console.WriteLine("There are no deliveries within the database...please try adding one through option 1.");
        }
    }

    private void ViewEnRouteOrComplete()
    {
        bool deliveryEnRouteOrComplete = true;

        while (deliveryEnRouteOrComplete)
        {
            Console.Clear();

            foreach (ServiceContent content in _repo.GetAllContent())
            {
                System.Console.WriteLine("Would you like to view Completed or EnRoute Deliveries\n"
                + "2. EnRoute Deliveries\n"
                + "3. Completed Deliveries\n"
                + "4. Main Menu");
                string serviceStatusString = Console.ReadLine();

                switch (serviceStatusString)
                {
                    case "2":
                    case "3":
                        int completeInt = int.Parse(serviceStatusString);
                        content.Status = (Status)completeInt;
                        DisplayDeliveries(content);
                        break;
                    case "4":
                        System.Console.WriteLine("Going to main menu...");
                        deliveryEnRouteOrComplete = false;
                        break;
                    default:
                        System.Console.WriteLine("Incorrect Response. Please try again.");
                        break;
                }
            }
        }
    }

    // Update
    private void UpdateStatus()
    {
        Console.Clear();

        System.Console.WriteLine("Please enter the order number of the delivery status you would like to update:");

        string OrderNumber = Console.ReadLine();
        ServiceContent contentToUpdate = _repo.GetDeliveryByON(OrderNumber);

        Console.Clear();

        if (contentToUpdate != null)
        {
            ServiceContent newContent = new ServiceContent();
            System.Console.WriteLine("Please enter a new status for this delivery, if there is no update press enter:\n"
            + "1. Scheduled\n"
            + "2. EnRoute\n"
            + "3. Complete\n"
            + "4. Canceled");
            string serviceString = Console.ReadLine();
            int serviceInt = serviceString != "" ? int.Parse(serviceString) : 0;
            newContent.Status = (Status)serviceInt;

            bool updateResult = _repo.UpdateStatus(OrderNumber, newContent);

            if (updateResult)
            {
                Console.Clear();
                System.Console.WriteLine("Delivery status was successfully updated!");
            }
            else
            {
                Console.Clear();
                System.Console.WriteLine("There was an issue updating the status of the delivery...please try again.");
            }
        }
        else
        {
            System.Console.WriteLine("There is no delivery with that order number...select option 2 to view all deliveries.");
        }
    }

    // Delete
    private void CancelDelivery()
    {
        Console.Clear();

        System.Console.WriteLine("Please enter the order number for the delivery you would like to delete:");

        string OrderNumber = Console.ReadLine();

        bool wasDeleted = _repo.DeleteDelivery(OrderNumber);

        if (wasDeleted)
        {
            System.Console.WriteLine("Delivery was successfully deleted!");
        }
        else
        {
            System.Console.WriteLine("There was a problem with deleting the delivery...Please make sure you entered the correct order number...");
        }
    }

    private void Seed()
    {
        ServiceContent delivery1 = new ServiceContent("111", "6/24/2022", "7/5/2022", Status.Complete, "Macintosh Laptop Charger", 1, 001);
        ServiceContent delivery2 = new ServiceContent("206", "6/29/2022", "N/A", Status.Canceled, "Logitech Keyboard", 5, 054);
        ServiceContent delivery3 = new ServiceContent("50", "8/23/2022", "N/A", Status.Scheduled, "Men's Glide Razors", 10, 023);
        ServiceContent delivery4 = new ServiceContent("223", "7/01/2022", "7/16/2022", Status.Complete, "IPhone 11 Pro Max Phone Charger", 1, 115);
        ServiceContent delivery5 = new ServiceContent("300", "8/20/2022", "8/31/2022", Status.EnRoute, "Nintendo Switch Blue Case", 1, 245);

        _repo.AddDeliveryToDirectory(delivery1);
        _repo.AddDeliveryToDirectory(delivery2);
        _repo.AddDeliveryToDirectory(delivery3);
        _repo.AddDeliveryToDirectory(delivery4);
        _repo.AddDeliveryToDirectory(delivery5);
    }

    private void DisplayDeliveries(ServiceContent content)
    {
        System.Console.WriteLine($@"Order Number: {content.OrderNumber}
        Date Ordered: {content.OrderDate} | Delivery Date: {content.DeliveryDate}
        Order Status: {content.Status}
        Item Ordered: {content.ItemName} | Quantity: {content.ItemQuantity}
        Customer ID: {content.CustomerID}");
    }
}
