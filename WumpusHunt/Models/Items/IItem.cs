namespace WumpusHunt.Models.Items
{
    public interface IItem
    {
        /// <summary>
        /// Score this item is worth at the end of the game
        /// </summary>
        int Score { get; }
        /// <summary>
        /// Name of the item
        /// </summary>
        string Name { get; }
        /// <summary>
        /// What this item will say if it's lying on the ground
        /// </summary>
        /// <returns></returns>
        string Probe();
    }
}