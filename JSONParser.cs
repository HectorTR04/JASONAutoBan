using Newtonsoft.Json;

namespace JASONAutoBan
{
    internal class JsonParser
    {
        public static Dictionary<string, PlayerBan> GetBanList(string fileName)
        {
            try
            {
                string jsonContent = File.ReadAllText(fileName);

                var banDict = JsonConvert.DeserializeObject<Dictionary<string, PlayerBan>>(jsonContent)
                    ?? throw new InvalidOperationException("Failed to deserialize JSON content.");

                return banDict;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while loading JSON: {ex.Message}");
                throw;
            }
        }

        public static void SaveBanList(Dictionary<string, PlayerBan> dict, string filePath)
        {
            try
            {
                string json = JsonConvert.SerializeObject(dict, Formatting.Indented);

                File.WriteAllText(filePath, json);

                Console.WriteLine("Data successfully saved to JSON file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving the file: {ex.Message}");
            }
        }
    }
}

