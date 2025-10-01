namespace Apps;

public class Item
{
    // Item Name
    public string? Name;
    // Item Description
    public string? Desc;
    // Item Owner ID
    public int OwnerID;

    // Method for creating new Item
    public Item(string name, string desc, int ownerid)
    {
        Name = name;
        Desc = desc;
        OwnerID = ownerid;
    }

    // Method that prints out all info related to an item.
    public void ItemInfo()
    {
        Console.WriteLine($"Item: {Name}");
        System.Console.WriteLine($" Description: {Desc}");
        System.Console.WriteLine($" OwnerID: {OwnerID}");
        System.Console.ReadLine();
    }
}