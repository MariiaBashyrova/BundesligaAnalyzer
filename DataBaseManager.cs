using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;


namespace BundesligaAnalyser
{
    internal class DataBaseManager
    {
        private const string сonnectionString =
            "Data Source=bundesliga.db";

        public void CreateDatabase()
        {
            SqliteConnection connection =
                new SqliteConnection(сonnectionString);

            string createTeams = @"
            CREATE TABLE IF NOT EXISTS teams (
                id INTEGER PRIMARY KEY,
                season INTEGER,
                liga_id INTEGER,
                name TEXT NOT NULL
            );";

            string createMatches = @"
            CREATE TABLE IF NOT EXISTS matches (
                id INTEGER PRIMARY KEY,
                season INTEGER,
                liga_id INTEGER,
                home_team_id INTEGER,
                away_team_id INTEGER,
                home_goals INTEGER,
                away_goals INTEGER,
                matchday INTEGER,
                played INTEGER, 
                match_datetime TEXT,
                FOREIGN KEY(home_team_id) REFERENCES teams(id),
                FOREIGN KEY(away_team_id) REFERENCES teams(id)
                );";

            string createForecasts = @"
                CREATE TABLE IF NOT EXISTS forecasts (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    season INTEGER,
                    liga_id INTEGER,
                    matchday INTEGER,
                    team_id INTEGER,
                    team_name TEXT,
                    platz INTEGER,
                    points INTEGER,
                    position_range TEXT,
                    created_at TEXT
                );";


            try
            {
                connection.Open();

                SqliteCommand cmd = connection.CreateCommand();

                cmd.CommandText = createTeams;
                cmd.ExecuteNonQuery();

                cmd.CommandText = createMatches;
                cmd.ExecuteNonQuery();

                cmd.CommandText = createForecasts;
                cmd.ExecuteNonQuery();

                //MessageBox.Show("Tabellen wurden erstellt.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Erstellen von Tabellen: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public bool AddTeam(int id, int liga_id, int season, string name)
        {
            SqliteConnection connection =
                new SqliteConnection(сonnectionString);
            bool check = true;
            string insertTeam = @"
            INSERT OR IGNORE INTO teams VALUES (@id, @season, @liga_id, @name);";
            try 
            { 
                connection.Open();
                SqliteCommand cmd = connection.CreateCommand();

                cmd.CommandText = insertTeam;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@liga_id", liga_id);
                cmd.Parameters.AddWithValue("@season", season);
                cmd.Parameters.AddWithValue("@name", name);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) 
            { 
                MessageBox.Show("Fehler beim Insert in die Tabelle: " + ex.Message); 
                check = false;
            }
            finally { connection.Close();}
            return check;
        }

        public bool AddMatch(int id, int liga_id, int season, int hteam, int ateam, int hgoals, int agoals, int mday, int pl, string mtime)
        {
            SqliteConnection connection =
                new SqliteConnection(сonnectionString);
            bool check = true;
            string insertTeam = @"
            INSERT INTO matches VALUES (@id, @season, @liga_id, @hteam, @ateam, @hgoals, @agoals,
                       @mday, @pl, @mtime )
                        ON CONFLICT(id) DO UPDATE SET
                home_goals=excluded.home_goals,
                away_goals=excluded.away_goals,
                played=excluded.played;";
            try
            {
                connection.Open();
                SqliteCommand cmd = connection.CreateCommand();

                cmd.CommandText = insertTeam;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@liga_id", liga_id);
                cmd.Parameters.AddWithValue("@season", season);
                cmd.Parameters.AddWithValue("@hteam", hteam);
                cmd.Parameters.AddWithValue("@ateam", ateam);
                cmd.Parameters.AddWithValue("@hgoals", hgoals);
                cmd.Parameters.AddWithValue("@agoals", agoals);
                cmd.Parameters.AddWithValue("@mday", mday);
                cmd.Parameters.AddWithValue("@pl", pl);
                cmd.Parameters.AddWithValue("@mtime", mtime);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show("Fehler beim Insert in die Tabelle: " + ex.Message); check = false; }
            finally { connection.Close(); }
            return check;
        }

    }
}
