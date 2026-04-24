using protracker_parser.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace protracker_parser.Services
{

    public class ParserService
    {
        private readonly HttpClient _httpClient;

        public ParserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        async public Task<string> Process(int heroId)
        {


            //string url = $"https://api.opendota.com/api/heroes/{heroId}";           
            string url = "https://api.opendota.com/api/heroStats";
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string jsonString = await response.Content.ReadAsStringAsync();

                List<Hero> allHeroes = JsonSerializer.Deserialize<List<Hero>>(jsonString);
                Hero hero = allHeroes[heroId];
                if (hero == null) return "Hero not found";

                string fullImageUrl = "https://api.opendota.com" + hero.ImgPath;

                double winrate = FindHeroWinrate(hero);

                return $"Hero: {hero.Name}, pub picks: {hero.PubPicks}, " +
                    $"pub winrate: {winrate}";

            }
            catch (Exception e)
            {
                throw;
            }
        }
        public double FindHeroWinrate(Hero hero)
        {
            double winrate = hero.PubPicks > 0 ? Math.Round((double)hero.PubWins / hero.PubPicks * 100, 2) : 0;
            return winrate;
        }

        public string FindHighestWinrateHero(List<Hero> allHeroes)
        {
            Hero? highestWinrateHero = null;
            double maxWinrate = 0;
            foreach (var tempHero in allHeroes)
            {
                double currentWinrate = (double)tempHero.PubWins / tempHero.PubPicks * 100;
                if (currentWinrate > maxWinrate)
                {
                    maxWinrate = currentWinrate;
                    highestWinrateHero = tempHero;
                }
            }
            if (highestWinrateHero == null) return "incorrect hero";
            return $"Highest winrate hero name: {highestWinrateHero.Name}," +
                $"pub picks: {highestWinrateHero.PubPicks}, pub winrate: {maxWinrate}";
        }

        public string FindLowestWinrateHero(List<Hero> allHeroes)
        {
            Hero? lowestWinrateHero = null;
            double minWinrate = 101.0;
            foreach (var tempHero in allHeroes)
            {
                double currentWinrate = (double)tempHero.PubWins / tempHero.PubPicks * 100;
                if (currentWinrate < minWinrate)
                {
                    minWinrate = currentWinrate;
                    lowestWinrateHero = tempHero;
                }
            }
            return $"Lowest winrate hero name: {lowestWinrateHero.Name}," +
                $"pub picks: {lowestWinrateHero.PubPicks}, pub winrate: {minWinrate}";
        }
    }
}