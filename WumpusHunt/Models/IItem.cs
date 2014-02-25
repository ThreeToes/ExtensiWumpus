namespace WumpusHunt.Models
{
    internal interface IItem
    {
        int Score { get; }
        string Name { get; }
    }
}