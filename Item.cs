namespace Apps;

// Class used for item creation containing Item name, description and who owns it via owner ID.
public class Item : TradeStatus
{
    // Item Name
    public string? Name;
    // Item Description
    public string? Desc;
    // Item Owner ID
    public int OwnerID;
    public Status Status;

    // Method for creating new Item
    public Item(string? name, string? desc, int ownerid)
    {
        Name = name;
        Desc = desc;
        OwnerID = ownerid;
        Status = Status.None;
    }

    // Method that prints out all info related to an item.
    public void ItemInfo()
    {
        Console.WriteLine($"Item: {Name}\n" +
                            $"------------------------------------------------------------------------\n" +
                            $" Description: {Desc}\n" +
                            $" OwnerID: {OwnerID}\n" +
                            $" Status: {Status}\n" +
                            $"------------------------------------------------------------------------\n");
    }
}