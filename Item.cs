namespace Apps;

public class Item()
{
    // Item Name
    public string? Name;
    // Item Description
    public string? Desc;
    // Item Owner ID
    public int OwnerID;

    // Method that prints out all info related to an item.
    public void ItemInfo()
    {
        Console.WriteLine($"User: {Name}, Email: {Desc}, UserID: {OwnerID}");
    }

    enum Status
    {
        None,
        Stored,
        Tradable,
        Pending,

    }
}