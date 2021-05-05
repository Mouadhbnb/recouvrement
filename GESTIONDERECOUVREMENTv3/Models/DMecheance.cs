using System;
using System.Collections.Generic;

#nullable disable

namespace GESTIONDERECOUVREMENT.Models
{
    public partial class DMecheance
    {
        public DMecheance()
        {
            DRegleches = new HashSet<DReglech>();
        }

        public int MeNo { get; set; }
        public short? MeDomaine { get; set; }
        public short? MeType { get; set; }
        public string MePiece { get; set; }
        public decimal? MePourcent { get; set; }
        public DateTime? MeDatePrevu { get; set; }
        public DateTime? MeDateDoc { get; set; }
        public DateTime? MeDateEcheance { get; set; }
        public short? MeModeReglement { get; set; }
        public int? MeId { get; set; }
        public decimal? MeMontant { get; set; }
        public decimal? MeMontantReste { get; set; }
        public short? MeRegle { get; set; }
        public string CtNum { get; set; }
        public int? MeNbrJour { get; set; }
        public string DoRepresentant { get; set; }
        public string DoRecouvreur { get; set; }
        public int CbMarq { get; set; }
        public string CbCreateur { get; set; }
        public DateTime? CbModification { get; set; }
        public DateTime? DatePromis { get; set; }
        public decimal? MontantPromis { get; set; }

        public virtual DComptet CtNumNavigation { get; set; }
        public virtual DDocentete MePieceNavigation { get; set; }
        public virtual ICollection<DReglech> DRegleches { get; set; }
    }
}
