using System.Data;
using System.Text.Json;
using System.Windows.Forms;
using BundesligaAnalyser;

namespace BundesligaAnalyser
{
    public partial class HauptForm : Form
    {
        public HauptForm()
        {
            InitializeComponent();
        }

        private void l1_Click(object sender, EventArgs e)
        {

        }

        private void ergebnisseAktualisierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            APIManager api = new APIManager();

            string json =
                api.GetJson(cb_Liga.Text, cb_Jahr.Text);

            api.ReadJson(json, cb_Liga.Text, cb_Jahr.Text);

             
            tbc1.SelectedTab = p_Prognose;
        }

        private void prognToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Prognose");
            DataBaseManager db = new DataBaseManager();
            DataTable dt    = db.PrognoseBerechnen(cb_Liga.Text, cb_Jahr.Text, (int)n_Tag.Value);
            dg_Prognose.DataSource = dt;
            
            tbc1.SelectedTab = p_Prognose;
            bool check = db.SaveForecast(dt, cb_Liga.Text, cb_Jahr.Text, (int)n_Tag.Value);

            foreach (DataGridViewRow row in dg_Prognose.Rows)
            {
                if (Convert.ToInt32(row.Cells["Platz"].Value) < 4)
                {

                    row.DefaultCellStyle.BackColor = Color.FromArgb(214, 250, 214);
                       // Color.LightGreen;

                }
                else if (Convert.ToInt32(row.Cells["Platz"].Value) > 15)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(250, 214 , 214);
                    //Color.LightPink;
                }

            }
            dg_Prognose.Columns["id"].Visible = false;

            foreach (DataGridViewColumn col in dg_Prognose.Columns)
            {
                if (col.Name == "Mannschaft")
                {
                    col.Width = 150;
                    col.DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleLeft;
                }
                
                else
                {
                    col.Width = 60;
                    col.DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        private void spieleAnzeigenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Spiele");

            DataBaseManager db = new DataBaseManager();

            tbc1.SelectedTab = p_Spiele;
            dg_Spiele.DataSource = db.GetMatches(cb_Liga.Text, cb_Jahr.Text, (int)n_Tag.Value);

            foreach (DataGridViewRow row in dg_Spiele.Rows)
            {
                if (row.Cells["Played"].Value.ToString() == "1")
                {
                    
                        row.DefaultCellStyle.BackColor =  Color.FromArgb(240, 240, 240);
                    
                }

            }
            dg_Spiele.Columns["Played"].Visible = false;

            foreach (DataGridViewColumn col in dg_Spiele.Columns)
            {
                if (col.Name == "Datum")
                {
                    col.Width = 80;
                    col.DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleCenter;
                }
                else if (col.Name == "Heim" ||
                         col.Name == "Gast")
                {
                    col.Width = 120;
                    col.DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleLeft;
                }
                else
                {
                    col.Width = 60;
                    col.DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        private void spieltageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Spieltage");
            tbc1.SelectedTab = p_Vergleich;
            DataBaseManager db = new DataBaseManager();

           
            dg_Vergleich.DataSource = db.CompareMatchdays(cb_Liga.Text, cb_Jahr.Text, (int)n_Tag.Value);

            for (int i = 0; i < dg_Vergleich.Rows.Count; i++)
            {
                
                if (dg_Vergleich.Rows[i].Cells["Aenderung"].Value.ToString() == "0")
                {
                   
                    dg_Vergleich.Rows[i].Cells["Aenderung"].Value = "-";
                }
                else if (dg_Vergleich.Rows[i].Cells["Aenderung"].Value.ToString().Contains("-"))
                {
                    dg_Vergleich.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(250, 214, 214);
                    dg_Vergleich.Rows[i].Cells["Aenderung"].Value += @"↓";
                    
                }
                else
                {
                    dg_Vergleich.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(214, 250, 214);
                    dg_Vergleich.Rows[i].Cells["Aenderung"].Value += @"↑";

                }
            }

            

            foreach (DataGridViewColumn col in dg_Vergleich.Columns)
            {
                if (col.Name == "Mannschaft")
                {
                    col.Width = 120;
                    col.DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleLeft;
                }

                else
                {
                    col.Width = 40;
                    col.DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        private void HauptForm_Load(object sender, EventArgs e)
        {
            //  Füge verfügbare Saisons hinzu.
            cb_Jahr.Items.AddRange(new string[] { "2023", "2024", "2025", "2026" });
            // Füge Liga-Auswahl hinzu: "BL1" = Erste Bundesliga, "BL2" = Zweite Bundesliga.
            cb_Liga.Items.AddRange(new string[] { "BL1", "BL2"});
            // Standard-Auswahl: Jahr "2025" (Index 2).
            cb_Jahr.SelectedIndex = 2; // 2025
            // Standard-Auswahl: Liga "BL1" (Index 0).
            cb_Liga.SelectedIndex = 0; // Bundeliga2
                                       
            n_Tag.Value = 34; // Voreingestellter Spieltag.

            DataBaseManager db = new DataBaseManager(); 
            db.CreateDatabase();

        }
    }
}
