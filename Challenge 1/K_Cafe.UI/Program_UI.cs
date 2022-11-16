using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Program_UI
{
    CafeRepository _repo = new CafeRepository();

    public void Run()
    {
        Seed();
        Menu();
    }

    private void Menu()
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();

            System.Console.WriteLine("Welcome to Komodo Cafe!\n" +
            "Please select from the following options:\n" +
            +"1. Create new menu items\n"
            + "2. View menu items\n"
            + "3. Update item by menu item number\n"
            + "4. Delete item by menu item number\n"
            + "5. Exit");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CreateNewItem();
                    break;
                case "2":
                    ViewAllItems();
                    break;
                case "3":
                    // UpdateItem();
                    break;
                case "4":
                    // DeleteItem();
                    break;
                case "5":
                    Console.Clear();
                    System.Console.WriteLine("Now exiting the system...");
                    keepRunning = false;
                    break;
                default:
                    System.Console.WriteLine("That isn't an option...please pick from 1-5");
                    break;
            }

            System.Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    private void CreateNewItem()
    {
        Console.Clear();

        MenuItem newItem = new MenuItem();

        newItem.MealNum = _repo.GetAllItems().Count + 1;

        System.Console.WriteLine("Please enter a name for your new menu item...");
        newItem.Name = Console.ReadLine();

        System.Console.WriteLine("Please enter a description for your new item...");
        newItem.Description = Console.ReadLine();

        System.Console.WriteLine("Please enter the ingredients for your new item...");
        newItem.ListOfIngredients = Console.ReadLine();

        System.Console.WriteLine("Please enter the price for your new item...");
        newItem.Price = double.Parse(Console.ReadLine());

        bool itemAdded = _repo.AddNewItem(newItem);

        if (itemAdded)
        {
            Console.Clear();
            System.Console.WriteLine("Item was added!\n");
        }
        else
        {
            Console.Clear();
            System.Console.WriteLine("There was a problem creating your new item, please try again...\n");
        }
    }

    private void ViewAllItems()
    {
        foreach (MenuItem item in _repo.GetAllItems())
        {
            DisplayItem(item);
        }
    }

    private void DisplayItem(MenuItem item)
    {
        System.Console.WriteLine($"Item #{item.MealNum}: {item.Name}\n"
        + "-------------\n"
        + $"$ {item.Price}\n"
        + $"{item.ListOfIngredients}");
        System.Console.WriteLine();
        System.Console.WriteLine($"{item.Description}");
        System.Console.WriteLine();
    }

    private void UpdateItem()
    {
        Console.Clear();

        System.Console.WriteLine("Please enter the menu number of the item you would like to update...");

        int menuNum = int.Parse(Console.ReadLine());
        MenuItem newItem = new MenuItem();

        System.Console.WriteLine("Please enter a new name for this item. If not press enter...");
        newItem.Name = Console.ReadLine();

        System.Console.WriteLine("Please enter a new description. If not press enter...");
        newItem.Description = Console.ReadLine();

        System.Console.WriteLine("Please enter a new list of ingredients.. If not press enter...");
        newItem.ListOfIngredients = Console.ReadLine();

        System.Console.WriteLine("Please enter a price. If not press enter...");
        newItem.Price = double.Parse(Console.ReadLine());

        bool updateSuccess = _repo.UpdateItem(menuNum, newItem);

        if (updateSuccess)
        {
            Console.Clear();

            System.Console.WriteLine("Update was successful!");
        }
        else
        {
            Console.Clear();

            System.Console.WriteLine("There was a problem updating your item, please try again...");
        }
    }

    private void DeleteItem()
    {
        Console.Clear();

        System.Console.WriteLine("Please enter the menu number for the item you would like to delete...");

        int menuNum = int.Parse(Console.ReadLine());

        bool deleteSuccess = _repo.DeleteItem(menuNum);

        if (deleteSuccess)
        {
            Console.Clear();

            System.Console.WriteLine("Deletion was successful!");
        }
        else
        {
            Console.Clear();

            System.Console.WriteLine("There was a problem deleting your item, please try again...");
        }
    }

    private void Seed()
    {
        MenuItem crabBoil = new MenuItem(_repo.GetAllItems().Count + 1, "Crab boil", "The most delicious, mouth watering, scrumptious combination of some of the most delicate seafood this planet has ever known", "crab, garlic, spices, butter, shrimp, sausages, potatoes, corn on the cob, boiled egg", 36.00);
        _repo.AddNewItem(crabBoil);

        MenuItem pepperoniPizza = new MenuItem(_repo.GetAllItems().Count + 1, "Pep pizza", "An italian-american delicacy topped with tomato sauce, mozzerlla cheese, and pepperoni pizza on a bedding of soft dough", "dough, sauce, cheese, pepperoni", 5.00);
    }
}
