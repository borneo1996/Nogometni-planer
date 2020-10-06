using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using Baza;

namespace Nogometni_planer
{
    public partial class GrupeForm : Form
    {
        public List<Grupa> grupe;

        public Grupa trenutacnaGrupa;

        public Korisnik korisnik = new Korisnik();

        List<Korisnik> clanoviGrupe = new List<Korisnik>();

        private Korisnik posiljatelj = new Korisnik();

        public GrupeForm(Korisnik k)
        {
            korisnik = k;
            InitializeComponent();
        }

        public void GrupeForm_Load(object sender, EventArgs e)
        {
            labelKorisnickoIme.Text = korisnik.KorisnickoIme;
            labelEmail.Text = korisnik.Email;
            ProvjeriImamLiPozivnicu(korisnik.Id);
            grupe = null;
            grupe = DohvatiGrupeUKojimaSeNalazim(korisnik.Id).ToList();
            ProvjeraImamLiGrupuUopce(grupe);
            OsvjeziIspisGrupa();
            PrimjeniOsnovnePostavkeNaDataGridViewGrupe();
            UrediDataGridVieweIPokreniTimere(grupe);
        }

        private void UrediDataGridVieweIPokreniTimere(List<Grupa> grupice)
        {
            //ovako je rjesen problem toga sto se na loadu nije ucitavala lista clanova 
            //i buga gdje se aplikacija rusila ukoliko bi se ulogirao novi korisnik bez grupa
            if (grupice.Count > 0)
            {
                dgvGrupe.CurrentCell = dgvGrupe.Rows[0].Cells["NazivGrupe"];
                if (dgvGrupe.CurrentCell != null)
                {
                    dgvGrupe.CurrentCell = dgvGrupe.Rows[0].Cells["NazivGrupe"];
                    OsvjeziChatbox(dgvGrupe.CurrentRow.DataBoundItem as Grupa);
                    DohvatiInformacijeOdabraneGrupe();
                }
            }
            dgvGrupe.AllowUserToResizeRows = false;
            dgvPopisClanova.AllowUserToResizeRows = false;

            izbaciBtn.Enabled = false;
            sendBtn.Enabled = false;

            NotificationRefreshTimer.Enabled = true;
        }

        private void kreirajGrupuBtn_Click(object sender, EventArgs e)
        {
            KreacijaGrupe kreacijaGrupeForm = new KreacijaGrupe(this);
            kreacijaGrupeForm.ShowDialog();
            grupe = null;
            grupe = DohvatiGrupeUKojimaSeNalazim(korisnik.Id);
            ProvjeraImamLiGrupuUopce(grupe);
            OsvjeziIspisGrupa();
            PrimjeniOsnovnePostavkeNaDataGridViewGrupe();
            if (dgvGrupe.RowCount > 0)
            {
                dgvGrupe.Rows[0].Selected = true;
            }
        }

        private void ProvjeraImamLiGrupuUopce(List<Grupa> groups)
        {
            if (groups.Count < 1)
            {
                obrisiGrupuBtn.Enabled = false;
                foreach (Control c in panelGrupe.Controls)
                {
                    c.Hide();
                }
            }
            else
            {
                obrisiGrupuBtn.Enabled = true;
                foreach (Control c in panelGrupe.Controls)
                {
                    c.Show();
                }
            }
        }


        private void obrisiGrupuBtn_Click_1(object sender, EventArgs e)
        {
            Grupa gr;
            if (dgvGrupe.CurrentRow == null)
            {
                gr = dgvGrupe.Rows[0].DataBoundItem as Grupa;
            }
            else
            {
                gr = dgvGrupe.CurrentRow.DataBoundItem as Grupa;
            }

            DialogResult res = MessageBox.Show("Sigurno želiš obrisati grupu " + gr.NazivGrupe + "?", "Brisanje grupe", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                BrisiGrupu(gr);
                MessageBox.Show("Grupa je uspješno obrisana!");
                grupe = null;
                grupe = DohvatiGrupeUKojimaSeNalazim(korisnik.Id).ToList();
                ProvjeraImamLiGrupuUopce(grupe);
                OsvjeziIspisGrupa();
                PrimjeniOsnovnePostavkeNaDataGridViewGrupe();
                if (grupe.Count > 0)
                {
                    dgvGrupe.Rows[0].Selected = true;
                }
                UrediDataGridVieweIPokreniTimere(grupe);
            }
        }

