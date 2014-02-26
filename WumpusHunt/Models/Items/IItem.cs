namespace WumpusHunt.Models.Items
{
    public interface IItem
    {
        int Score { get; }
        string Name { get; }
    }
}