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
    public partial class KreacijaGrupe : Form
    {
        public GrupeForm _grupeForm;
        public KreacijaGrupe(GrupeForm grupeForm)
        {
            InitializeComponent();
            _grupeForm = grupeForm;
            
        }

        private void kreacijaGrupe_Load(object sender, EventArgs e)
        {
            kreirajBtn.Enabled = false;
            labelOpaska.Text = "";
        }

        private void kreirajBtn_Click(object sender, EventArgs e)
        {
            string upit = "INSERT INTO [grupa] ([naziv], [admin]) VALUES ('" + textBoxNazivGrupe.Text + "', '" + _grupeForm.korisnik.Id + "')";
            BazaPodataka.Instanca.IzvrsiUpit(upit);
            int id_grupe = DohvatiIdKreiraneGrupe(textBoxNazivGrupe.Text, _grupeForm.korisnik.Id);
            upit = "INSERT INTO [administracija] ([admin], [grupa]) VALUES ('" + _grupeForm.korisnik.Id + "', '" + id_grupe + "')";
            BazaPodataka.Instanca.IzvrsiUpit(upit);
            Close();
        }

        private void odustaniBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxNazivGrupe_TextChanged(object sender, EventArgs e)
        {
            provjeraBtn();
        }


        private void provjeraBtn()
        {
            if(textBoxNazivGrupe.TextLength < 4)
            {
                kreirajBtn.Visible = false;
                odustaniBtn.Visible = false;
                labelOpaska.Text = "Ime grupe mora sadržavati barem 4 slova!";
            } else
            {
                kreirajBtn.Enabled = true;
                kreirajBtn.Visible = true;
                odustaniBtn.Visible = true;
                labelOpaska.Text = "";
                
            }
        }

        private int DohvatiIdKreiraneGrupe(string nazivGrupe, int adminID)
        {
            string upit = "SELECT [grupa_id] FROM [grupa] WHERE [naziv]='" + nazivGrupe + "' AND [admin]='" + adminID + "'";
            SqlDataReader dataReader = BazaPodataka.Instanca.DohvatiDataReader(upit);
            int grupaID = 0;
            while (dataReader.Read())
            {
                grupaID = int.Parse(dataReader["grupa_id"].ToString());
            }
            dataReader.Close();
            return grupaID;
        }
    }
}
