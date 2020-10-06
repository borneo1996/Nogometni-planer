namespace Nogometni_planer
{
    partial class FormaZaPozivanjeNaTermin
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
            this.dgvClanoviGrupe = new System.Windows.Forms.DataGridView();
            this.posaljiPozivnicuBtn = new System.Windows.Forms.Button();
            this.textBoxVrijeme = new System.Windows.Forms.TextBox();
            this.textBoxLokacija = new System.Windows.Forms.TextBox();
            this.labelNapomena = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClanoviGrupe)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvClanoviGrupe
            // 
            this.dgvClanoviGrupe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClanoviGrupe.Location = new System.Drawing.Point(12, 12);
            this.dgvClanoviGrupe.Name = "dgvClanoviGrupe";
            this.dgvClanoviGrupe.ReadOnly = true;
            this.dgvClanoviGrupe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClanoviGrupe.Size = new System.Drawing.Size(240, 426);
            this.dgvClanoviGrupe.TabIndex = 0;
            // 
            // posaljiPozivnicuBtn
            // 
            this.posaljiPozivnicuBtn.Location = new System.Drawing.Point(258, 64);
            this.posaljiPozivnicuBtn.Name = "posaljiPozivnicuBtn";
            this.posaljiPozivnicuBtn.Size = new System.Drawing.Size(196, 23);
            this.posaljiPozivnicuBtn.TabIndex = 1;
            this.posaljiPozivnicuBtn.Text = "Pošalji pozivnicu";
            this.posaljiPozivnicuBtn.UseVisualStyleBackColor = true;
            this.posaljiPozivnicuBtn.Click += new System.EventHandler(this.posaljiPozivnicuBtn_Click);
            // 
            // textBoxVrijeme
            // 
            this.textBoxVrijeme.Enabled = false;
            this.textBoxVrijeme.Location = new System.Drawing.Point(258, 12);
            this.textBoxVrijeme.Name = "textBoxVrijeme";
            this.textBoxVrijeme.Size = new System.Drawing.Size(196, 20);
            this.textBoxVrijeme.TabIndex = 2;
            // 
            // textBoxLokacija
            // 
            this.textBoxLokacija.Enabled = false;
            this.textBoxLokacija.Location = new System.Drawing.Point(258, 38);
            this.textBoxLokacija.Name = "textBoxLokacija";
            this.textBoxLokacija.Size = new System.Drawing.Size(196, 20);
            this.textBoxLokacija.TabIndex = 2;
            // 
            // labelNapomena
            // 
            this.labelNapomena.Location = new System.Drawing.Point(258, 104);
            this.labelNapomena.Name = "labelNapomena";
            this.labelNapomena.Size = new System.Drawing.Size(196, 29);
            this.labelNapomena.TabIndex = 3;
            this.labelNapomena.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormaZaPozivanjeNaTermin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 450);
            this.Controls.Add(this.labelNapomena);
            this.Controls.Add(this.textBoxLokacija);
            this.Controls.Add(this.textBoxVrijeme);
            this.Controls.Add(this.posaljiPozivnicuBtn);
            this.Controls.Add(this.dgvClanoviGrupe);
            this.Name = "FormaZaPozivanjeNaTermin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Termin";
            this.Load += new System.EventHandler(this.FormaZaPozivanjeNaTermin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClanoviGrupe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClanoviGrupe;
        private System.Windows.Forms.Button posaljiPozivnicuBtn;
        private System.Windows.Forms.TextBox textBoxVrijeme;
        private System.Windows.Forms.TextBox textBoxLokacija;
        private System.Windows.Forms.Label labelNapomena;
    }
}