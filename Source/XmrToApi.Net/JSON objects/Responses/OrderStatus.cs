namespace Jojatekok.XmrToAPI
{
    public enum OrderStatus
    {
        ToBeCreated = 0,
        Unpaid = 1,
        PaidUnconfirmed = 2,
        PaidConfirmed = 3,
        Complete = 4,
        Underpaid = 100,
        TimedOut = 200
    }
}
