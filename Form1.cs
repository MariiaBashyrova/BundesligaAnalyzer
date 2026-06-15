using BundesligaAnalyzer;
using System.Text.Json;

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
            MessageBox.Show("Prognose");
            tbc1.SelectedTab = p_Prognose;
        }

        private void spieleAnzeigenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Spiele");
            tbc1.SelectedTab = p_Spiele;
        }

        private void spieltageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Spieltage");
            tbc1.SelectedTab = p_Vergleich;
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
