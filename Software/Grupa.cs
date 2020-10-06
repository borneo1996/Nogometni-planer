using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nogometni_planer
{
    public class Grupa
    {
        public int IDGrupe { get; set; }
        public string NazivGrupe { get; set; }
        public int AdminGrupe { get; set; }

        public List<Korisnik> listaClanova = new List<Korisnik>();


        public Grupa()
        {
        }

    }

    
}
