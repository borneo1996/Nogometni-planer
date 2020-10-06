namespace Nogometni_planer
{
    partial class GrupeForm
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
            this.components = new System.ComponentModel.Container();
            this.kreirajGrupuBtn = new System.Windows.Forms.Button();
            this.obrisiGrupuBtn = new System.Windows.Forms.Button();
            this.dgvGrupe = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvPopisClanova = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.sendBtn = new System.Windows.Forms.Button();
            this.chatBox = new System.Windows.Forms.RichTextBox();
            this.porukatextBox = new System.Windows.Forms.TextBox();
            this.pozivUGrupuBtn = new System.Windows.Forms.Button();
            this.kalendar = new System.Windows.Forms.MonthCalendar();
            this.panelGrupe = new System.Windows.Forms.Panel();
            this.TerminiBtn = new System.Windows.Forms.Button();
            this.izbaciBtn = new System.Windows.Forms.Button();
            this.buttonPrijatelji = new System.Windows.Forms.Button();
            this.labelKorisnickoIme = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.btnNovaPozivnica = new System.Windows.Forms.Button();
            this.NotificationRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.pomocBtn = new System.Windows.Forms.Button();
            this.pomocButtonToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.logoutBtn = new System.Windows.Forms.Button();
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.notifyIconPoruke = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPopisClanova)).BeginInit();
            this.panelGrupe.SuspendLayout();
            this.SuspendLayout();
            // 
            // kreirajGrupuBtn
            // 
            this.kreirajGrupuBtn.Location = new System.Drawing.Point(12, 547);
            this.kreirajGrupuBtn.Name = "kreirajGrupuBtn";
            this.kreirajGrupuBtn.Size = new System.Drawing.Size(94, 23);
            this.kreirajGrupuBtn.TabIndex = 1;
            this.kreirajGrupuBtn.Text = "Kreiraj grupu";
            this.kreirajGrupuBtn.UseVisualStyleBackColor = true;
            this.kreirajGrupuBtn.Click += new System.EventHandler(this.kreirajGrupuBtn_Click);
            // 
            // obrisiGrupuBtn
            // 
            this.obrisiGrupuBtn.Location = new System.Drawing.Point(112, 547);
            this.obrisiGrupuBtn.Name = "obrisiGrupuBtn";
            this.obrisiGrupuBtn.Size = new System.Drawing.Size(95, 23);
            this.obrisiGrupuBtn.TabIndex = 9;
            this.obrisiGrupuBtn.Text = "Obriši grupu";
            this.obrisiGrupuBtn.UseVisualStyleBackColor = true;
            this.obrisiGrupuBtn.Click += new System.EventHandler(this.obrisiGrupuBtn_Click_1);
            // 
            // dgvGrupe
            // 
            this.dgvGrupe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrupe.Location = new System.Drawing.Point(12, 123);
            this.dgvGrupe.Name = "dgvGrupe";
            this.dgvGrupe.ReadOnly = true;
            this.dgvGrupe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrupe.Size = new System.Drawing.Size(195, 418);
            this.dgvGrupe.TabIndex = 0;
            this.dgvGrupe.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrupe_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Grupe";
            // 
            // dgvPopisClanova
            // 
            this.dgvPopisClanova.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPopisClanova.Location = new System.Drawing.Point(641, 246);
            this.dgvPopisClanova.Name = "dgvPopisClanova";
            this.dgvPopisClanova.ReadOnly = true;
            this.dgvPopisClanova.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPopisClanova.Size = new System.Drawing.Size(199, 274);
            this.dgvPopisClanova.TabIndex = 3;
            this.dgvPopisClanova.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPopisClanova_CellClick);
            this.dgvPopisClanova.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvPopisClanova_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 403);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tipkaj poruku ovdje..";
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(11, 497);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(618, 23);
            this.sendBtn.TabIndex = 8;
            this.sendBtn.Text = "Pošalji";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // chatBox
            // 
            this.chatBox.Location = new System.Drawing.Point(11, 17);
            this.chatBox.Name = "chatBox";
            this.chatBox.ReadOnly = true;
            this.chatBox.Size = new System.Drawing.Size(618, 375);
            this.chatBox.TabIndex = 5;
            this.chatBox.Text = "";
            // 
            // porukatextBox
            // 
            this.porukatextBox.Location = new System.Drawing.Point(11, 421);
            this.porukatextBox.Multiline = true;
            this.porukatextBox.Name = "porukatextBox";
            this.porukatextBox.Size = new System.Drawing.Size(618, 70);
            this.porukatextBox.TabIndex = 6;
            this.porukatextBox.TextChanged += new System.EventHandler(this.porukatextBox_TextChanged);
            // 
            // pozivUGrupuBtn
            // 
            this.pozivUGrupuBtn.Location = new System.Drawing.Point(641, 217);
            this.pozivUGrupuBtn.Name = "pozivUGrupuBtn";
            this.pozivUGrupuBtn.Size = new System.Drawing.Size(97, 23);
            this.pozivUGrupuBtn.TabIndex = 4;
            this.pozivUGrupuBtn.Text = "Pozovi u grupu";
            this.pozivUGrupuBtn.UseVisualStyleBackColor = true;
            this.pozivUGrupuBtn.Click += new System.EventHandler(this.pozivUGrupuBtn_Click);
            // 
            // kalendar
            // 
            this.kalendar.Location = new System.Drawing.Point(641, 9);
            this.kalendar.MaxSelectionCount = 1;
            this.kalendar.Name = "kalendar";
            this.kalendar.TabIndex = 9;
            // 
            // panelGrupe
            // 
            this.panelGrupe.Controls.Add(this.TerminiBtn);
            this.panelGrupe.Controls.Add(this.izbaciBtn);
            this.panelGrupe.Controls.Add(this.kalendar);
            this.panelGrupe.Controls.Add(this.pozivUGrupuBtn);
            this.panelGrupe.Controls.Add(this.porukatextBox);
            this.panelGrupe.Controls.Add(this.chatBox);
            this.panelGrupe.Controls.Add(this.sendBtn);
            this.panelGrupe.Controls.Add(this.label1);
            this.panelGrupe.Controls.Add(this.dgvPopisClanova);
            this.panelGrupe.Location = new System.Drawing.Point(240, 12);
            this.panelGrupe.Name = "panelGrupe";
            this.panelGrupe.Size = new System.Drawing.Size(849, 529);
            this.panelGrupe.TabIndex = 10;
            // 
            // TerminiBtn
            // 
            this.TerminiBtn.Location = new System.Drawing.Point(703, 183);
            this.TerminiBtn.Name = "TerminiBtn";
            this.TerminiBtn.Size = new System.Drawing.Size(75, 23);
            this.TerminiBtn.TabIndex = 11;
            this.TerminiBtn.Text = "Termini";
            this.TerminiBtn.UseVisualStyleBackColor = true;
            this.TerminiBtn.Click += new System.EventHandler(this.terminiBtn_Click);
            // 
            // izbaciBtn
            // 
            this.izbaciBtn.Location = new System.Drawing.Point(743, 217);
            this.izbaciBtn.Name = "izbaciBtn";
            this.izbaciBtn.Size = new System.Drawing.Size(97, 23);
            this.izbaciBtn.TabIndex = 10;
            this.izbaciBtn.Text = "Izbaci iz grupe";
            this.izbaciBtn.UseVisualStyleBackColor = true;
            this.izbaciBtn.Click += new System.EventHandler(this.izbaciBtn_Click);
            // 
            // buttonPrijatelji
            // 
            this.buttonPrijatelji.Location = new System.Drawing.Point(132, 57);
            this.buttonPrijatelji.Name = "buttonPrijatelji";
            this.buttonPrijatelji.Size = new System.Drawing.Size(75, 23);
            this.buttonPrijatelji.TabIndex = 12;
            this.buttonPrijatelji.Text = "Prijatelji";
            this.buttonPrijatelji.UseVisualStyleBackColor = true;
            this.buttonPrijatelji.Click += new System.EventHandler(this.buttonPrijatelji_Click);
            // 
            // labelKorisnickoIme
            // 
            this.labelKorisnickoIme.AutoSize = true;
            this.labelKorisnickoIme.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKorisnickoIme.Location = new System.Drawing.Point(12, 12);
            this.labelKorisnickoIme.Name = "labelKorisnickoIme";
            this.labelKorisnickoIme.Size = new System.Drawing.Size(85, 18);
            this.labelKorisnickoIme.TabIndex = 12;
            this.labelKorisnickoIme.Text = "Username";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.Location = new System.Drawing.Point(12, 30);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(39, 15);
            this.labelEmail.TabIndex = 12;
            this.labelEmail.Text = "Email";
            // 
            // btnNovaPozivnica
            // 
            this.btnNovaPozivnica.BackColor = System.Drawing.Color.Gold;
            this.btnNovaPozivnica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovaPozivnica.Location = new System.Drawing.Point(943, 546);
            this.btnNovaPozivnica.Name = "btnNovaPozivnica";
            this.btnNovaPozivnica.Size = new System.Drawing.Size(116, 24);
            this.btnNovaPozivnica.TabIndex = 13;
            this.btnNovaPozivnica.Text = "Nova pozivnica";
            this.btnNovaPozivnica.UseVisualStyleBackColor = false;
            this.btnNovaPozivnica.Click += new System.EventHandler(this.btnNovaPozivnica_Click);
            // 
            // NotificationRefreshTimer
            // 
            this.NotificationRefreshTimer.Interval = 3000;
            this.NotificationRefreshTimer.Tick += new System.EventHandler(this.NotificationRefreshTimer_Tick);
            // 
            // pomocBtn
            // 
            this.pomocBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pomocBtn.Location = new System.Drawing.Point(1065, 546);
            this.pomocBtn.Name = "pomocBtn";
            this.pomocBtn.Size = new System.Drawing.Size(24, 23);
            this.pomocBtn.TabIndex = 14;
            this.pomocBtn.Text = "?";
            this.pomocButtonToolTip.SetToolTip(this.pomocBtn, "Klikni za pomoć. (tipka F1)");
            this.pomocBtn.UseVisualStyleBackColor = true;
            this.pomocBtn.Click += new System.EventHandler(this.pomocBtn_Click);
            // 
            // pomocButtonToolTip
            // 
            this.pomocButtonToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.pomocButtonToolTip.ToolTipTitle = "Pomoć";
            // 
            // logoutBtn
            // 
            this.logoutBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.logoutBtn.Location = new System.Drawing.Point(15, 57);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(95, 23);
            this.logoutBtn.TabIndex = 15;
            this.logoutBtn.Text = "Odjavi me";
            this.logoutBtn.UseVisualStyleBackColor = false;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // helpProvider
            // 
            this.helpProvider.HelpNamespace = "D:\\Apps\\Visual studio repos\\PI projekt\\Software\\Nogometni planer.chm";
            // 
            // notifyIconPoruke
            // 
            this.notifyIconPoruke.Text = "notifyIconPoruke";
            this.notifyIconPoruke.Visible = true;
            this.notifyIconPoruke.BalloonTipClicked += new System.EventHandler(this.notifyIconPoruke_BalloonTipClicked);
            this.notifyIconPoruke.Click += new System.EventHandler(this.notifyIconPoruke_Click);
            // 
            // GrupeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 579);
            this.Controls.Add(this.buttonPrijatelji);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.pomocBtn);
            this.Controls.Add(this.btnNovaPozivnica);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelKorisnickoIme);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelGrupe);
            this.Controls.Add(this.dgvGrupe);
            this.Controls.Add(this.kreirajGrupuBtn);
            this.Controls.Add(this.obrisiGrupuBtn);
            this.helpProvider.SetHelpKeyword(this, "Pocetna");
            this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.Name = "GrupeForm";
            this.helpProvider.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Grupe";
            this.Load += new System.EventHandler(this.GrupeForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrupeForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPopisClanova)).EndInit();
            this.panelGrupe.ResumeLayout(false);
            this.panelGrupe.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button kreirajGrupuBtn;
        private System.Windows.Forms.Button obrisiGrupuBtn;
        private System.Windows.Forms.DataGridView dgvGrupe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvPopisClanova;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.RichTextBox chatBox;
        private System.Windows.Forms.TextBox porukatextBox;
        private System.Windows.Forms.Button pozivUGrupuBtn;
        private System.Windows.Forms.MonthCalendar kalendar;
        private System.Windows.Forms.Panel panelGrupe;
        private System.Windows.Forms.Label labelKorisnickoIme;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Button btnNovaPozivnica;
        private System.Windows.Forms.Button izbaciBtn;
        private System.Windows.Forms.Timer NotificationRefreshTimer;
        private System.Windows.Forms.Button pomocBtn;
        private System.Windows.Forms.ToolTip pomocButtonToolTip;
        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.Button TerminiBtn;
        public System.Windows.Forms.HelpProvider helpProvider;
        private System.Windows.Forms.Button buttonPrijatelji;
        private System.Windows.Forms.NotifyIcon notifyIconPoruke;
    }
}