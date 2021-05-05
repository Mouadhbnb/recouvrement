using System;
using System.Collections.Generic;

#nullable disable

namespace GESTIONDERECOUVREMENT.Models
{
    public partial class DComptet
    {
        public DComptet()
        {
            DDocentetes = new HashSet<DDocentete>();
            DLitiges = new HashSet<DLitige>();
            DMecheances = new HashSet<DMecheance>();
            DNotifications = new HashSet<DNotification>();
        }

        public string CtNum { get; set; }
        public string CtIntitule { get; set; }
        public short? CtType { get; set; }
        public string CgNumPrinc { get; set; }
        public string CtQualite { get; set; }
        public string CtClassement { get; set; }
        public string CtContact { get; set; }
        public string CtAdresse { get; set; }
        public string CtComplement { get; set; }
        public string CtCodePostal { get; set; }
        public string CtVille { get; set; }
        public string CtCodeRegion { get; set; }
        public string CtPays { get; set; }
        public string CtRaccourci { get; set; }
        public short? BtNum { get; set; }
        public short? NDevise { get; set; }
        public string CtApe { get; set; }
        public string CtIdentifiant { get; set; }
        public string CtSiret { get; set; }
        public string CtStatistique01 { get; set; }
        public string CtStatistique02 { get; set; }
        public string CtStatistique03 { get; set; }
        public string CtStatistique04 { get; set; }
        public string CtStatistique05 { get; set; }
        public string CtStatistique06 { get; set; }
        public string CtStatistique07 { get; set; }
        public string CtStatistique08 { get; set; }
        public string CtStatistique09 { get; set; }
        public string CtStatistique10 { get; set; }
        public string CtCommentaire { get; set; }
        public decimal? CtEncours { get; set; }
        public decimal? CtAssurance { get; set; }
        public string CtNumPayeur { get; set; }
        public short? NRisque { get; set; }
        public int? CoNo { get; set; }
        public short? NCatTarif { get; set; }
        public decimal? CtTaux01 { get; set; }
        public decimal? CtTaux02 { get; set; }
        public decimal? CtTaux03 { get; set; }
        public decimal? CtTaux04 { get; set; }
        public short? NCatCompta { get; set; }
        public short? NPeriod { get; set; }
        public short? CtFacture { get; set; }
        public short? CtBlfact { get; set; }
        public short? CtLangue { get; set; }
        public short? NExpedition { get; set; }
        public short? NCondition { get; set; }
        public DateTime? CtDateCreate { get; set; }
        public short? CtSaut { get; set; }
        public short? CtLettrage { get; set; }
        public short? CtValidEch { get; set; }
        public short? CtSommeil { get; set; }
        public int? DeNo { get; set; }
        public short? CtControlEnc { get; set; }
        public short? CtNotRappel { get; set; }
        public short? NAnalytique { get; set; }
        public string CaNum { get; set; }
        public string CtTelephone { get; set; }
        public string CtTelecopie { get; set; }
        public string CtEmail { get; set; }
        public string CtSite { get; set; }
        public string CtCoface { get; set; }
        public short? CtSurveillance { get; set; }
        public DateTime? CtSvDateCreate { get; set; }
        public string CtSvFormeJuri { get; set; }
        public string CtSvEffectif { get; set; }
        public decimal? CtSvCa { get; set; }
        public decimal? CtSvResultat { get; set; }
        public short? CtSvIncident { get; set; }
        public DateTime? CtSvDateIncid { get; set; }
        public short? CtSvPrivil { get; set; }
        public string CtSvRegul { get; set; }
        public string CtSvCotation { get; set; }
        public DateTime? CtSvDateMaj { get; set; }
        public string CtSvObjetMaj { get; set; }
        public DateTime? CtSvDateBilan { get; set; }
        public short? CtSvNbMoisBilan { get; set; }
        public short? NAnalytiqueIfrs { get; set; }
        public string CaNumIfrs { get; set; }
        public short? CtPrioriteLivr { get; set; }
        public short? CtLivrPartielle { get; set; }
        public int? MrNo { get; set; }
        public short? CtNotPenal { get; set; }
        public int? EbNo { get; set; }
        public DateTime? CtDateFermeDebut { get; set; }
        public DateTime? CtDateFermeFin { get; set; }
        public short? CtFactureElec { get; set; }
        public short? CtTypeNif { get; set; }
        public string CtRepresentInt { get; set; }
        public string CtRepresentNif { get; set; }
        public short? CtEdiCodeType { get; set; }
        public string CtEdiCode { get; set; }
        public string CtEdiCodeSage { get; set; }
        public short? CtProfilSoc { get; set; }
        public short? CtStatutContrat { get; set; }
        public DateTime? CtDateMaj { get; set; }
        public short? CtEchangeRappro { get; set; }
        public short? CtEchangeCr { get; set; }
        public int? PiNoEchange { get; set; }
        public short? CtBonApayer { get; set; }
        public short? CtDelaiTransport { get; set; }
        public short? CtDelaiAppro { get; set; }
        public string CtLangueIso2 { get; set; }
        public string CtNumCentrale { get; set; }
        public decimal? RValeur { get; set; }
        public string CtRecouvreur { get; set; }
        public decimal? CtSoldeComptable { get; set; }
        public decimal? CtSoldeCommercial { get; set; }
        public string CtSouche { get; set; }
        public int CbMarq { get; set; }
        public int? CbMarqSage { get; set; }
        public string CbCreateur { get; set; }
        public DateTime? CbModification { get; set; }
        public string CtTypeTaux02 { get; set; }
        public string CtTelephone1 { get; set; }
        public string CtTelephoneFix { get; set; }
        public string CtTelephonePoste { get; set; }
        public string CtLocalite { get; set; }
        public string CtProfile { get; set; }

        public virtual DEmploye CtRecouvreurNavigation { get; set; }
        public virtual DModeler MrNoNavigation { get; set; }
        public virtual ICollection<DDocentete> DDocentetes { get; set; }
        public virtual ICollection<DLitige> DLitiges { get; set; }
        public virtual ICollection<DMecheance> DMecheances { get; set; }
        public virtual ICollection<DNotification> DNotifications { get; set; }
    }
}
