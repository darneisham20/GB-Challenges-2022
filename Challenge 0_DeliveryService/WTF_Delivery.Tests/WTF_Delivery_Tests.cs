namespace WTF_Delivery.Tests;

public class WTF_Delivery_Tests
{
    [Fact]
    public void SetCorrectOrderNumber()
    {
        ServiceContent content = new ServiceContent();
        content.OrderNumber = "111";

        string expected = "111";
        string actual = content.OrderNumber;

        Assert.AreEqual(expected, actual);
    }

    public void SetCorrectItemName()
    {
        ServiceContent content = new ServiceContent();
        content.ItemName = "Macintosh Laptop Charger";

        string expected = "Macintosh Laptop Charger";
        string actual = content.ItemName;

        Assert.AreEqual(expected, actual);
    }
}