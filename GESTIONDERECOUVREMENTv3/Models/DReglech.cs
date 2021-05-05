using System;
using System.Collections.Generic;

#nullable disable

namespace GESTIONDERECOUVREMENT.Models
{
    public partial class DReglech
    {
        public int RgNo { get; set; }
        public int DrNo { get; set; }
        public int? MeId { get; set; }
        public int? MeNo { get; set; }
        public short? DoDomaine { get; set; }
        public short? DoType { get; set; }
        public string DoPiece { get; set; }
        public decimal? RcMontant { get; set; }
        public decimal? RcMontantImpute { get; set; }
        public short? RgTypeReg { get; set; }
        public short? RcEtat { get; set; }
        public string DoPieceOrigine { get; set; }
        public int CbMarq { get; set; }
        public string CbCreateur { get; set; }
        public DateTime? CbModification { get; set; }

        public virtual DMecheance MeNoNavigation { get; set; }
        public virtual DCreglement RgNoNavigation { get; set; }
    }
}