        private void BrisiGrupu(Grupa gr)
        {
            string brisanjeclanova = "DELETE FROM [clanstvo] WHERE [clanstvo].[grupa]='" + gr.IDGrupe + "'";
            string brisanjeadmina = "DELETE FROM [administracija] WHERE [administracija].[grupa]='" + gr.IDGrupe + "'";
            string brisanjeporuka = "DELETE FROM [poruka] WHERE [poruka].[grupa_id]='" + gr.IDGrupe + "'";
            string brisanjepozivnica = "DELETE FROM [grupa_pozivnice] WHERE [grupa_pozivnice].[grupa]='" + gr.IDGrupe + "'";
            string brisanjetermina = "DELETE FROM [termin] WHERE [termin].[grupa]='" + gr.IDGrupe + "'";
            string brisanjegrupe = "DELETE FROM [grupa] WHERE [grupa].[grupa_id]='" + gr.IDGrupe + "'";
            BazaPodataka.Instanca.IzvrsiUpit(brisanjeclanova);
            BazaPodataka.Instanca.IzvrsiUpit(brisanjeadmina);
            BazaPodataka.Instanca.IzvrsiUpit(brisanjeporuka);
            BazaPodataka.Instanca.IzvrsiUpit(brisanjepozivnica);
            BazaPodataka.Instanca.IzvrsiUpit(brisanjetermina);
            BazaPodataka.Instanca.IzvrsiUpit(brisanjegrupe);
        }

        private List<Grupa> DohvatiGrupeUKojimaSeNalazim(int id)
        {
            string upit = "SELECT * FROM [grupa] WHERE [admin]='" + id + "'";
            SqlDataReader dataReader = BazaPodataka.Instanca.DohvatiDataReader(upit);
            Grupa dohvacenaGrupa;
            List<Grupa> dohvaceneGrupe = new List<Grupa>();
            while (dataReader.Read())
            {
                dohvacenaGrupa = new Grupa();
                dohvacenaGrupa = DohvatiGrupu(dataReader);
                dohvacenaGrupa.NazivGrupe += "*";
                dohvaceneGrupe.Add(dohvacenaGrupa);
            }
            dataReader.Close();

            upit = "SELECT * FROM [grupa] INNER JOIN [clanstvo] on [grupa].[grupa_id]=[clanstvo].[grupa] WHERE [clanstvo].[korisnik]='" + id + "'";
            dataReader = BazaPodataka.Instanca.DohvatiDataReader(upit);
            while (dataReader.Read())
            {
                dohvacenaGrupa = new Grupa();
                dohvacenaGrupa = DohvatiGrupu(dataReader);
                dohvaceneGrupe.Add(dohvacenaGrupa);
            }
            dataReader.Close();
            return dohvaceneGrupe;

        }

        private Grupa DohvatiGrupu(SqlDataReader dr)
        {
            Grupa group = null;
            if (dr != null)
            {
                group = new Grupa();
                group.IDGrupe = int.Parse(dr["grupa_id"].ToString());
                group.AdminGrupe = int.Parse(dr["admin"].ToString());
                group.NazivGrupe = dr["naziv"].ToString();
            }
            return group;
        }

        private void OsvjeziIspisGrupa()
        {
            dgvGrupe.DataSource = null;
            dgvGrupe.DataSource = grupe;
        }

