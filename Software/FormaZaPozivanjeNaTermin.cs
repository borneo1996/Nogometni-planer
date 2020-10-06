using Baza;
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

namespace Nogometni_planer
{
    public partial class FormaZaPozivanjeNaTermin : Form
    {
        Termin termin;
        Grupa grupa;
        Korisnik kor;
        List<Korisnik> listaClanova = new List<Korisnik>();
        List<Korisnik> listaClanovaGrupe = new List<Korisnik>();
        List<Korisnik> listaClanovaKojimaJePoslanaPozivnica = new List<Korisnik>();
        List<Korisnik> listaClanovaKojiSuVecNaListi = new List<Korisnik>();

        public FormaZaPozivanjeNaTermin(Termin t, Grupa g, Korisnik k)
        {
            termin = t;
            grupa = g;
            kor = k;
            InitializeComponent();
        }

        private void FormaZaPozivanjeNaTermin_Load(object sender, EventArgs e)
        {
            textBoxLokacija.Text = termin.Lokacija;
            textBoxVrijeme.Text = termin.DatumIVrijeme;

            listaClanovaGrupe = DohvatiClanoveGrupe(grupa, kor).ToList();
            listaClanovaKojimaJePoslanaPozivnica = DohvatiClanoveKojimaJeVecPoslanaPozivnica(termin);
            listaClanovaKojiSuVecNaListi = DohvatiClanoveKojiSuVecNaListiZaTermin(termin);
            listaClanova = SrediListuZaPozivanje(listaClanovaGrupe, listaClanovaKojimaJePoslanaPozivnica, listaClanovaKojiSuVecNaListi);
            OsvjeziDataGridView();

        }

        private List<Korisnik> SrediListuZaPozivanje(List<Korisnik> listaClanovaGrupe, List<Korisnik> listaClanovaKojimaJePoslanaPozivnica, List<Korisnik> listaClanovaKojiSuVecNaListi)
        {
            List<Korisnik> lista = new List<Korisnik>();
            List<Korisnik> listaPomocna = new List<Korisnik>();
            listaPomocna = listaClanovaGrupe.ToList();
            lista = listaClanovaGrupe.ToList();
            foreach (Korisnik korisn in listaPomocna)
            {
                foreach (Korisnik k in listaClanovaKojiSuVecNaListi)
                {
                    if (korisn.Id == k.Id)
                    {
                        lista.Remove(korisn);
                        break;
                    }
                }
            }
            foreach(Korisnik korisn in listaPomocna)
            {
                foreach (Korisnik k in listaClanovaKojimaJePoslanaPozivnica)
                {
                    if (korisn.Id == k.Id)
                    {
                        lista.Remove(korisn);
                        break;
                    }
                }
            }
            return lista;
        }

        private List<Korisnik> DohvatiClanoveKojiSuVecNaListiZaTermin(Termin t)
        {
            List<Korisnik> clanovi = new List<Korisnik>();
            string upit = "SELECT * FROM [korisnik] INNER JOIN [termini_korisnici] on [termini_korisnici].[korisnik]=[korisnik].[korisnik_id] WHERE [termini_korisnici].[termin]='" + t.Id +"'";
            SqlDataReader dataReader = BazaPodataka.Instanca.DohvatiDataReader(upit);
            Korisnik dohvaceniKorisnik;
            while (dataReader.Read())
            {
                dohvaceniKorisnik = new Korisnik();
                dohvaceniKorisnik = DohvatiPodatkeOKorisniku(dataReader);
                if (dohvaceniKorisnik.Id != kor.Id)
                {
                    clanovi.Add(dohvaceniKorisnik);
                }
            }
            dataReader.Close();
            return clanovi;
        }

        private List<Korisnik> DohvatiClanoveKojimaJeVecPoslanaPozivnica(Termin t)
        {
            List<Korisnik> clanovi = new List<Korisnik>();
            string upit = "SELECT * FROM [korisnik] INNER JOIN [termin_pozivnice] on [termin_pozivnice].[korisnik]=[korisnik].[korisnik_id] WHERE [termin_pozivnice].[termin]='" + t.Id + "' AND [termin_pozivnice].[odgovorena]='0'";
            SqlDataReader dataReader = BazaPodataka.Instanca.DohvatiDataReader(upit);
            Korisnik dohvaceniKorisnik;
            while (dataReader.Read())
            {
                dohvaceniKorisnik = new Korisnik();
                dohvaceniKorisnik = DohvatiPodatkeOKorisniku(dataReader);
                if (dohvaceniKorisnik.Id != kor.Id)
                {
                    clanovi.Add(dohvaceniKorisnik);
                }
            }
            dataReader.Close();
            return clanovi;
        }

