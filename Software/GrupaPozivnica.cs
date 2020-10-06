using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nogometni_planer
{
    public class GrupaPozivnica
    {
        public int PozivnicaID { get; set; }
        public int GrupaID { get; set; }
        public string GrupaNaziv { get; set; }
        public string Pozivatelj { get; set; }
        public GrupaPozivnica()
        {

        }
    }
}
