using System;
using System.Collections.Generic;

#nullable disable

namespace GESTIONDERECOUVREMENT.Models
{
    public partial class DModeler
    {
        public DModeler()
        {
            DComptets = new HashSet<DComptet>();
        }

        public int MrNo { get; set; }
        public string MrIntitule { get; set; }
        public int CbMarq { get; set; }
        public int? CbMarqSage { get; set; }
        public string CbCreateur { get; set; }
        public DateTime? CbModification { get; set; }

        public virtual ICollection<DComptet> DComptets { get; set; }
    }
}