        private void OsvjeziDataGridView()
        {
            dgvClanoviGrupe.DataSource = null;
            dgvClanoviGrupe.DataSource = listaClanova;
            dgvClanoviGrupe.AllowUserToResizeRows = false;
            dgvClanoviGrupe.RowHeadersVisible = false;
            dgvClanoviGrupe.AllowUserToResizeColumns = false;
            dgvClanoviGrupe.AllowUserToOrderColumns = false;
            for (int i = 0; i < dgvClanoviGrupe.Columns.Count; i++)
            {
                dgvClanoviGrupe.Columns[i].Visible = false;
            }
            dgvClanoviGrupe.Columns["KorisnickoIme"].Visible = true;
            dgvClanoviGrupe.Columns["KorisnickoIme"].HeaderText = "Korisnik";
            dgvClanoviGrupe.Columns["KorisnickoIme"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvClanoviGrupe.Columns["KorisnickoIme"].HeaderCell.Style.Font = new Font("Tahoma", 9F, FontStyle.Bold);
            if (listaClanova.Count > 0)
            {
                dgvClanoviGrupe.Rows[0].Selected = true;
            }
        }

        private List<Korisnik> DohvatiClanoveGrupe(Grupa g, Korisnik k)
        {
            List<Korisnik> clanovi = new List<Korisnik>();
            List<Korisnik> admini = new List<Korisnik>();
            List<Korisnik> obicniClanovi = new List<Korisnik>();
            string upit = "SELECT * FROM [korisnik] INNER JOIN [clanstvo] on [clanstvo].[korisnik]=[korisnik].[korisnik_id] WHERE [clanstvo].[grupa]='" + g.IDGrupe + "' AND NOT [korisnik].[korisnik_id]='" + k.Id + "'";
            SqlDataReader dataReader = BazaPodataka.Instanca.DohvatiDataReader(upit);
            Korisnik dohvaceniKorisnik;
            while (dataReader.Read())
            {
                dohvaceniKorisnik = new Korisnik();
                dohvaceniKorisnik = DohvatiPodatkeOKorisniku(dataReader);
                if (dohvaceniKorisnik.Id != kor.Id)
                {
                    obicniClanovi.Add(dohvaceniKorisnik);
                }
            }
            dataReader.Close();

            upit = "SELECT [korisnik].[korisnicko_ime], [korisnik].[korisnik_id] FROM [korisnik] INNER JOIN [administracija] on [administracija].[admin]=[korisnik].[korisnik_id] WHERE [administracija].[grupa]='" + g.IDGrupe + "'" +
                "UNION SELECT[korisnik].[korisnicko_ime], [korisnik].[korisnik_id] FROM[korisnik] INNER JOIN[grupa] on[grupa].[admin]=[korisnik].[korisnik_id] WHERE[grupa].[grupa_id]='" + g.IDGrupe + "'";
            dataReader = BazaPodataka.Instanca.DohvatiDataReader(upit);
            while (dataReader.Read())
            {
                dohvaceniKorisnik = new Korisnik();
                dohvaceniKorisnik = DohvatiPodatkeOKorisniku(dataReader);
                if (dohvaceniKorisnik.Id != kor.Id)
                {
                    admini.Add(dohvaceniKorisnik);
                }
            }
            dataReader.Close();
            clanovi = ProvjeriDuplikate(admini, obicniClanovi);
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

        private void posaljiPozivnicuBtn_Click(object sender, EventArgs e)
        {
            if (dgvClanoviGrupe.CurrentRow != null)
            {
                Korisnik k = dgvClanoviGrupe.CurrentRow.DataBoundItem as Korisnik;
                listaClanova.Remove(kor);
                listaClanova.Remove(k);
                string upit = "INSERT INTO [termin_pozivnice] ([korisnik], [termin], [odgovorena]) VALUES ('" + k.Id + "', '" + termin.Id + "', '0')";
                string upitKorisnik = "SELECT * FROM [termin_pozivnice] WHERE [termin_pozivnice].[korisnik]='" + k.Id + "' AND [termin_pozivnice].[termin]='" + termin.Id + "'";
                string upitKorisnik2 = "SELECT * FROM [termini_korisnici] WHERE [termini_korisnici].[korisnik]='" + k.Id + "' AND [termini_korisnici].[termin]='" + termin.Id + "'";
                if (PozivnicaJosNijePoslanaKorisniku(upitKorisnik) && KorisnikVecDodanZaTermin(upitKorisnik2))
                {
                    BazaPodataka.Instanca.IzvrsiUpit(upit);
                    labelNapomena.Text = "Pozivnica poslana korisniku!";
                    labelNapomena.ForeColor = Color.Green;
                } else
                {
                    labelNapomena.Text = "Korisnik je već pozvan na termin ili se već nalazi na listi!";
                    labelNapomena.ForeColor = Color.Blue;
                }
            }
            OsvjeziDataGridView();
        }

        private bool PozivnicaJosNijePoslanaKorisniku(string upit)
        {
            SqlDataReader dataReader = BazaPodataka.Instanca.DohvatiDataReader(upit);
            if (dataReader.Read())
            {
                dataReader.Close();
                return false;
            } else
            {
                dataReader.Close();
                return true;
            }
        }

        private bool KorisnikVecDodanZaTermin(string upit)
        {
            SqlDataReader dataReader = BazaPodataka.Instanca.DohvatiDataReader(upit);
            if (dataReader.Read())
            {
                dataReader.Close();
                return false;
            }
            else
            {
                dataReader.Close();
                return true;
            }
        }
    }
}
