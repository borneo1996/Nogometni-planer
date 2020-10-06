namespace Nogometni_planer
{
    partial class KreacijaGrupe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNazivGrupe = new System.Windows.Forms.TextBox();
            this.kreirajBtn = new System.Windows.Forms.Button();
            this.odustaniBtn = new System.Windows.Forms.Button();
            this.labelOpaska = new System.Windows.Forms.Label();
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ime grupe";
            // 
            // textBoxNazivGrupe
            // 
            this.textBoxNazivGrupe.Location = new System.Drawing.Point(117, 44);
            this.textBoxNazivGrupe.Name = "textBoxNazivGrupe";
            this.textBoxNazivGrupe.Size = new System.Drawing.Size(195, 20);
            this.textBoxNazivGrupe.TabIndex = 1;
            this.textBoxNazivGrupe.TextChanged += new System.EventHandler(this.textBoxNazivGrupe_TextChanged);
            // 
            // kreirajBtn
            // 
            this.kreirajBtn.Location = new System.Drawing.Point(190, 119);
            this.kreirajBtn.Name = "kreirajBtn";
            this.kreirajBtn.Size = new System.Drawing.Size(97, 27);
            this.kreirajBtn.TabIndex = 2;
            this.kreirajBtn.Text = "Kreiraj";
            this.kreirajBtn.UseVisualStyleBackColor = true;
            this.kreirajBtn.Click += new System.EventHandler(this.kreirajBtn_Click);
            // 
            // odustaniBtn
            // 
            this.odustaniBtn.Location = new System.Drawing.Point(92, 119);
            this.odustaniBtn.Name = "odustaniBtn";
            this.odustaniBtn.Size = new System.Drawing.Size(92, 27);
            this.odustaniBtn.TabIndex = 3;
            this.odustaniBtn.Text = "Odustani";
            this.odustaniBtn.UseVisualStyleBackColor = true;
            this.odustaniBtn.Click += new System.EventHandler(this.odustaniBtn_Click);
            // 
            // labelOpaska
            // 
            this.labelOpaska.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelOpaska.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOpaska.ForeColor = System.Drawing.Color.Red;
            this.labelOpaska.Location = new System.Drawing.Point(0, 67);
            this.labelOpaska.Name = "labelOpaska";
            this.labelOpaska.Size = new System.Drawing.Size(389, 92);
            this.labelOpaska.TabIndex = 4;
            this.labelOpaska.Text = "Ime grupe mora imati barem 4 slova";
            this.labelOpaska.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // helpProvider
            // 
            this.helpProvider.HelpNamespace = "D:\\Apps\\Visual studio repos\\PI projekt\\Software\\Nogometni planer.chm";
            // 
            // KreacijaGrupe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 159);
            this.Controls.Add(this.odustaniBtn);
            this.Controls.Add(this.kreirajBtn);
            this.Controls.Add(this.textBoxNazivGrupe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelOpaska);
            this.helpProvider.SetHelpKeyword(this, "Grupe");
            this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.Name = "KreacijaGrupe";
            this.helpProvider.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nogometni planer";
            this.Load += new System.EventHandler(this.kreacijaGrupe_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNazivGrupe;
        private System.Windows.Forms.Button kreirajBtn;
        private System.Windows.Forms.Button odustaniBtn;
        private System.Windows.Forms.Label labelOpaska;
        public System.Windows.Forms.HelpProvider helpProvider;
    }
}