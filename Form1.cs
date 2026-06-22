using System.Data;
using System.Linq.Expressions;
using System.Text;
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
            ImportiereErgebnisseAusApi(cb_Liga.Text, cb_Jahr.Text);

            tbc1.SelectedTab = p_Prognose;
        }

        private void ImportiereErgebnisseAusApi(string league, string jahr)
        {
            APIManager api = new APIManager();

            string json =
                api.GetJson(league, jahr);

            api.ReadJson(json, league, jahr);
        }

        private void prognToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DataBaseManager db = new DataBaseManager();
            DataTable dt = db.PrognoseBerechnen(cb_Liga.Text, cb_Jahr.Text, (int)n_Tag.Value);

            bool check = db.SaveForecast(dt, cb_Liga.Text, cb_Jahr.Text, (int)n_Tag.Value);
            dg_Prognose.DataSource = null;
            dg_Prognose.Columns.Clear();
            dg_Prognose.DataSource = dt;
            tbc1.SelectedTab = p_Prognose;
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
            dg_Spiele.DataSource = null;
            dg_Spiele.Columns.Clear();
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
            dg_Vergleich.DataSource = null;
            dg_Vergleich.Columns.Clear();
            DataTable dt = db.CompareMatchdays(cb_Liga.Text, cb_Jahr.Text, (int)n_Tag.Value);
            dg_Vergleich.DataSource = dt;
            FormatVergleichTabelle();

        }

        private void FormatVergleichTabelle()

        {
            
            for (int i = 0; i < dg_Vergleich.Rows.Count; i++)
            {
                string valuestr = dg_Vergleich.Rows[i].Cells["Aenderung"].Value.ToString();


                if (valuestr == "0")
                {
                    //MessageBox.Show("0");
                    dg_Vergleich.Rows[i].Cells["Aenderung"].Value = @"-";
                }
                else if (valuestr.Contains("-"))
                {
                    //MessageBox.Show("minus");
                    dg_Vergleich.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(250, 214, 214);
                    dg_Vergleich.Rows[i].Cells["Aenderung"].Value = @"↓" + valuestr.Replace("-", "");

                }
                else
                {
                    //MessageBox.Show("plus");
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
            bool check;
            if (!db.EsGibtDaten(1, 2025, 1))
            {
                //Wenn es keine Daten gibt, muss die Daten herunterladen
                ImportiereErgebnisseAusApi("BL1", "2025");

            }
            if (!db.EsGibtDaten(2, 2025, 1))
            {
                //Wenn es keine Daten gibt, muss die Daten herunterladen
                ImportiereErgebnisseAusApi("BL2", "2025");

            }
            db.TestDaten();
            check = db.SaveForecast(db.PrognoseBerechnen("1", "2025", 34), "1", "2025", 34);
            check = db.SaveForecast(db.PrognoseBerechnen("1", "2025", 33), "1", "2025", 33);
            check = db.SaveForecast(db.PrognoseBerechnen("2", "2025", 34), "2", "2025", 34);
            check = db.SaveForecast(db.PrognoseBerechnen("2", "2025", 33), "2", "2025", 33);
        }

        private void CSVtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView currentGrid;

            if (tbc1.SelectedTab == p_Spiele)
            {
                currentGrid = dg_Spiele;
            }
            else if (tbc1.SelectedTab == p_Prognose)
            {
                currentGrid = dg_Prognose;
            }
            else
            {
                currentGrid = dg_Vergleich;
            }

            ExportToCsv(currentGrid);
            
        }

        //Dieser Abschnitt wurde mithilfe des GPT-Chats erstellt
        private void ExportToCsv(DataGridView dgv)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "CSV-Dateien (*.csv)|*.csv";
            saveFileDialog.FileName = "Bundesliga.csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {

                using (StreamWriter writer =
                       new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8))
                {
                    // Kopfzeilen 
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        writer.Write(dgv.Columns[i].HeaderText);

                        if (i < dgv.Columns.Count - 1)
                            writer.Write(";");
                    }

                    writer.WriteLine();

                    // Zeilen
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            for (int i = 0; i < dgv.Columns.Count; i++)
                            {
                                //writer.Write(row.Cells[i].Value);
                                if (dgv.Columns[i].HeaderText == "Punktbereich" ||
                                    dgv.Columns[i].HeaderText == "Platzprognose" ||
                                        dgv.Columns[i].HeaderText == "Ergebnis")
                                {
                                    writer.Write("=\"" + row.Cells[i].Value + "\"");
                                }
                                else
                                {
                                    writer.Write(row.Cells[i].Value);
                                }

                                if (i < dgv.Columns.Count - 1)
                                    writer.Write(";");
                            }

                            writer.WriteLine();
                        }
                    }
                }

                MessageBox.Show("CSV-Datei erfolgreich gespeichert.");
                }
                catch (Exception ex) { MessageBox.Show("Fehler beim Speichern: " + ex.Message); }

            }
        }
    }
}
