using System;
using System.Collections.Generic;

#nullable disable

namespace GESTIONDERECOUVREMENT.Models
{
    public partial class DCreglement
    {
        public DCreglement()
        {
            DRegleches = new HashSet<DReglech>();
        }

        public int RgNo { get; set; }
        public short? DoType { get; set; }
        public string DoPiece { get; set; }
        public string RgSouche { get; set; }
        public string RgPiece { get; set; }
        public string CtNumPayeur { get; set; }
        public DateTime? RgDate { get; set; }
        public string RgReference { get; set; }
        public string RgLibelle { get; set; }
        public decimal? RgMontant { get; set; }
        public decimal? RgMontantDev { get; set; }
        public short? NReglement { get; set; }
        public short? RgImpute { get; set; }
        public short? RgCompta { get; set; }
        public int? EcNo { get; set; }
        public short? RgType { get; set; }
        public decimal? RgCours { get; set; }
        public short? NDevise { get; set; }
        public string JoNum { get; set; }
        public string CgNumCont { get; set; }
        public DateTime? RgImpaye { get; set; }
        public string CgNum { get; set; }
        public int? RgDoc { get; set; }
        public short? RgTypeReg { get; set; }
        public string RgHeure { get; set; }
        public int? CaNo { get; set; }
        public int? CoNoCaissier { get; set; }
        public string CaNumCaisse { get; set; }
        public string CaCaissier { get; set; }
        public short? RgBanque { get; set; }
        public string RgCompteBq { get; set; }
        public short? RgTransfere { get; set; }
        public short RgCloture { get; set; }
        public short? RgTicket { get; set; }
        public string CtNumPayeurOrig { get; set; }
        public DateTime? RgDateEchCont { get; set; }
        public string CgNumEcart { get; set; }
        public string JoNumEcart { get; set; }
        public decimal? RgMontantEcart { get; set; }
        public int? RgNoBonAchat { get; set; }
        public string RgCommentaire { get; set; }
        public short? RgValorise { get; set; }
        public short? RgEtatR { get; set; }
        public string RgPieceRemplacer { get; set; }
        public string RgPieceTransferer { get; set; }
        public string RgPieceCloturer { get; set; }
        public int? CarCode { get; set; }
        public string ChNumSerie { get; set; }
        public int? DlNumRetenue { get; set; }
        public string TrNumSerie { get; set; }
        public DateTime? RgDateEscompte { get; set; }
        public int CbMarq { get; set; }
        public string CbCreateur { get; set; }
        public DateTime? CbModification { get; set; }

        public virtual PReglement NReglementNavigation { get; set; }
        public virtual ICollection<DReglech> DRegleches { get; set; }
    }
}
