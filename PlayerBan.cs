namespace JASONAutoBan
{
    enum BanType { Racism, Sexism, Sabotage}
    internal class PlayerBan
    {
        public string PlayerID { get; set; }

        public Dictionary<BanType, int> Bans { get; set; }

        public PlayerBan(string playerID)
        {
            PlayerID = playerID;
            Bans = new Dictionary<BanType, int>();
        }
    }
}
