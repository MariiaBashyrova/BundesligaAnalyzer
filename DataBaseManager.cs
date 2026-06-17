using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
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
            finally { connection.Close(); }
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

        public DataTable GetMatches(string league, string season_, int mday)
        {
            DataTable table = new DataTable(); //
            SqliteConnection connection =
                new SqliteConnection(сonnectionString);
            int liga_Id = league == "BL1"? 1 : 2;
            int season = int.Parse(season_);
            

            try
            {
                connection.Open();

                string abfrage = @"
                    SELECT 
                    m.matchday AS Spieltag,
                    m.played AS Played,
                    m.match_datetime AS Datum,
                    th.name AS Heim,
                    ta.name AS Gast,
                    IFNULL(m.home_goals || ':' || m.away_goals,""-"") AS Ergebnis
                FROM matches m
                JOIN teams th ON m.home_team_id = th.id
                JOIN teams ta ON m.away_team_id = ta.id
                WHERE m.liga_id = @liga AND m.matchday = @matchday AND m.season = @season
                ORDER BY m.match_datetime;";

                SqliteCommand cmd =
                    new SqliteCommand(abfrage, connection);

                cmd.Parameters.AddWithValue("@liga", liga_Id);
                cmd.Parameters.AddWithValue("@season", season);
                cmd.Parameters.AddWithValue("@matchday", mday);

                SqliteDataReader reader = cmd.ExecuteReader();
                
                table.Load(reader);

                foreach (DataRow row in table.Rows)
                {
                    DateTime dt =
                        DateTime.Parse(row["Datum"].ToString());

                    row["Datum"] =
                        dt.ToString("dd.MM.yyyy HH:mm");
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
            finally { connection.Close(); }


            return table;
        }

        public DataTable PrognoseBerechnen(string league, string season_, int mday)
        {
            DataTable table = new DataTable(); //
            SqliteConnection connection =
                new SqliteConnection(сonnectionString);
            int liga_Id = league == "BL1" ? 1 : 2;
            int season = int.Parse(season_);


            try
            {
                connection.Open();

                string abfrage = @"
                    WITH table_calc AS (
                    SELECT
                        t.id,
                        t.name,

                        SUM(m.played) AS games,

                        SUM(CASE
                            WHEN m.home_team_id = t.id AND m.home_goals > m.away_goals THEN 1
                            WHEN m.away_team_id = t.id AND m.away_goals > m.home_goals THEN 1
                            ELSE 0
                        END) AS wins,

                        SUM(CASE
                            WHEN m.home_goals = m.away_goals THEN 1
                            ELSE 0
                        END) AS draws,

                        SUM(CASE
                            WHEN m.home_team_id = t.id AND m.home_goals < m.away_goals THEN 1
                            WHEN m.away_team_id = t.id AND m.away_goals < m.home_goals THEN 1
                            ELSE 0
                        END) AS losses,

                        SUM(CASE
                            WHEN m.home_team_id = t.id THEN m.home_goals
                            ELSE m.away_goals
                        END) AS goals_for,

                        SUM(CASE
                            WHEN m.home_team_id = t.id THEN m.away_goals
                            ELSE m.home_goals
                        END) AS goals_against,

                        SUM(CASE
                            WHEN m.home_team_id = t.id THEN m.home_goals - m.away_goals
                            ELSE m.away_goals - m.home_goals
                        END) AS goal_diff,

                        SUM(CASE
                            WHEN m.home_team_id = t.id AND m.home_goals > m.away_goals THEN 3
                            WHEN m.away_team_id = t.id AND m.away_goals > m.home_goals THEN 3
                            WHEN m.home_goals = m.away_goals THEN 1
                            ELSE 0
                        END) AS points,

                        SUM(CASE
                            WHEN m.played = 1 THEN
                                CASE
                                    WHEN m.home_team_id = t.id AND m.home_goals > m.away_goals THEN 3
                                    WHEN m.away_team_id = t.id AND m.away_goals > m.home_goals THEN 3
                                    WHEN m.home_goals = m.away_goals THEN 1
                                    ELSE 0
                                END
                            ELSE 0
                        END) AS points_min,

                        SUM(CASE
                            WHEN m.played = 1 THEN
                                CASE
                                    WHEN m.home_team_id = t.id AND m.home_goals > m.away_goals THEN 3
                                    WHEN m.away_team_id = t.id AND m.away_goals > m.home_goals THEN 3
                                    WHEN m.home_goals = m.away_goals THEN 1
                                    ELSE 0
                                END
                            WHEN m.played = 0 AND m.matchday <= @matchday THEN 3
                            ELSE 0
                        END) AS points_max

                    FROM teams t
                    JOIN matches m
                        ON t.liga_id = @liga and m.liga_id=@liga
                        and t.season = @season and m.season = @season
                        and (t.id = m.home_team_id OR t.id = m.away_team_id)
                        and (m.matchday <= @matchday OR m.played = 0)

                    GROUP BY t.id, t.name
                ),

                final AS (
                SELECT
                    ROW_NUMBER() OVER (
                        ORDER BY points DESC, goal_diff DESC, goals_for DESC, id
                    ) AS Platz,

                    (
                        SELECT COUNT(*) + 1
                        FROM table_calc t2
                        WHERE t2.points_min > t1.points_max
                    ) AS min_position,

                    (
                        SELECT COUNT(*) + 1
                        FROM table_calc t2
                        WHERE t2.id != t1.id AND t2.points_max >= t1.points_min
                    ) AS max_position,

                    t1.*
                FROM table_calc t1
                )

                    SELECT 
                    Platz, id,
                    name AS Mannschaft,
                    games AS Spiele,
                    points AS Punkte,
                    goal_diff AS Tordifferenz,
                    CASE 
                        WHEN points_min = points_max THEN CAST(points_min AS TEXT)
                        ELSE points_min || '-' || points_max
                    END AS Punktbereich,

                    CASE 
                        WHEN min_position = max_position THEN CAST(min_position AS TEXT)
                        ELSE min_position || '-' || max_position
                    END AS Platzprognose

                FROM final
                ORDER BY Platz;";

                SqliteCommand cmd =
                    new SqliteCommand(abfrage, connection);

                cmd.Parameters.AddWithValue("@liga", liga_Id);
                cmd.Parameters.AddWithValue("@season", season);
                cmd.Parameters.AddWithValue("@matchday", mday);

                SqliteDataReader reader = cmd.ExecuteReader();

                table.Load(reader);

                


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
            finally { connection.Close(); }


            return table;
        }

        public DataTable CompareMatchdays(string league, string season_, int mday)
        {
            DataTable table = new DataTable(); //
            SqliteConnection connection =
                new SqliteConnection(сonnectionString);
            int liga_Id = league == "BL1" ? 1 : 2;
            int season = int.Parse(season_);

            try
            {
                connection.Open();

                string abfrage = @"WITH f1 AS (
                        SELECT *
                        FROM forecasts
                        WHERE liga_id =  @liga AND season = @season AND matchday = @matchday1
                        AND created_at = (
                            SELECT MAX(created_at)
                            FROM forecasts
                            WHERE liga_id = @liga AND season = @season AND matchday = @matchday1
                        )
                    ),
                    f2 AS (
                        SELECT *
                        FROM forecasts
                        WHERE liga_id = @liga AND season = @season AND  matchday = @matchday2
                        AND created_at = (
                            SELECT MAX(created_at)
                            FROM forecasts
                            WHERE liga_id = @liga AND season = @season AND matchday = @matchday2
                        )
                    )

                    SELECT 
                        f1.team_name AS Mannschaft,
                        f1.platz AS Platz_alt,
                        f2.platz AS Platz_neu,
                        CAST((f1.platz - f2.platz) AS TEXT) AS Aenderung

                    FROM f1
                    JOIN f2 
                        ON f1.team_id = f2.team_id AND f1.team_id IS NOT NULL

                    ORDER BY Platz_neu;";
                SqliteCommand cmd =
                   new SqliteCommand(abfrage, connection);

                cmd.Parameters.AddWithValue("@liga", liga_Id);
                cmd.Parameters.AddWithValue("@season", season);
                cmd.Parameters.AddWithValue("@matchday1", mday-1);
                cmd.Parameters.AddWithValue("@matchday2", mday);

                SqliteDataReader reader = cmd.ExecuteReader();

                table.Load(reader);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
            finally { connection.Close(); }

            return table;
        }
        public bool SaveForecast(DataTable table, string league, string season_, int mday)
        {
            
            SqliteConnection connection =
                new SqliteConnection(сonnectionString);
            bool check = true;
            
            int liga_id = league == "BL1" ? 1 : 2;
            int season = int.Parse(season_);

            string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            string insert = @"
            INSERT INTO forecasts (
                liga_id, season, matchday,
                team_id, team_name,
                platz, points, position_range,
                created_at
            )
            VALUES (@liga_id,@season, @matchday,@id , @name, @platz, @points, @pos, @now);";
            try
            {
                connection.Open();
                SqliteCommand cmd = connection.CreateCommand();

                cmd.CommandText = insert;

                foreach (DataRow row in table.Rows)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@id", row["id"]);
                    cmd.Parameters.AddWithValue("@liga_id", liga_id);
                    cmd.Parameters.AddWithValue("@season", season); 
                    cmd.Parameters.AddWithValue("@matchday", mday);
                    cmd.Parameters.AddWithValue("@name", row["Mannschaft"]);
                    cmd.Parameters.AddWithValue("@platz", row["Platz"]);
                    cmd.Parameters.AddWithValue("@points", row["Punkte"]);
                    cmd.Parameters.AddWithValue("@pos", row["Platzprognose"]);
                    cmd.Parameters.AddWithValue("@now", now);

                    cmd.ExecuteNonQuery();
                }
               
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Insert in die Tabelle: " + ex.Message);
                check = false;
            }
            finally { connection.Close(); }
            return check;
        }
    }
}
