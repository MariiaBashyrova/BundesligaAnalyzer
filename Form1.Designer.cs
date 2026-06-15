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
            cb_Jahr = new ComboBox();
            cb_Liga = new ComboBox();
            l1 = new Label();
            l2 = new Label();
            l3 = new Label();
            n_Tag = new NumericUpDown();
            ms_1 = new MenuStrip();
            ergebnisseAktualisierenToolStripMenuItem = new ToolStripMenuItem();
            prognToolStripMenuItem = new ToolStripMenuItem();
            spieleAnzeigenToolStripMenuItem = new ToolStripMenuItem();
            spieltageToolStripMenuItem = new ToolStripMenuItem();
            tbc1 = new TabControl();
            p_Prognose = new TabPage();
            dg_Prognose = new DataGridView();
            p_Spiele = new TabPage();
            dg_Spiele = new DataGridView();
            p_Vergleich = new TabPage();
            dg_Vergleich = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)n_Tag).BeginInit();
            ms_1.SuspendLayout();
            tbc1.SuspendLayout();
            p_Prognose.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dg_Prognose).BeginInit();
            p_Spiele.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dg_Spiele).BeginInit();
            p_Vergleich.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dg_Vergleich).BeginInit();
            SuspendLayout();
            // 
            // cb_Jahr
            // 
            cb_Jahr.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Jahr.FormattingEnabled = true;
            cb_Jahr.Location = new Point(326, 51);
            cb_Jahr.Name = "cb_Jahr";
            cb_Jahr.Size = new Size(135, 28);
            cb_Jahr.TabIndex = 0;
            // 
            // cb_Liga
            // 
            cb_Liga.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Liga.FormattingEnabled = true;
            cb_Liga.Location = new Point(326, 85);
            cb_Liga.Name = "cb_Liga";
            cb_Liga.Size = new Size(135, 28);
            cb_Liga.TabIndex = 1;
            // 
            // l1
            // 
            l1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            l1.Location = new Point(0, 51);
            l1.Name = "l1";
            l1.Size = new Size(320, 28);
            l1.TabIndex = 2;
            l1.Text = "Wählen Sie die Saison der Liga aus";
            l1.TextAlign = ContentAlignment.MiddleRight;
            l1.Click += l1_Click;
            // 
            // l2
            // 
            l2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            l2.Location = new Point(52, 85);
            l2.Name = "l2";
            l2.Size = new Size(268, 28);
            l2.TabIndex = 3;
            l2.Text = "Wählen Sie die Bundesliga aus";
            l2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // l3
            // 
            l3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            l3.Location = new Point(110, 119);
            l3.Name = "l3";
            l3.Size = new Size(210, 28);
            l3.TabIndex = 5;
            l3.Text = "Wähle einen Spieltag aus";
            l3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // n_Tag
            // 
            n_Tag.Location = new Point(326, 119);
            n_Tag.Maximum = new decimal(new int[] { 34, 0, 0, 0 });
            n_Tag.Name = "n_Tag";
            n_Tag.Size = new Size(101, 27);
            n_Tag.TabIndex = 7;
            n_Tag.TextAlign = HorizontalAlignment.Right;
            // 
            // ms_1
            // 
            ms_1.BackColor = SystemColors.ButtonHighlight;
            ms_1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ms_1.ImageScalingSize = new Size(20, 20);
            ms_1.Items.AddRange(new ToolStripItem[] { ergebnisseAktualisierenToolStripMenuItem, prognToolStripMenuItem, spieleAnzeigenToolStripMenuItem, spieltageToolStripMenuItem });
            ms_1.Location = new Point(0, 0);
            ms_1.Name = "ms_1";
            ms_1.Size = new Size(839, 31);
            ms_1.TabIndex = 10;
            ms_1.Text = "menuStrip1";
            // 
            // ergebnisseAktualisierenToolStripMenuItem
            // 
            ergebnisseAktualisierenToolStripMenuItem.Name = "ergebnisseAktualisierenToolStripMenuItem";
            ergebnisseAktualisierenToolStripMenuItem.Size = new Size(216, 27);
            ergebnisseAktualisierenToolStripMenuItem.Text = "Ergebnisse aktualisieren";
            ergebnisseAktualisierenToolStripMenuItem.Click += ergebnisseAktualisierenToolStripMenuItem_Click;
            // 
            // prognToolStripMenuItem
            // 
            prognToolStripMenuItem.Name = "prognToolStripMenuItem";
            prognToolStripMenuItem.Size = new Size(186, 27);
            prognToolStripMenuItem.Text = "Prognose berechnen";
            prognToolStripMenuItem.Click += prognToolStripMenuItem_Click;
            // 
            // spieleAnzeigenToolStripMenuItem
            // 
            spieleAnzeigenToolStripMenuItem.Name = "spieleAnzeigenToolStripMenuItem";
            spieleAnzeigenToolStripMenuItem.Size = new Size(149, 27);
            spieleAnzeigenToolStripMenuItem.Text = "Spiele anzeigen";
            spieleAnzeigenToolStripMenuItem.Click += spieleAnzeigenToolStripMenuItem_Click;
            // 
            // spieltageToolStripMenuItem
            // 
            spieltageToolStripMenuItem.Name = "spieltageToolStripMenuItem";
            spieltageToolStripMenuItem.Size = new Size(197, 27);
            spieltageToolStripMenuItem.Text = "Spieltage vergleichen";
            spieltageToolStripMenuItem.Click += spieltageToolStripMenuItem_Click;
            // 
            // tbc1
            // 
            tbc1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbc1.Controls.Add(p_Prognose);
            tbc1.Controls.Add(p_Spiele);
            tbc1.Controls.Add(p_Vergleich);
            tbc1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbc1.Location = new Point(8, 172);
            tbc1.Name = "tbc1";
            tbc1.SelectedIndex = 0;
            tbc1.Size = new Size(830, 417);
            tbc1.TabIndex = 11;
            // 
            // p_Prognose
            // 
            p_Prognose.Controls.Add(dg_Prognose);
            p_Prognose.Location = new Point(4, 34);
            p_Prognose.Name = "p_Prognose";
            p_Prognose.Padding = new Padding(3);
            p_Prognose.Size = new Size(822, 379);
            p_Prognose.TabIndex = 0;
            p_Prognose.Text = "Turniertabelle";
            p_Prognose.UseVisualStyleBackColor = true;
            // 
            // dg_Prognose
            // 
            dg_Prognose.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dg_Prognose.Dock = DockStyle.Fill;
            dg_Prognose.Location = new Point(3, 3);
            dg_Prognose.Name = "dg_Prognose";
            dg_Prognose.RowHeadersWidth = 51;
            dg_Prognose.Size = new Size(816, 373);
            dg_Prognose.TabIndex = 1;
            // 
            // p_Spiele
            // 
            p_Spiele.Controls.Add(dg_Spiele);
            p_Spiele.Location = new Point(4, 34);
            p_Spiele.Name = "p_Spiele";
            p_Spiele.Padding = new Padding(3);
            p_Spiele.Size = new Size(822, 379);
            p_Spiele.TabIndex = 1;
            p_Spiele.Text = "Spiele";
            p_Spiele.UseVisualStyleBackColor = true;
            // 
            // dg_Spiele
            // 
            dg_Spiele.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dg_Spiele.Dock = DockStyle.Fill;
            dg_Spiele.Location = new Point(3, 3);
            dg_Spiele.Name = "dg_Spiele";
            dg_Spiele.RowHeadersWidth = 51;
            dg_Spiele.Size = new Size(816, 373);
            dg_Spiele.TabIndex = 1;
            // 
            // p_Vergleich
            // 
            p_Vergleich.Controls.Add(dg_Vergleich);
            p_Vergleich.Location = new Point(4, 34);
            p_Vergleich.Name = "p_Vergleich";
            p_Vergleich.Padding = new Padding(3);
            p_Vergleich.Size = new Size(822, 379);
            p_Vergleich.TabIndex = 2;
            p_Vergleich.Text = "Vergleich";
            p_Vergleich.UseVisualStyleBackColor = true;
            // 
            // dg_Vergleich
            // 
            dg_Vergleich.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dg_Vergleich.Dock = DockStyle.Fill;
            dg_Vergleich.Location = new Point(3, 3);
            dg_Vergleich.Name = "dg_Vergleich";
            dg_Vergleich.RowHeadersWidth = 51;
            dg_Vergleich.Size = new Size(816, 373);
            dg_Vergleich.TabIndex = 0;
            // 
            // HauptForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(839, 591);
            Controls.Add(tbc1);
            Controls.Add(ms_1);
            Controls.Add(n_Tag);
            Controls.Add(l3);
            Controls.Add(l2);
            Controls.Add(l1);
            Controls.Add(cb_Liga);
            Controls.Add(cb_Jahr);
            MainMenuStrip = ms_1;
            Name = "HauptForm";
            Text = "Bundesliga Analyser";
            Load += HauptForm_Load;
            ((System.ComponentModel.ISupportInitialize)n_Tag).EndInit();
            ms_1.ResumeLayout(false);
            ms_1.PerformLayout();
            tbc1.ResumeLayout(false);
            p_Prognose.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dg_Prognose).EndInit();
            p_Spiele.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dg_Spiele).EndInit();
            p_Vergleich.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dg_Vergleich).EndInit();
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
        private MenuStrip ms_1;
        private ToolStripMenuItem ergebnisseAktualisierenToolStripMenuItem;
        private ToolStripMenuItem prognToolStripMenuItem;
        private ToolStripMenuItem spieleAnzeigenToolStripMenuItem;
        private ToolStripMenuItem spieltageToolStripMenuItem;
        private TabControl tbc1;
        private TabPage p_Prognose;
        private TabPage p_Spiele;
        private TabPage p_Vergleich;
        private DataGridView dg_Vergleich;
        private DataGridView dg_Prognose;
        private DataGridView dg_Spiele;
    }
}
