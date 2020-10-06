using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baza
{
    public class BazaPodataka
    {
        private static BazaPodataka instanca;

        private string connectionString;

        private SqlConnection connection;

        public static BazaPodataka Instanca
        {
            get
            {
                if (instanca == null)
                {
                    instanca = new BazaPodataka();
                }
                return instanca;
            }
        }

        public string ConnectionString
        {
            get
            {
                return connectionString;
            }
            private set
            {
                connectionString = value;
            }
        }

        public SqlConnection Connection
        {
            get
            {
                return connection;
            }
            private set
            {
                connection = value;
            }
        }
        //konstruktor klase (otvaranje konekcije na bazu)
        private BazaPodataka()
        {
            ConnectionString = @"Server=31.147.204.119\PISERVER,1433; Database=PI20_069_DB; User Id=PI20_069_User; Password=_]YY$vV9";
            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
        }
        //zatvaranje konekcije sa bazom
        public void CloseConnection()
        {
            if (Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
            }
        }

        //dohvaca podatke na temelju upita
        public SqlDataReader DohvatiDataReader(string upit)
        {
            SqlCommand command = new SqlCommand(upit, Connection);
            return command.ExecuteReader();
        }

        //dohvaca skalarnu vrijednost
        public object DohvatiVrijednost(string upit)
        {
            SqlCommand command = new SqlCommand(upit, Connection);
            return command.ExecuteScalar();
        }

        public int IzvrsiUpit(string upit)
        {
            SqlCommand command = new SqlCommand(upit, Connection);
            return command.ExecuteNonQuery();
        }
    }
}
