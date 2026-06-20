namespace BundesligaAnalyser
{
    partial class HauptForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HauptForm));
            cb_Jahr = new ComboBox();
            cb_Liga = new ComboBox();
            l1 = new Label();
            l2 = new Label();
            l3 = new Label();
            n_Tag = new NumericUpDown();
            tbc1 = new TabControl();
            p_Prognose = new TabPage();
            dg_Prognose = new DataGridView();
            p_Spiele = new TabPage();
            dg_Spiele = new DataGridView();
            p_Vergleich = new TabPage();
            dg_Vergleich = new DataGridView();
            ergebnisseAktualisierenToolStripMenuItem = new ToolStripMenuItem();
            prognToolStripMenuItem = new ToolStripMenuItem();
            spieleAnzeigenToolStripMenuItem = new ToolStripMenuItem();
            spieltageToolStripMenuItem = new ToolStripMenuItem();
            ms_1 = new MenuStrip();
            CSVtoolStripMenuItem = new ToolStripMenuItem();
            TestButton = new Button();
            ((System.ComponentModel.ISupportInitialize)n_Tag).BeginInit();
            tbc1.SuspendLayout();
            p_Prognose.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dg_Prognose).BeginInit();
            p_Spiele.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dg_Spiele).BeginInit();
            p_Vergleich.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dg_Vergleich).BeginInit();
            ms_1.SuspendLayout();
            SuspendLayout();
            // 
            // cb_Jahr
            // 
            cb_Jahr.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Jahr.FormattingEnabled = true;
            cb_Jahr.Location = new Point(408, 64);
            cb_Jahr.Margin = new Padding(4);
            cb_Jahr.Name = "cb_Jahr";
            cb_Jahr.Size = new Size(168, 33);
            cb_Jahr.TabIndex = 0;
            // 
            // cb_Liga
            // 
            cb_Liga.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Liga.FormattingEnabled = true;
            cb_Liga.Location = new Point(408, 106);
            cb_Liga.Margin = new Padding(4);
            cb_Liga.Name = "cb_Liga";
            cb_Liga.Size = new Size(168, 33);
            cb_Liga.TabIndex = 1;
            // 
            // l1
            // 
            l1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            l1.Location = new Point(0, 64);
            l1.Margin = new Padding(4, 0, 4, 0);
            l1.Name = "l1";
            l1.Size = new Size(400, 35);
            l1.TabIndex = 2;
            l1.Text = "Wählen Sie die Saison der Liga aus";
            l1.TextAlign = ContentAlignment.MiddleRight;
            l1.Click += l1_Click;
            // 
            // l2
            // 
            l2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            l2.Location = new Point(65, 106);
            l2.Margin = new Padding(4, 0, 4, 0);
            l2.Name = "l2";
            l2.Size = new Size(335, 35);
            l2.TabIndex = 3;
            l2.Text = "Wählen Sie die Bundesliga aus";
            l2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // l3
            // 
            l3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            l3.Location = new Point(138, 149);
            l3.Margin = new Padding(4, 0, 4, 0);
            l3.Name = "l3";
            l3.Size = new Size(262, 35);
            l3.TabIndex = 5;
            l3.Text = "Wähle einen Spieltag aus";
            l3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // n_Tag
            // 
            n_Tag.Location = new Point(408, 149);
            n_Tag.Margin = new Padding(4);
            n_Tag.Maximum = new decimal(new int[] { 34, 0, 0, 0 });
            n_Tag.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            n_Tag.Name = "n_Tag";
            n_Tag.Size = new Size(126, 31);
            n_Tag.TabIndex = 7;
            n_Tag.TextAlign = HorizontalAlignment.Right;
            n_Tag.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // tbc1
            // 
            tbc1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbc1.Controls.Add(p_Prognose);
            tbc1.Controls.Add(p_Spiele);
            tbc1.Controls.Add(p_Vergleich);
            tbc1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbc1.ImeMode = ImeMode.KatakanaHalf;
            tbc1.Location = new Point(10, 215);
            tbc1.Margin = new Padding(4);
            tbc1.Name = "tbc1";
            tbc1.SelectedIndex = 0;
            tbc1.Size = new Size(1121, 502);
            tbc1.TabIndex = 11;
            // 
            // p_Prognose
            // 
            p_Prognose.Controls.Add(dg_Prognose);
            p_Prognose.Location = new Point(4, 39);
            p_Prognose.Margin = new Padding(4);
            p_Prognose.Name = "p_Prognose";
            p_Prognose.Padding = new Padding(4);
            p_Prognose.Size = new Size(1113, 459);
            p_Prognose.TabIndex = 0;
            p_Prognose.Text = "Turniertabelle";
            p_Prognose.UseVisualStyleBackColor = true;
            // 
            // dg_Prognose
            // 
            dg_Prognose.AllowUserToAddRows = false;
            dg_Prognose.AllowUserToDeleteRows = false;
            dg_Prognose.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dg_Prognose.BackgroundColor = Color.White;
            dg_Prognose.BorderStyle = BorderStyle.None;
            dg_Prognose.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dg_Prognose.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dg_Prognose.Dock = DockStyle.Fill;
            dg_Prognose.GridColor = SystemColors.Window;
            dg_Prognose.Location = new Point(4, 4);
            dg_Prognose.Margin = new Padding(4);
            dg_Prognose.Name = "dg_Prognose";
            dg_Prognose.ReadOnly = true;
            dg_Prognose.RowHeadersVisible = false;
            dg_Prognose.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dg_Prognose.RowsDefaultCellStyle = dataGridViewCellStyle1;
            dg_Prognose.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dg_Prognose.Size = new Size(1105, 451);
            dg_Prognose.TabIndex = 1;
            dg_Prognose.CellContentDoubleClick += dg_Prognose_CellContentDoubleClick;
            // 
            // p_Spiele
            // 
            p_Spiele.Controls.Add(dg_Spiele);
            p_Spiele.Location = new Point(4, 39);
            p_Spiele.Margin = new Padding(4);
            p_Spiele.Name = "p_Spiele";
            p_Spiele.Padding = new Padding(4);
            p_Spiele.Size = new Size(1113, 459);
            p_Spiele.TabIndex = 1;
            p_Spiele.Text = "Spiele";
            p_Spiele.UseVisualStyleBackColor = true;
            // 
            // dg_Spiele
            // 
            dg_Spiele.AllowUserToAddRows = false;
            dg_Spiele.AllowUserToDeleteRows = false;
            dg_Spiele.AllowUserToOrderColumns = true;
            dg_Spiele.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dg_Spiele.BackgroundColor = Color.White;
            dg_Spiele.BorderStyle = BorderStyle.None;
            dg_Spiele.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dg_Spiele.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dg_Spiele.Dock = DockStyle.Fill;
            dg_Spiele.Location = new Point(4, 4);
            dg_Spiele.Margin = new Padding(4);
            dg_Spiele.Name = "dg_Spiele";
            dg_Spiele.ReadOnly = true;
            dg_Spiele.RowHeadersVisible = false;
            dg_Spiele.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dg_Spiele.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dg_Spiele.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dg_Spiele.Size = new Size(1105, 451);
            dg_Spiele.TabIndex = 1;
            // 
            // p_Vergleich
            // 
            p_Vergleich.Controls.Add(dg_Vergleich);
            p_Vergleich.Location = new Point(4, 39);
            p_Vergleich.Margin = new Padding(4);
            p_Vergleich.Name = "p_Vergleich";
            p_Vergleich.Padding = new Padding(4);
            p_Vergleich.Size = new Size(1113, 459);
            p_Vergleich.TabIndex = 2;
            p_Vergleich.Text = "Vergleich";
            p_Vergleich.UseVisualStyleBackColor = true;
            // 
            // dg_Vergleich
            // 
            dg_Vergleich.AllowUserToAddRows = false;
            dg_Vergleich.AllowUserToDeleteRows = false;
            dg_Vergleich.AllowUserToOrderColumns = true;
            dg_Vergleich.BackgroundColor = Color.White;
            dg_Vergleich.BorderStyle = BorderStyle.None;
            dg_Vergleich.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dg_Vergleich.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dg_Vergleich.Dock = DockStyle.Fill;
            dg_Vergleich.Location = new Point(4, 4);
            dg_Vergleich.Margin = new Padding(4);
            dg_Vergleich.Name = "dg_Vergleich";
            dg_Vergleich.RowHeadersVisible = false;
            dg_Vergleich.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dg_Vergleich.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dg_Vergleich.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dg_Vergleich.Size = new Size(1105, 451);
            dg_Vergleich.TabIndex = 0;
            // 
            // ergebnisseAktualisierenToolStripMenuItem
            // 
            ergebnisseAktualisierenToolStripMenuItem.Name = "ergebnisseAktualisierenToolStripMenuItem";
            ergebnisseAktualisierenToolStripMenuItem.Size = new Size(235, 32);
            ergebnisseAktualisierenToolStripMenuItem.Text = "Ergebnisse aktualisieren";
            ergebnisseAktualisierenToolStripMenuItem.Click += ergebnisseAktualisierenToolStripMenuItem_Click;
            // 
            // prognToolStripMenuItem
            // 
            prognToolStripMenuItem.Name = "prognToolStripMenuItem";
            prognToolStripMenuItem.Size = new Size(207, 32);
            prognToolStripMenuItem.Text = "Prognose berechnen";
            prognToolStripMenuItem.Click += prognToolStripMenuItem_Click;
            // 
            // spieleAnzeigenToolStripMenuItem
            // 
            spieleAnzeigenToolStripMenuItem.Name = "spieleAnzeigenToolStripMenuItem";
            spieleAnzeigenToolStripMenuItem.Size = new Size(164, 32);
            spieleAnzeigenToolStripMenuItem.Text = "Spiele anzeigen";
            spieleAnzeigenToolStripMenuItem.Click += spieleAnzeigenToolStripMenuItem_Click;
            // 
            // spieltageToolStripMenuItem
            // 
            spieltageToolStripMenuItem.Name = "spieltageToolStripMenuItem";
            spieltageToolStripMenuItem.Size = new Size(215, 32);
            spieltageToolStripMenuItem.Text = "Spieltage vergleichen";
            spieltageToolStripMenuItem.Click += spieltageToolStripMenuItem_Click;
            // 
            // ms_1
            // 
            ms_1.BackColor = SystemColors.ButtonHighlight;
            ms_1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ms_1.GripStyle = ToolStripGripStyle.Visible;
            ms_1.ImageScalingSize = new Size(20, 20);
            ms_1.Items.AddRange(new ToolStripItem[] { ergebnisseAktualisierenToolStripMenuItem, prognToolStripMenuItem, spieleAnzeigenToolStripMenuItem, spieltageToolStripMenuItem, CSVtoolStripMenuItem });
            ms_1.Location = new Point(0, 0);
            ms_1.Name = "ms_1";
            ms_1.Padding = new Padding(8, 2, 0, 2);
            ms_1.Size = new Size(1132, 36);
            ms_1.TabIndex = 10;
            ms_1.Text = "menuStrip1";
            // 
            // CSVtoolStripMenuItem
            // 
            CSVtoolStripMenuItem.Name = "CSVtoolStripMenuItem";
            CSVtoolStripMenuItem.Size = new Size(269, 32);
            CSVtoolStripMenuItem.Text = "Aktuelle Tabelle exportieren";
            CSVtoolStripMenuItem.Click += CSVtoolStripMenuItem_Click;
            // 
            // TestButton
            // 
            TestButton.Location = new Point(583, 64);
            TestButton.Name = "TestButton";
            TestButton.Size = new Size(171, 61);
            TestButton.TabIndex = 12;
            TestButton.Text = "Daten für den Test vorbereiten";
            TestButton.UseVisualStyleBackColor = true;
            TestButton.Click += TestButton_Click;
            // 
            // HauptForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1132, 720);
            Controls.Add(TestButton);
            Controls.Add(tbc1);
            Controls.Add(ms_1);
            Controls.Add(n_Tag);
            Controls.Add(l3);
            Controls.Add(l2);
            Controls.Add(l1);
            Controls.Add(cb_Liga);
            Controls.Add(cb_Jahr);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = ms_1;
            Margin = new Padding(4);
            Name = "HauptForm";
            Text = "Bundesliga Analyzer";
            Load += HauptForm_Load;
            ((System.ComponentModel.ISupportInitialize)n_Tag).EndInit();
            tbc1.ResumeLayout(false);
            p_Prognose.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dg_Prognose).EndInit();
            p_Spiele.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dg_Spiele).EndInit();
            p_Vergleich.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dg_Vergleich).EndInit();
            ms_1.ResumeLayout(false);
            ms_1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cb_Jahr;
        private ComboBox cb_Liga;
        private Label l1;
        private Label l2;
        private Label l3;
        private NumericUpDown n_Tag;
        private Button bt_Update;
        private TabControl tbc1;
        private TabPage p_Prognose;
        private TabPage p_Spiele;
        private TabPage p_Vergleich;
        private DataGridView dg_Vergleich;
        private DataGridView dg_Prognose;
        private DataGridView dg_Spiele;
        private ToolStripMenuItem ergebnisseAktualisierenToolStripMenuItem;
        private ToolStripMenuItem prognToolStripMenuItem;
        private ToolStripMenuItem spieleAnzeigenToolStripMenuItem;
        private ToolStripMenuItem spieltageToolStripMenuItem;
        private MenuStrip ms_1;
        private Button TestButton;
        private ToolStripMenuItem CSVtoolStripMenuItem;
    }
}
