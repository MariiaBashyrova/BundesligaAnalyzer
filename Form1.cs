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
            DataTable dt = db.PrognoseBerechnen(cb_Liga.Text, cb_Jahr.Text, (int)n_Tag.Value);
            dg_Prognose.DataSource = dt;
            tbc1.SelectedTab = p_Prognose;
            bool check = db.SaveForecast(dt, cb_Liga.Text, cb_Jahr.Text, (int)n_Tag.Value);
            FormatPrognoseTabelle();
        }

        private void FormatPrognoseTabelle()
        {
            foreach (DataGridViewRow row in dg_Prognose.Rows)
            {
                if (Convert.ToInt32(row.Cells["Platz"].Value) < 4)
                {

                    row.DefaultCellStyle.BackColor = Color.FromArgb(214, 250, 214);
                    // Color.LightGreen;

                }
                else if (Convert.ToInt32(row.Cells["Platz"].Value) > 15)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(250, 214, 214);
                    //Color.LightPink;
                }

            }
            dg_Prognose.Columns["id"].Visible = false;

            foreach (DataGridViewColumn col in dg_Prognose.Columns)
            {
                if (col.Name == "Mannschaft")
                {

                    col.FillWeight = 40;
                    col.DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleLeft;
                }

                else
                {
                    col.FillWeight = 10;
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
            FormatSpieleTabelle();
        }

        private void FormatSpieleTabelle()
        {
            foreach (DataGridViewRow row in dg_Spiele.Rows)
            {
                if (row.Cells["Played"].Value.ToString() == "1")
                {

                    row.DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);

                }

            }
            dg_Spiele.Columns["Played"].Visible = false;

            foreach (DataGridViewColumn col in dg_Spiele.Columns)
            {
                if (col.Name == "Datum")
                {
                    col.FillWeight = 20;
                    col.DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleCenter;
                }
                else if (col.Name == "Heim" ||
                         col.Name == "Gast")
                {
                    col.FillWeight = 30;
                    col.DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleLeft;
                }
                else
                {
                    col.FillWeight = 10;
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
            FormatVergleichTabelle();

        }

        private void FormatVergleichTabelle()
        {
            for (int i = 0; i < dg_Vergleich.Rows.Count; i++)
            {
                string valuestr = dg_Vergleich.Rows[i].Cells["Aenderung"].Value.ToString();


                if (valuestr == "0")
                {

                    dg_Vergleich.Rows[i].Cells["Aenderung"].Value = "-";
                }
                else if (valuestr.Contains("-"))
                {
                    dg_Vergleich.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(250, 214, 214);
                    dg_Vergleich.Rows[i].Cells["Aenderung"].Value = @"↓" + valuestr.Replace("-", "");

                }
                else
                {
                    dg_Vergleich.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(214, 250, 214);
                    dg_Vergleich.Rows[i].Cells["Aenderung"].Value = @"↑" + valuestr;

                }
            }

            dg_Vergleich.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            foreach (DataGridViewColumn col in dg_Vergleich.Columns)
            {
                if (col.Name == "Mannschaft")
                {
                    col.FillWeight = 55;
                    col.DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleLeft;
                }

                else
                {
                    col.FillWeight = 15;
                    col.DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleCenter;
                }
            }

            dg_Vergleich.Columns["Aenderung"].HeaderText = "Änderung";
        }

        private void HauptForm_Load(object sender, EventArgs e)
        {
            //  Füge verfügbare Saisons hinzu.
            cb_Jahr.Items.AddRange(new string[] { "2023", "2024", "2025", "2026" });
            // Füge Liga-Auswahl hinzu: "BL1" = Erste Bundesliga, "BL2" = Zweite Bundesliga.
            cb_Liga.Items.AddRange(new string[] { "BL1", "BL2" });
            // Standard-Auswahl: Jahr "2025" (Index 2).
            cb_Jahr.SelectedIndex = 2; // 2025
            // Standard-Auswahl: Liga "BL1" (Index 0).
            cb_Liga.SelectedIndex = 0; // Bundeliga2

            n_Tag.Value = 34; // Voreingestellter Spieltag.

            DataBaseManager db = new DataBaseManager();
            db.CreateDatabase();

        }

        private void dg_Prognose_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.ToString()+" "+sender.ToString());
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            DataBaseManager db = new DataBaseManager();
            if (!db.EsGibtDaten(1, 2025, 1))
            {
                //Wenn es keine Daten gibt, muss die Daten herunterladen
                APIManager api = new APIManager();

                string json = api.GetJson("BL1","2025");

                api.ReadJson(json, "BL1", "2025");

            }
            if (!db.EsGibtDaten(2, 2025, 1))
            {
                //Wenn es keine Daten gibt, muss die Daten herunterladen
                APIManager api = new APIManager();

                string json = api.GetJson("BL2", "2025");

                api.ReadJson(json, "BL2 ", "2025");

            }
            db.TestDaten();
        }
    }
}