        private void PrimjeniOsnovnePostavkeNaDataGridViewGrupe()
        {
            dgvGrupe.Columns["AdminGrupe"].Visible = false;
            dgvGrupe.Columns["IDGrupe"].Visible = false;
            dgvGrupe.Columns["NazivGrupe"].HeaderText = "Grupa";
            dgvGrupe.RowHeadersVisible = false;
            dgvGrupe.AllowUserToResizeColumns = false;
            dgvGrupe.AllowUserToOrderColumns = false;
            dgvGrupe.Columns["NazivGrupe"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrupe.Columns["NazivGrupe"].HeaderCell.Style.Font = new Font("Tahoma", 9F, FontStyle.Bold);

        }


        private void DohvatiInformacijeOdabraneGrupe()
        {
            Grupa odabranaGrupa = new Grupa();
            odabranaGrupa = dgvGrupe.CurrentRow.DataBoundItem as Grupa;
            List<Korisnik> clanoviGrupe = null;
            clanoviGrupe = DohvatiClanoveGrupe(odabranaGrupa.IDGrupe);
            dgvPopisClanova.DataSource = null;
            dgvPopisClanova.DataSource = clanoviGrupe;
            PrimjeniOsnovnePostavkeNaDGVclanovi();
            bool kreator = ProvjeriJesamLiKreiraoGrupu(korisnik.Id, odabranaGrupa.IDGrupe);
            bool admin = ProvjeriJesamLiAdminOdabraneGrupe(korisnik.Id, odabranaGrupa.IDGrupe);
            TerminiBtn.Enabled = true;
            if (admin)
            {
                izbaciBtn.Visible = true;
                izbaciBtn.Enabled = true;
                pozivUGrupuBtn.Visible = true;
            }
            else
            {
                izbaciBtn.Visible = false;
                izbaciBtn.Enabled = false;
                pozivUGrupuBtn.Visible = false;
            }

            if (kreator)//samo kreator grupe ju moze i obrisati
            {
                obrisiGrupuBtn.Enabled = true;
            }
            else
            {

                obrisiGrupuBtn.Enabled = false;
            }
            trenutacnaGrupa = odabranaGrupa;

        }

        private bool ProvjeriJesamLiAdminOdabraneGrupe(int id, int grupaID)
        {
            string upit = "SELECT * FROM [korisnik] INNER JOIN [administracija] on [administracija].[admin]=[korisnik].[korisnik_id] WHERE [administracija].[admin]='" + id + "' " +
                "AND [administracija].[grupa]='" + grupaID + "'";
            SqlDataReader dataReader = BazaPodataka.Instanca.DohvatiDataReader(upit);
            if (dataReader.Read())
            {
                dataReader.Close();
                return true;
            }
            else
            {
                dataReader.Close();
                return false;
            }
        }

        private bool ProvjeriJesamLiKreiraoGrupu(int korisnikID, int grupaID)
        {
            string upit = "SELECT * FROM [grupa] WHERE [grupa].[grupa_id]='" + grupaID + "' AND [grupa].[admin]='" + korisnikID + "'";
            SqlDataReader dataReader = BazaPodataka.Instanca.DohvatiDataReader(upit);
            if (dataReader.Read())
            {
                dataReader.Close();
                return true;
            }
            else
            {
                dataReader.Close();
                return false;
            }
        }
        private List<Korisnik> DohvatiClanoveGrupe(int idgrupe)
        {
            List<Korisnik> clanovi = new List<Korisnik>();
            List<Korisnik> admini = new List<Korisnik>();
            List<Korisnik> obicniClanovi = new List<Korisnik>();
            string upit = "SELECT * FROM [korisnik] INNER JOIN [clanstvo] on [clanstvo].[korisnik]=[korisnik].[korisnik_id] WHERE [clanstvo].[grupa]='" + idgrupe + "'";
            SqlDataReader dataReader = BazaPodataka.Instanca.DohvatiDataReader(upit);
            Korisnik dohvaceniKorisnik;
            while (dataReader.Read())
            {
                dohvaceniKorisnik = new Korisnik();
                dohvaceniKorisnik = DohvatiPodatkeOKorisniku(dataReader);
                obicniClanovi.Add(dohvaceniKorisnik);
            }
            dataReader.Close();

            upit = "SELECT [korisnik].[korisnicko_ime], [korisnik].[korisnik_id] FROM [korisnik] INNER JOIN [administracija] on [administracija].[admin]=[korisnik].[korisnik_id] WHERE [administracija].[grupa]='" + idgrupe + "'" +
                "UNION SELECT[korisnik].[korisnicko_ime], [korisnik].[korisnik_id] FROM[korisnik] INNER JOIN[grupa] on[grupa].[admin]=[korisnik].[korisnik_id] WHERE[grupa].[grupa_id]='" + idgrupe + "'";
            dataReader = BazaPodataka.Instanca.DohvatiDataReader(upit);
            while (dataReader.Read())
            {
                dohvaceniKorisnik = new Korisnik();
                dohvaceniKorisnik = DohvatiPodatkeOAdminu(dataReader);
                admini.Add(dohvaceniKorisnik);
            }
            dataReader.Close();
            clanovi = ProvjeriDuplikate(admini, obicniClanovi);//admin je ujedno i clan grupe
            return clanovi;
        }

        private List<Korisnik> ProvjeriDuplikate(List<Korisnik> adm, List<Korisnik> kor)
        {
            List<Korisnik> members = new List<Korisnik>();

            members.AddRange(kor);
            int j = adm.Count;
            int i = kor.Count;
            int c, c2;//brojaci

            for (c = 0; c < j; c++)
            {
                for (c2 = 0; c2 < i; c2++)
                {
                    if (adm[c].Id == kor[c2].Id)
                    {
                        members.Remove(kor[c2]);
                        break;
                    }
                }
                adm[c].KorisnickoIme += "(Admin)";
                members.Add(adm[c]);
            }
            return members.OrderBy(o => o.KorisnickoIme).ToList();
        }

        private Korisnik DohvatiPodatkeOKorisniku(SqlDataReader dr)
        {
            Korisnik k = null;
            if (dr != null)
            {
                k = new Korisnik();
                k.Id = int.Parse(dr["korisnik_id"].ToString());
                k.KorisnickoIme = dr["korisnicko_ime"].ToString();
            }

            return k;
        }

        private Korisnik DohvatiPodatkeOAdminu(SqlDataReader dr)
        {
            Korisnik k = null;
            if (dr != null)
            {
                k = new Korisnik();
                k.Id = int.Parse(dr["korisnik_id"].ToString());
                k.KorisnickoIme = dr["korisnicko_ime"].ToString();
            }

            return k;
        }

        private void PrimjeniOsnovnePostavkeNaDGVclanovi()
        {
            dgvPopisClanova.RowHeadersVisible = false;
            dgvPopisClanova.AllowUserToResizeColumns = false;
            dgvPopisClanova.AllowUserToOrderColumns = false;
            for (int i = 0; i < dgvPopisClanova.Columns.Count; i++)
            {
                dgvPopisClanova.Columns[i].Visible = false;
            }
            dgvPopisClanova.Columns["KorisnickoIme"].Visible = true;
            dgvPopisClanova.Columns["KorisnickoIme"].HeaderText = "Korisnik";
            dgvPopisClanova.Columns["KorisnickoIme"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPopisClanova.Columns["KorisnickoIme"].HeaderCell.Style.Font = new Font("Tahoma", 9F, FontStyle.Bold);
        }

        private void ProvjeriImamLiPozivnicu(int id)
        {
            btnNovaPozivnica.Visible = false;
            string upit = "SELECT * FROM [grupa] INNER JOIN [grupa_pozivnice] on [grupa_pozivnice].[grupa]=[grupa].[grupa_id] WHERE [grupa_pozivnice].[korisnik]='" + id + "' AND [grupa_pozivnice].[odgovorena]='0'";
            SqlDataReader dataReader = BazaPodataka.Instanca.DohvatiDataReader(upit);
            if (dataReader.Read())
            {
                btnNovaPozivnica.Visible = true;
            }
            dataReader.Close();

            upit = "SELECT * FROM [termin_pozivnice] WHERE [termin_pozivnice].[korisnik]='" + id + "' AND [termin_pozivnice].[odgovorena]='0'";
            dataReader = BazaPodataka.Instanca.DohvatiDataReader(upit);
            if (dataReader.Read())
            {
                btnNovaPozivnica.Visible = true;
            }
            dataReader.Close();

            upit = "SELECT * FROM [prijateljstvo_pozivnice] WHERE [prijateljstvo_pozivnice].[primatelj]='" + id + "' AND [prijateljstvo_pozivnice].[odgovorena]='0'";
            dataReader = BazaPodataka.Instanca.DohvatiDataReader(upit);
            if (dataReader.Read())
            {
                btnNovaPozivnica.Visible = true;
            }
            dataReader.Close();
        }

        private void pozivUGrupuBtn_Click(object sender, EventArgs e)
        {
            ZvanjeUGrupuForm pozivForma = new ZvanjeUGrupuForm(korisnik, trenutacnaGrupa);
            pozivForma.ShowDialog();
        }

        private void izbaciBtn_Click(object sender, EventArgs e)
        {
            Korisnik zrtva = dgvPopisClanova.CurrentRow.DataBoundItem as Korisnik;
            Grupa group = dgvGrupe.CurrentRow.DataBoundItem as Grupa;
            DialogResult res = MessageBox.Show("Sigurno želiš izbaciti " + zrtva.KorisnickoIme + " iz grupe?", "Izbacivanje iz grupe", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                IzbaciCovjekaVan(zrtva, group);
            }
            clanoviGrupe = DohvatiClanoveGrupe(group.IDGrupe);
            dgvPopisClanova.DataSource = null;
            dgvPopisClanova.DataSource = clanoviGrupe;
            PrimjeniOsnovnePostavkeNaDGVclanovi();
        }

        private void btnNovaPozivnica_Click(object sender, EventArgs e)
        {
            Pozivnice pozivniceForma = new Pozivnice(korisnik);
            pozivniceForma.ShowDialog();
            ProvjeriImamLiPozivnicu(korisnik.Id);
            grupe = DohvatiGrupeUKojimaSeNalazim(korisnik.Id).ToList();
            ProvjeraImamLiGrupuUopce(grupe);
            OsvjeziIspisGrupa();
            PrimjeniOsnovnePostavkeNaDataGridViewGrupe();
            if (grupe.Count > 0)
            {
                dgvGrupe.CurrentCell = dgvGrupe.Rows[0].Cells[1];
                dgvGrupe.Rows[0].Selected = true;
                DohvatiInformacijeOdabraneGrupe();
            }
        }

        private bool AkoJeOdabraniKorisnikAdmin(Korisnik k, Grupa g)
        {
            string upit = "SELECT [administracija_id], [admin], [grupa] FROM [administracija] WHERE [administracija].[admin]='" + k.Id + "' " +
                "AND [administracija].[grupa]='" + g.IDGrupe + "'";
            SqlDataReader dataReader = BazaPodataka.Instanca.DohvatiDataReader(upit);
            if (dataReader.Read())
            {
                dataReader.Close();
                return true;
            }
            dataReader.Close();
            return false;
        }

        private void IzbaciCovjekaVan(Korisnik k, Grupa g)
        {
            string brisanje = "DELETE FROM [clanstvo] WHERE [grupa]='" + g.IDGrupe + "' AND [korisnik]='" + k.Id + "'";
            BazaPodataka.Instanca.IzvrsiUpit(brisanje);
            brisanje = "DELETE FROM [administracija] WHERE [administracija].[grupa]='" + g.IDGrupe + "' AND [administracija].[admin]='" + k.Id + "'";
            BazaPodataka.Instanca.IzvrsiUpit(brisanje);
            MessageBox.Show("Korisnik " + k.KorisnickoIme + " je uklonjen iz grupe!", "Brisanje uspješno", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void porukatextBox_TextChanged(object sender, EventArgs e)
        {
            ProvjeriDuljinuPoruke(porukatextBox.Text);//u chatu, da ne saljes praznu poruku
        }

        private void ProvjeriDuljinuPoruke(string poruka)
        {
            if (poruka.Length < 1)
            {
                sendBtn.Enabled = false;
            }
            else
            {
                sendBtn.Enabled = true;
            }
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            string poruka = porukatextBox.Text;
            Grupa group = dgvGrupe.CurrentRow.DataBoundItem as Grupa;
            DateTime vrijeme = DateTime.Now;
            string formatiranoVrijeme = vrijeme.ToString("yyyy-MM-dd HH:mm:ss.fff");
            PosaljiPoruku(korisnik.Id, group.IDGrupe, formatiranoVrijeme, poruka);
            porukatextBox.Clear();
            chatBox.Clear();
            List<Poruka> chat = DohvatiPorukeGrupe(group);
            IspisiPorukeGrupe(chat);
        }

        private void PosaljiPoruku(int user, int grupa, string vr, string text)
        {
            string upit = "INSERT INTO [poruka] ([grupa_id], [korisnik_id], [vrijeme], [poruka]) " +
                "VALUES ('" + grupa + "', '" + user + "', '" + vr + "', '" + text + "')";
            BazaPodataka.Instanca.IzvrsiUpit(upit);
        }

        private void OsvjeziChatbox(Grupa gr)
        {
            chatBox.Clear();
            List<Poruka> chat = DohvatiPorukeGrupe(gr);
            IspisiPorukeGrupe(chat);
        }

        private List<Poruka> DohvatiPorukeGrupe(Grupa group)
        {
            string upit = "SELECT [poruka_id], [grupa_id], [korisnik].[korisnicko_ime], [vrijeme], [poruka] FROM [poruka] INNER JOIN [korisnik] on [korisnik].[korisnik_id]=[poruka].[korisnik_id] WHERE [poruka].[grupa_id]='" + group.IDGrupe + "'";
            SqlDataReader dataReader = BazaPodataka.Instanca.DohvatiDataReader(upit);
            Poruka message;
            List<Poruka> chat = new List<Poruka>();
            while (dataReader.Read())
            {
                message = new Poruka();
                message.PorukaID = int.Parse(dataReader["poruka_id"].ToString());
                message.GrupaID = int.Parse(dataReader["grupa_id"].ToString());
                message.Korisnik = dataReader["korisnicko_ime"].ToString();
                message.Vrijeme = dataReader["vrijeme"].ToString();
                message.Tekst = dataReader["poruka"].ToString();
                chat.Add(message);
            }
            dataReader.Close();
            return chat;
        }

        private void IspisiPorukeGrupe(List<Poruka> c)
        {
            foreach (Poruka p in c)
            {
                string poruka = "[" + p.Vrijeme + "]   " + p.Korisnik + ":  " + p.Tekst + "\n";
                chatBox.Text += poruka;
            }
        }


        private void NotificationRefreshTimer_Tick(object sender, EventArgs e)
        {
            if (ProvjeriNovePoruke())
            {
                notifyIconPoruke.Icon = SystemIcons.Information;
                notifyIconPoruke.BalloonTipText = posiljatelj.KorisnickoIme + " Vam je poslao novu poruku.";
                notifyIconPoruke.ShowBalloonTip(1000);
            }
            try
            {
                Grupa g = dgvGrupe.CurrentRow.DataBoundItem as Grupa;
                if (g != null)
                {
                    OsvjeziChatbox(g);
                }
            }
            catch (NullReferenceException)
            {
                
            }
            finally
            {
                ProvjeriImamLiPozivnicu(korisnik.Id);
            }

        }

        private void dgvPopisClanova_MouseDown(object sender, MouseEventArgs e)
        {
            Grupa grupa = dgvGrupe.CurrentRow.DataBoundItem as Grupa;
            if (e.Button == MouseButtons.Right)
            {
                var klik = dgvPopisClanova.HitTest(e.X, e.Y);

                if (klik.RowIndex != -1)
                {
                    dgvPopisClanova.ClearSelection();
                    dgvPopisClanova.Rows[klik.RowIndex].Selected = true;
                    dgvPopisClanova.CurrentCell = dgvPopisClanova.Rows[klik.RowIndex].Cells[1];
                }
                Korisnik k = dgvPopisClanova.Rows[klik.RowIndex].DataBoundItem as Korisnik;

                ContextMenuStrip menu = new ContextMenuStrip();

                if (ProvjeriJesamLiKreiraoGrupu(korisnik.Id, grupa.IDGrupe) && !ProvjeriJeLiSelektiraniClanAdmin(k.Id, grupa.IDGrupe))
                {
                    menu.Items.Add("Unaprijedi u admina").Name = "Unaprijedi u admina";
                } // samo kreator moze unaprijediti
                else if (ProvjeriJesamLiKreiraoGrupu(korisnik.Id, grupa.IDGrupe) && ProvjeriJeLiSelektiraniClanAdmin(k.Id, grupa.IDGrupe) && (k.Id != korisnik.Id))
                {
                    menu.Items.Add("Makni status admina").Name = "Makni status admina";
                }
                if (ProvjeraPrijateljstva(k, korisnik))
                {
                    menu.Items.Add("Pošalji poruku").Name = "Pošalji poruku";
                }
                if (!ProvjeraPostojecegZahtjeva(k, korisnik))
                {
                    menu.Items.Add("Zahtjev za prijateljstvo").Name = "Zahtjev za prijateljstvo";
                }
                if ((k.Id == korisnik.Id) && !ProvjeriJesamLiKreiraoGrupu(korisnik.Id, grupa.IDGrupe))
                {
                    menu.Items.Add("Napusti grupu").Name = "Napusti grupu";
                }//korisnik koji je kreirao grupu ju ne moze napustiti vec samo obrisati

                menu.Show(dgvPopisClanova, new Point(e.X, e.Y));

                menu.ItemClicked += new ToolStripItemClickedEventHandler(NapraviNestoOvisnoOOdabranojOpcijiDesnogKlika);
            }
        }

        private bool ProvjeriJeLiSelektiraniClanAdmin(int korisnik_id, int grupa_id)
        {
            string upit = "SELECT [admin], [grupa] FROM [administracija] WHERE [administracija].[grupa]='" + grupa_id + "' AND [administracija].[admin]='" + korisnik_id + "'";
            SqlDataReader dataReader = BazaPodataka.Instanca.DohvatiDataReader(upit);
            if (dataReader.Read())
            {
                dataReader.Close();
                return true;
            }
            dataReader.Close();
            return false;
        }

        private void NapraviNestoOvisnoOOdabranojOpcijiDesnogKlika(Object sender, ToolStripItemClickedEventArgs e)
        {
            Korisnik oznaceniKorisnik = dgvPopisClanova.CurrentRow.DataBoundItem as Korisnik;
            if (e.ClickedItem.Name == "Unaprijedi u admina")
            {
                Grupa grupa = dgvGrupe.CurrentRow.DataBoundItem as Grupa;
                string upit = "INSERT INTO [administracija] ([admin], [grupa]) VALUES ('" + oznaceniKorisnik.Id + "', '" + grupa.IDGrupe + "')";
                BazaPodataka.Instanca.IzvrsiUpit(upit);

                List<Korisnik> clanoviGrupe = DohvatiClanoveGrupe(grupa.IDGrupe);
                dgvPopisClanova.DataSource = null;
                dgvPopisClanova.DataSource = clanoviGrupe;
                PrimjeniOsnovnePostavkeNaDGVclanovi();
            }
            if (e.ClickedItem.Name == "Makni status admina")
            {
                Grupa grupa = dgvGrupe.CurrentRow.DataBoundItem as Grupa;
                string upit = "DELETE FROM [administracija] WHERE [administracija].[grupa]='" + grupa.IDGrupe + "' AND [administracija].[admin]='" + oznaceniKorisnik.Id + "'";
                BazaPodataka.Instanca.IzvrsiUpit(upit);

                List<Korisnik> clanovi = DohvatiClanoveGrupe(grupa.IDGrupe);
                dgvPopisClanova.DataSource = null;
                dgvPopisClanova.DataSource = clanovi;
                PrimjeniOsnovnePostavkeNaDGVclanovi();
            }
            else if (e.ClickedItem.Name == "Pošalji poruku")
            {
                PrivatnePoruke privatnePorukeForm = new PrivatnePoruke(korisnik, oznaceniKorisnik);
                privatnePorukeForm.ShowDialog();
            }
            else if (e.ClickedItem.Name == "Zahtjev za prijateljstvo")
            {
                string upit = "INSERT INTO prijateljstvo_pozivnice VALUES('" + korisnik.Id + "', '" + oznaceniKorisnik.Id + "', " + '0' + ");";
                BazaPodataka.Instanca.IzvrsiUpit(upit);
            }
            else if (e.ClickedItem.Name == "Napusti grupu")
            {
                Grupa grupa = dgvGrupe.CurrentRow.DataBoundItem as Grupa;
                DialogResult res = MessageBox.Show("Sigurno želite napustiti grupu?", "Provjera", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    NapustiGrupu(oznaceniKorisnik, grupa);
                    grupe = DohvatiGrupeUKojimaSeNalazim(korisnik.Id).ToList();
                    ProvjeraImamLiGrupuUopce(grupe);
                    OsvjeziIspisGrupa();
                    PrimjeniOsnovnePostavkeNaDataGridViewGrupe();
                    dgvPopisClanova.ClearSelection();
                }
            }

        }

        private void NapustiGrupu(Korisnik k, Grupa g)
        {
            string upit = "DELETE FROM [clanstvo] WHERE [clanstvo].[korisnik]='" + k.Id + "' AND [clanstvo].[grupa]='" + g.IDGrupe + "'";
            BazaPodataka.Instanca.IzvrsiUpit(upit);
            if (AkoJeOdabraniKorisnikAdmin(k, g))
            {
                upit = "DELETE FROM [administracija] WHERE [administracija].[admin]='" + k.Id + "' AND [administracija].[grupa]='" + g.IDGrupe + "'";
                BazaPodataka.Instanca.IzvrsiUpit(upit);
            }
            MessageBox.Show("Više niste član grupe " + g.NazivGrupe + "!");
        }

        private void GrupeForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                helpProvider.SetShowHelp(this, true);
            }
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            NotificationRefreshTimer.Stop();
            this.Close();
        }

        private void terminiBtn_Click(object sender, EventArgs e)
        {
            Termini termin = new Termini(korisnik, trenutacnaGrupa);
            termin.ShowDialog();
        }

        private void pomocBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pritisni tipku F1 za pomoć!", "Pomoć", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonPrijatelji_Click(object sender, EventArgs e)
        {
            Prijatelji prijateljiForm = new Prijatelji(korisnik);
            prijateljiForm.ShowDialog();
        }

        private void dgvGrupe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DohvatiInformacijeOdabraneGrupe();
            chatBox.Clear();
            List<Poruka> chat = DohvatiPorukeGrupe(dgvGrupe.CurrentRow.DataBoundItem as Grupa);
            IspisiPorukeGrupe(chat);
            izbaciBtn.Enabled = false;
        }

        private void dgvPopisClanova_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Korisnik zrtva = dgvPopisClanova.CurrentRow.DataBoundItem as Korisnik;//clan kojeg se namjerava izbaciti (odnosno klikne se na njega)
            Grupa group = dgvGrupe.CurrentRow.DataBoundItem as Grupa;
            izbaciBtn.Enabled = !AkoJeOdabraniKorisnikAdmin(zrtva, group);
        }

