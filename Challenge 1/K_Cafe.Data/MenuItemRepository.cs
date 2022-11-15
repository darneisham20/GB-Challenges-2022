using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class MenuItemRepository
{
    protected readonly List<MenuItem> _menu = new List<MenuItem>();

    public bool AddNewItem(MenuItem item)
    {
        int prevCount = _menu.Count;

        _menu.Add(item);

        return prevCount < _menu.Count ? true : false;
    }

    public List<MenuItem> GetAllItems()
    {
        return _menu;
    }

    public bool UpdateItem(int mealNum, MenuItem newItem)
    {
        MenuItem oldItem = _menu.Find(item => item.MealNum == mealNum);

        if (oldItem != null)
        {
            oldItem.Name = newItem.Name != "" ? newItem.Name : oldItem.Name;
            oldItem.Description = newItem.Description != "" ? newItem.Description : oldItem.Description;
            oldItem.ListOfIngredients = newItem.ListOfIngredients != "" ? newItem.ListOfIngredients : oldItem.ListOfIngredients;
            oldItem.Price = newItem.Price != 0 ? newItem.Price : oldItem.Price;

            return true;
        }
        else
        {
            return false;
        }
    }

    public bool DeleteItem(int mealNum)
    {
        MenuItem itemToDelete = _menu.Find(item => item.MealNum == mealNum);

        bool deleteResult = _menu.Remove(itemToDelete);

        return deleteResult;
    }
}
