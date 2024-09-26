namespace JASONAutoBan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, PlayerBan> dict;
            string filePath = "../../../../JASONAutoBan\\players.json";
            dict = JsonParser.GetBanList(filePath);

            Console.WriteLine("JASONAutoBan");
            Console.WriteLine("------------");

            while (true)
            {
                Controller.HandleInput(dict, filePath);
            }
        }   
    }
}
