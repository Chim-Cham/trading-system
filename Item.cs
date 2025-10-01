namespace Apps;

public class Item
{
    // Item Name
    public string? Name;
    // Item Description
    public string? Desc;
    public int ItemID;
    // Item Owner ID
    public int OwnerID;

    public Item(string name, string desc, int itemid, int ownerid)
    {
        Name = name;
        Desc = desc;
        ItemID = itemid;
        OwnerID = ownerid;
    }

    // Method that prints out all info related to an item.
    public void ItemInfo()
    {
        Console.WriteLine($"Item: {Name}");
        System.Console.WriteLine($" Description: {Desc}");
        System.Console.WriteLine($" ItemID: {ItemID}");
        System.Console.WriteLine($" OwnerID: {OwnerID}");
        System.Console.ReadLine();
    }

    public void GetStatus()
    {
        return;
    }

    // enum used to track the status of items
    enum Status
    {
        None,
        Stored,
        Tradable,
        Pending,
    }
}