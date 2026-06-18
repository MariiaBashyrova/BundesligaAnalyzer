using BundesligaAnalyser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BundesligaAnalyser
{
    internal class APIManager
    {
        // Dieser Code wurde mithilfe von ChatGPT entwickelt und anschließend angepasst
        public string GetJson(string league, string season)
        {
            // Daten aus der OpenLigaDB laden
            string url =
                $"https://api.openligadb.de/getmatchdata/{league.ToLower()}/{season}";

            HttpClient client = new HttpClient();

            string json = client.GetStringAsync(url).Result;

            return json;
        }

        // Dieser Code wurde mithilfe von ChatGPT entwickelt und anschließend angepasst
        public void ReadJson(string json, string league, string season)
        {
            JsonDocument document = JsonDocument.Parse(json);
            DataBaseManager db = new DataBaseManager();

            int id_Liga = 0;
            bool check = true;

            JsonElement root = document.RootElement;

            if (league == "BL1") id_Liga = 1;
            else id_Liga = 2;

            int season_int = int.Parse(season);

            foreach (JsonElement match in root.EnumerateArray())
            {
                
                int matchId = 
                    match.GetProperty("matchID").GetInt32();

                int homeId =
                    match.GetProperty("team1")
                         .GetProperty("teamId")
                         .GetInt32();

                int awayId =
                    match.GetProperty("team2")
                         .GetProperty("teamId")
                         .GetInt32();

                string homeName =
                    match.GetProperty("team1")
                         .GetProperty("teamName")
                         .GetString();

                string awayName =
                    match.GetProperty("team2")
                         .GetProperty("teamName")
                         .GetString();

                int matchday =
                    match.GetProperty("group")
                         .GetProperty("groupOrderID")
                         .GetInt32();

                string matchDateTime =
                    match.GetProperty("matchDateTime")
                         .GetString();

                check = db.AddTeam(homeId, id_Liga, season_int, homeName);
                check = db.AddTeam(awayId, id_Liga, season_int, awayName);

                int homeGoals = 0;
                int awayGoals = 0;
                int played =
                    match.GetProperty("matchIsFinished").GetBoolean()
                    ? 1
                    : 0;

                foreach (JsonElement result in
                         match.GetProperty("matchResults").EnumerateArray())
                {
                    string resultName =
                        result.GetProperty("resultName").GetString();

                    if (resultName == "Endergebnis")
                    {
                        homeGoals =
                            result.GetProperty("pointsTeam1").GetInt32();

                        awayGoals =
                            result.GetProperty("pointsTeam2").GetInt32();

                        break;
                    }
                }
                
                check = db.AddMatch(matchId, id_Liga, season_int, homeId, awayId, homeGoals, awayGoals, matchday, played, matchDateTime);
                
            }

            if (check)
                MessageBox.Show("Die Spielergebnisse wurden aktualisiert!");
        }
    }
}
