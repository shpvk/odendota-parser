using protracker_parser.Models;

namespace protracker_parser.Services
{
    public class ParserService
    {
        public (int? gamesAmount, int? winrate, string? Error) Process(string inputText)
        {
            if (string.IsNullOrWhiteSpace(inputText))
                return (null, null, "Incorrect input string");

            return (10000, 100, null); // Temporary plug
        }

    }
}
