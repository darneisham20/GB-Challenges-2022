using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class MenuItem
{
    public MenuItem() { }

    public MenuItem(int mealNum, string name, string description, string listOfIngredients, double price)
    {
        MealNum = mealNum;
        Name = name;
        Description = description;
        ListOfIngredients = listOfIngredients;
        Price = price;
    }

    // Should be assigned from CafeRepository.cs file
    public int MealNum { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string ListOfIngredients { get; set; }

    public double Price { get; set; }
}
