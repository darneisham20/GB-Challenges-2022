namespace K_Cafe.Tests;

public class K_Cafe_Repository_Tests
{
    [Fact]
    public void SetCorrectMealNum()
    {
        MenuItem content = new MenuItem();
        content.MealNum = "5";

        string expected = "5";
        string actual = content.MealNum;

        Assert.AreEqual(expected, actual);
    }

    public void SetCorrectName()
    {
        MenuItem content = new MenuItem();
        content.Name = "Crab Boil";

        string expected = "Crab Boil";
        string actual = content.Name;

        Assert.AreEqual(expected, actual);
    }

    public void SetCorrectPrice()
    {
        MenuItem content = new MenuItem();
        content.Price = "36.00";

        string expected = "36.00";
        string actual = content.Price;

        Assert.AreEqual(expected, actual);
    }
}