namespace Apps;

interface TradeStatus
{
    public Status GetStatus(Status item)
    {
        return item;
    }
}

public enum Status
{
    None,
    Pending,
    Accepted,
    Declined,
    InTrade,
}