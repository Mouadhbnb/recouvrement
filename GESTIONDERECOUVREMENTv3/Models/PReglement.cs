using System;
using System.Collections.Generic;

#nullable disable

namespace GESTIONDERECOUVREMENT.Models
{
    public partial class PReglement
    {
        public PReglement()
        {
            DCreglements = new HashSet<DCreglement>();
        }

        public string RIntitule { get; set; }
        public string RCode { get; set; }
        public string JoFnum { get; set; }
        public string JoCnum { get; set; }
        public short? RModePaieDebit { get; set; }
        public short? RModePaieCredit { get; set; }
        public string IbAfbdecaissPrinc { get; set; }
        public string IbAfbencaissPrinc { get; set; }
        public int? EbNoDecaiss { get; set; }
        public int? EbNoEncaiss { get; set; }
        public string REdiCode { get; set; }
        public short? CbIndice { get; set; }
        public short? RActive { get; set; }
        public int CbMarq { get; set; }
        public DateTime? CbModification { get; set; }
        public string CbCreateur { get; set; }

        public virtual ICollection<DCreglement> DCreglements { get; set; }
    }
}
