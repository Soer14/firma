using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasStationApp
{
    public class DetailTransactionDto
    {
        public Guid Identyfikator { get; set; }
        public int NrRachunku { get; set; }
        public DateTime DataDostawy { get; set; }
        public int IdPartneraRozliczeniowego { get; set; }
        public string PelnyNrKarty { get; set; }
        public DateTime DataTransakcji { get; set; }
    }
}
