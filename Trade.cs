using System.Net.Cache;
using System.Security.Cryptography.X509Certificates;
using Apps;

namespace Apps;

public class Trade : TradeStatus
{
    public string? Sender;
    public string? Reciever;
    public Item Request;
    public Item Items;
    public Status Status;

    public Trade(string sender, string reciever, Item request, Item items, string status)
    {
        Sender = sender;
        Reciever = reciever;
        Request = request;
        Items = items;
        switch (status)
        {
            case "Pending":
                Status = Status.Pending;
                break;
            case "Declined":
                Status = Status.Pending;
                break;
            case "Accepted":
                Status = Status.Pending;
                break;
        }
        System.Console.WriteLine("Trade sumbited!");
    }

    public void GetRequest(Trade trade)
    {
        System.Console.WriteLine("----------------------------------------------------");
        Console.WriteLine($"Sender: {trade.Sender}");
        System.Console.WriteLine("----------------------------------------------------");
        System.Console.WriteLine($"Item: {trade.Request.Name}\n" +
                                $" Description: {trade.Request.Desc}");
        System.Console.WriteLine("----------------------------------------------------\n");

        Console.WriteLine($"Reciever: {trade.Reciever}");
        System.Console.WriteLine("----------------------------------------------------");
        System.Console.WriteLine($"Item: {trade.Items.Name}\n" +
                                $" Description: {trade.Items.Desc}");
        System.Console.WriteLine("----------------------------------------------------\n");
    }

    public void GetComplete(Trade trade)
    {
        Console.WriteLine($"Sender: {trade.Sender}"+
                            $"Item: {trade.Request.Name}"+
                            $" Description: {trade.Request.Desc}");
        System.Console.WriteLine(" > ");
        Console.WriteLine($"Reciever: {trade.Reciever}"+
                            $"Item: {trade.Items.Name}"+
                            $" Description: {trade.Items.Desc}\n");
    }

}