        public static bool ProvjeraPostojecegZahtjeva(Korisnik primatelj, Korisnik pozivatelj)
        {
            bool postojiZahtjev = false;
            // Korisnik ne može sam sebi poslati zahtjev
            if (primatelj.Id == pozivatelj.Id)
            {
                return true;
            }
            string upit = "SELECT Id FROM prijateljstvo_pozivnice WHERE odgovorena IN (0, 1) AND (pozivatelj='" + pozivatelj.Id + "' AND primatelj='" + primatelj.Id + "') OR (pozivatelj='" + primatelj.Id + "' AND primatelj='" + pozivatelj.Id + "');";
            SqlDataReader dataReader = BazaPodataka.Instanca.DohvatiDataReader(upit);
            postojiZahtjev = dataReader.HasRows;
            dataReader.Close();
            if (postojiZahtjev)
            {
                return true;
            }

            return false;
        }

        private bool ProvjeraPrijateljstva(Korisnik primatelj, Korisnik pozivatelj)
        {
            bool postojiZahtjev = false;
            string upit = "SELECT Id FROM prijatelji WHERE (korisnik1='" + pozivatelj.Id + "' AND korisnik2='" + primatelj.Id + "') OR (korisnik1='" + primatelj.Id + "' AND korisnik2='" + pozivatelj.Id + "');";
            SqlDataReader dataReader = BazaPodataka.Instanca.DohvatiDataReader(upit);
            postojiZahtjev = dataReader.HasRows;
            dataReader.Close();
            if (postojiZahtjev)
            {
                return true;
            }

            return false;
        }

