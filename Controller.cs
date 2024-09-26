namespace JASONAutoBan
{
    internal class Controller
    {
        public static void HandleInput(Dictionary<string, PlayerBan> dict, string filePath)
        {
            Console.WriteLine("Please Enter Player ID: ");

            string userInput = Console.ReadLine() ?? string.Empty;

            if (!dict.ContainsKey(userInput))
            {
                Console.Clear();
                Console.WriteLine("Player ID not found.");
                return;
            }
            UpdateBanCount(userInput, dict, filePath);
        }

        private static void UpdateBanCount(string userInput, Dictionary<string, PlayerBan> dict, string filePath)
        {
            Console.Clear();
            Console.WriteLine("Enter the type of ban to increase count: ");
            string banInput = Console.ReadLine() ?? string.Empty;
            if (!Enum.TryParse(banInput, out BanType type))
            {
                Console.WriteLine("Invalid ban type entered.");
                return;
            }

            Console.WriteLine("Enter integer to increase ban count: ");
            string userIncrement = Console.ReadLine() ?? string.Empty;

            int? incrementCount = GetValidInteger(userIncrement);
            if (incrementCount == null) { return; }

            try
            {
                PlayerBan ban = dict[userInput];
                if (ban.Bans.ContainsKey(type))
                {
                    ban.Bans[type] += incrementCount.Value;
                    Console.WriteLine($"{banInput} ban count for Player ID {userInput}" +
                        $" updated to {ban.Bans[type]}");
                    JsonParser.SaveBanList(dict, filePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred when updating data {ex.Message}");
            }
        }

        private static int? GetValidInteger(string userInput)
        {
            if (!int.TryParse(userInput, out int result))
            {
                Console.Clear();
                Console.WriteLine("Please enter a valid integer");
                return null;
            }
            return result;
        }
    }
}
