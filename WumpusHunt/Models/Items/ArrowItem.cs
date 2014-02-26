namespace WumpusHunt.Models.Items
{
    class ArrowItem : IItem
    {
        public int Score { get { return 0; } }
        public string Name { get { return "Arrow"; } }
        public string Probe()
        {
            return Strings.ArrowOnGround;
        }
    }
}