        private bool ProvjeriNovePoruke()
        {
            string upit = "SELECT korisnicko_ime FROM privatne_poruke " +
                "INNER JOIN korisnik ON korisnik.korisnik_id=privatne_poruke.posiljatelj " +
                "WHERE primatelj= '" + korisnik.Id + "' AND procitano = '0';";
            var posiljateljKorIme = BazaPodataka.Instanca.DohvatiVrijednost(upit);
            if (posiljateljKorIme != null)
            {
                posiljatelj = DohvatiKorisnika(posiljateljKorIme.ToString());
                PrivatnePoruke.OznaciKaoProcitano(posiljatelj, korisnik);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void notifyIconPoruke_Click(object sender, EventArgs e)
        {
            OtvoriPrivatnePoruke();
        }

        private void notifyIconPoruke_BalloonTipClicked(object sender, EventArgs e)
        {
            OtvoriPrivatnePoruke();
        }

        private Korisnik DohvatiKorisnika(string korIme)
        {
            string upit = "SELECT * FROM korisnik WHERE korisnicko_ime= '" + korIme + "';";
            SqlDataReader dataReader = BazaPodataka.Instanca.DohvatiDataReader(upit);
            Korisnik posiljatelj = new Korisnik();
            while (dataReader.Read())
            {
                posiljatelj.Id = int.Parse(dataReader["korisnik_id"].ToString());
                posiljatelj.KorisnickoIme = dataReader["korisnicko_ime"].ToString();
                posiljatelj.Lozinka = dataReader["lozinka"].ToString();
                posiljatelj.Email = dataReader["email"].ToString();
                posiljatelj.Ime = dataReader["ime"].ToString();
                dataReader["prezime"].ToString();
            }
            dataReader.Close();

            return posiljatelj;
        }

        private void OtvoriPrivatnePoruke()
        {
            PrivatnePoruke privatnePorukeForm = new PrivatnePoruke(korisnik, posiljatelj);
            privatnePorukeForm.ShowDialog();
        }
    }
}
