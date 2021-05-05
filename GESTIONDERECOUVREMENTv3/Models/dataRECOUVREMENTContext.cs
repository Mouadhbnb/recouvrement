using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GESTIONDERECOUVREMENT.Models
{
    public partial class dataRECOUVREMENTContext : DbContext
    {
        public dataRECOUVREMENTContext()
        {
        }

        public dataRECOUVREMENTContext(DbContextOptions<dataRECOUVREMENTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DAttachement> DAttachements { get; set; }
        public virtual DbSet<DComptet> DComptets { get; set; }
        public virtual DbSet<DCreglement> DCreglements { get; set; }
        public virtual DbSet<DDocentete> DDocentetes { get; set; }
        public virtual DbSet<DDocligne> DDoclignes { get; set; }
        public virtual DbSet<DEmodeler> DEmodelers { get; set; }
        public virtual DbSet<DEmploye> DEmployes { get; set; }
        public virtual DbSet<DLitige> DLitiges { get; set; }
        public virtual DbSet<DMecheance> DMecheances { get; set; }
        public virtual DbSet<DModeler> DModelers { get; set; }
        public virtual DbSet<DNotification> DNotifications { get; set; }
        public virtual DbSet<DReglech> DRegleches { get; set; }
        public virtual DbSet<DScenario> DScenarios { get; set; }
        public virtual DbSet<PReglement> PReglements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=GESTIONDERECOUVREMENT");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "French_CI_AS");

            modelBuilder.Entity<DAttachement>(entity =>
            {
                entity.HasKey(e => e.IdAtt);

                entity.ToTable("D_ATTACHEMENT");

                entity.Property(e => e.IdAtt).HasColumnName("ID_Att");

                entity.Property(e => e.Audio)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Contenu)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Document)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DComptet>(entity =>
            {
                entity.HasKey(e => e.CbMarq);

                entity.ToTable("D_COMPTET");

                entity.HasIndex(e => e.CtNum, "IX_D_COMPTET")
                    .IsUnique();

                entity.Property(e => e.CbMarq).HasColumnName("cbMarq");

                entity.Property(e => e.BtNum).HasColumnName("BT_Num");

                entity.Property(e => e.CaNum)
                    .HasMaxLength(50)
                    .HasColumnName("CA_Num");

                entity.Property(e => e.CaNumIfrs)
                    .HasMaxLength(50)
                    .HasColumnName("CA_NumIFRS");

                entity.Property(e => e.CbCreateur)
                    .HasMaxLength(50)
                    .HasColumnName("cbCreateur");

                entity.Property(e => e.CbMarqSage).HasColumnName("cbMarqSage");

                entity.Property(e => e.CbModification)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("cbModification");

                entity.Property(e => e.CgNumPrinc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("CG_NumPrinc");

                entity.Property(e => e.CoNo).HasColumnName("CO_No");

                entity.Property(e => e.CtAdresse)
                    .HasMaxLength(200)
                    .HasColumnName("CT_Adresse");

                entity.Property(e => e.CtApe)
                    .HasMaxLength(50)
                    .HasColumnName("CT_Ape");

                entity.Property(e => e.CtAssurance)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("CT_Assurance");

                entity.Property(e => e.CtBlfact).HasColumnName("CT_BLFact");

                entity.Property(e => e.CtBonApayer).HasColumnName("CT_BonAPayer");

                entity.Property(e => e.CtClassement)
                    .HasMaxLength(117)
                    .HasColumnName("CT_Classement");

                entity.Property(e => e.CtCodePostal)
                    .HasMaxLength(50)
                    .HasColumnName("CT_CodePostal");

                entity.Property(e => e.CtCodeRegion)
                    .HasMaxLength(50)
                    .HasColumnName("CT_CodeRegion");

                entity.Property(e => e.CtCoface)
                    .HasMaxLength(50)
                    .HasColumnName("CT_Coface");

                entity.Property(e => e.CtCommentaire)
                    .HasMaxLength(300)
                    .HasColumnName("CT_Commentaire");

                entity.Property(e => e.CtComplement)
                    .HasMaxLength(150)
                    .HasColumnName("CT_Complement");

                entity.Property(e => e.CtContact)
                    .HasMaxLength(150)
                    .HasColumnName("CT_Contact");

                entity.Property(e => e.CtControlEnc).HasColumnName("CT_ControlEnc");

                entity.Property(e => e.CtDateCreate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("CT_DateCreate");

                entity.Property(e => e.CtDateFermeDebut)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("CT_DateFermeDebut");

                entity.Property(e => e.CtDateFermeFin)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("CT_DateFermeFin");

                entity.Property(e => e.CtDateMaj)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("CT_DateMAJ");

                entity.Property(e => e.CtDelaiAppro).HasColumnName("CT_DelaiAppro");

                entity.Property(e => e.CtDelaiTransport).HasColumnName("CT_DelaiTransport");

                entity.Property(e => e.CtEchangeCr).HasColumnName("CT_EchangeCR");

                entity.Property(e => e.CtEchangeRappro).HasColumnName("CT_EchangeRappro");

                entity.Property(e => e.CtEdiCode)
                    .HasMaxLength(50)
                    .HasColumnName("CT_EdiCode");

                entity.Property(e => e.CtEdiCodeSage)
                    .HasMaxLength(50)
                    .HasColumnName("CT_EdiCodeSage");

                entity.Property(e => e.CtEdiCodeType).HasColumnName("CT_EdiCodeType");

                entity.Property(e => e.CtEmail)
                    .HasMaxLength(69)
                    .HasColumnName("CT_EMail");

                entity.Property(e => e.CtEncours)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("CT_Encours");

                entity.Property(e => e.CtFacture).HasColumnName("CT_Facture");

                entity.Property(e => e.CtFactureElec).HasColumnName("CT_FactureElec");

                entity.Property(e => e.CtIdentifiant)
                    .HasMaxLength(50)
                    .HasColumnName("CT_Identifiant");

                entity.Property(e => e.CtIntitule)
                    .HasMaxLength(150)
                    .HasColumnName("CT_Intitule");

                entity.Property(e => e.CtLangue).HasColumnName("CT_Langue");

                entity.Property(e => e.CtLangueIso2)
                    .HasMaxLength(50)
                    .HasColumnName("CT_LangueISO2");

                entity.Property(e => e.CtLettrage).HasColumnName("CT_Lettrage");

                entity.Property(e => e.CtLivrPartielle).HasColumnName("CT_LivrPartielle");

                entity.Property(e => e.CtLocalite)
                    .HasMaxLength(50)
                    .HasColumnName("CT_Localite");

                entity.Property(e => e.CtNotPenal).HasColumnName("CT_NotPenal");

                entity.Property(e => e.CtNotRappel).HasColumnName("CT_NotRappel");

                entity.Property(e => e.CtNum)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("CT_Num");

                entity.Property(e => e.CtNumCentrale)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CT_NumCentrale");

                entity.Property(e => e.CtNumPayeur)
                    .HasMaxLength(50)
                    .HasColumnName("CT_NumPayeur");

                entity.Property(e => e.CtPays)
                    .HasMaxLength(50)
                    .HasColumnName("CT_Pays");

                entity.Property(e => e.CtPrioriteLivr).HasColumnName("CT_PrioriteLivr");

                entity.Property(e => e.CtProfilSoc).HasColumnName("CT_ProfilSoc");

                entity.Property(e => e.CtProfile)
                    .HasMaxLength(50)
                    .HasColumnName("CT_Profile");

                entity.Property(e => e.CtQualite)
                    .HasMaxLength(50)
                    .HasColumnName("CT_Qualite");

                entity.Property(e => e.CtRaccourci)
                    .HasMaxLength(50)
                    .HasColumnName("CT_Raccourci");

                entity.Property(e => e.CtRecouvreur)
                    .HasMaxLength(50)
                    .HasColumnName("CT_Recouvreur");

                entity.Property(e => e.CtRepresentInt)
                    .HasMaxLength(50)
                    .HasColumnName("CT_RepresentInt");

                entity.Property(e => e.CtRepresentNif)
                    .HasMaxLength(50)
                    .HasColumnName("CT_RepresentNIF");

                entity.Property(e => e.CtSaut).HasColumnName("CT_Saut");

                entity.Property(e => e.CtSiret)
                    .HasMaxLength(50)
                    .HasColumnName("CT_Siret");

                entity.Property(e => e.CtSite)
                    .HasMaxLength(69)
                    .HasColumnName("CT_Site");

                entity.Property(e => e.CtSoldeCommercial)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("CT_SoldeCommercial");

                entity.Property(e => e.CtSoldeComptable)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("CT_SoldeComptable");

                entity.Property(e => e.CtSommeil).HasColumnName("CT_Sommeil");

                entity.Property(e => e.CtSouche)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CT_Souche");

                entity.Property(e => e.CtStatistique01)
                    .HasMaxLength(50)
                    .HasColumnName("CT_Statistique01");

                entity.Property(e => e.CtStatistique02)
                    .HasMaxLength(50)
                    .HasColumnName("CT_Statistique02");

                entity.Property(e => e.CtStatistique03)
                    .HasMaxLength(50)
                    .HasColumnName("CT_Statistique03");

                entity.Property(e => e.CtStatistique04)
                    .HasMaxLength(50)
                    .HasColumnName("CT_Statistique04");

                entity.Property(e => e.CtStatistique05)
                    .HasMaxLength(50)
                    .HasColumnName("CT_Statistique05");

                entity.Property(e => e.CtStatistique06)
                    .HasMaxLength(50)
                    .HasColumnName("CT_Statistique06");

                entity.Property(e => e.CtStatistique07)
                    .HasMaxLength(50)
                    .HasColumnName("CT_Statistique07");

                entity.Property(e => e.CtStatistique08)
                    .HasMaxLength(50)
                    .HasColumnName("CT_Statistique08");

                entity.Property(e => e.CtStatistique09)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CT_Statistique09");

                entity.Property(e => e.CtStatistique10)
                    .HasMaxLength(50)
                    .HasColumnName("CT_Statistique10");

                entity.Property(e => e.CtStatutContrat).HasColumnName("CT_StatutContrat");

                entity.Property(e => e.CtSurveillance).HasColumnName("CT_Surveillance");

                entity.Property(e => e.CtSvCa)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("CT_SvCA");

                entity.Property(e => e.CtSvCotation)
                    .HasMaxLength(50)
                    .HasColumnName("CT_SvCotation");

                entity.Property(e => e.CtSvDateBilan)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("CT_SvDateBilan");

                entity.Property(e => e.CtSvDateCreate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("CT_SvDateCreate");

                entity.Property(e => e.CtSvDateIncid)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("CT_SvDateIncid");

                entity.Property(e => e.CtSvDateMaj)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("CT_SvDateMaj");

                entity.Property(e => e.CtSvEffectif)
                    .HasMaxLength(50)
                    .HasColumnName("CT_SvEffectif");

                entity.Property(e => e.CtSvFormeJuri)
                    .HasMaxLength(50)
                    .HasColumnName("CT_SvFormeJuri");

                entity.Property(e => e.CtSvIncident).HasColumnName("CT_SvIncident");

                entity.Property(e => e.CtSvNbMoisBilan).HasColumnName("CT_SvNbMoisBilan");

                entity.Property(e => e.CtSvObjetMaj)
                    .HasMaxLength(50)
                    .HasColumnName("CT_SvObjetMaj");

                entity.Property(e => e.CtSvPrivil).HasColumnName("CT_SvPrivil");

                entity.Property(e => e.CtSvRegul)
                    .HasMaxLength(50)
                    .HasColumnName("CT_SvRegul");

                entity.Property(e => e.CtSvResultat)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("CT_SvResultat");

                entity.Property(e => e.CtTaux01)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("CT_Taux01");

                entity.Property(e => e.CtTaux02)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("CT_Taux02");

                entity.Property(e => e.CtTaux03)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("CT_Taux03");

                entity.Property(e => e.CtTaux04)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("CT_Taux04");

                entity.Property(e => e.CtTelecopie)
                    .HasMaxLength(50)
                    .HasColumnName("CT_Telecopie");

                entity.Property(e => e.CtTelephone)
                    .HasMaxLength(150)
                    .HasColumnName("CT_Telephone");

                entity.Property(e => e.CtTelephone1)
                    .HasMaxLength(50)
                    .HasColumnName("CT_Telephone1");

                entity.Property(e => e.CtTelephoneFix)
                    .HasMaxLength(50)
                    .HasColumnName("CT_TelephoneFix");

                entity.Property(e => e.CtTelephonePoste)
                    .HasMaxLength(50)
                    .HasColumnName("CT_TelephonePoste");

                entity.Property(e => e.CtType).HasColumnName("CT_Type");

                entity.Property(e => e.CtTypeNif).HasColumnName("CT_TypeNIF");

                entity.Property(e => e.CtTypeTaux02)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CT_TypeTaux02");

                entity.Property(e => e.CtValidEch).HasColumnName("CT_ValidEch");

                entity.Property(e => e.CtVille)
                    .HasMaxLength(50)
                    .HasColumnName("CT_Ville");

                entity.Property(e => e.DeNo).HasColumnName("DE_No");

                entity.Property(e => e.EbNo).HasColumnName("EB_No");

                entity.Property(e => e.MrNo).HasColumnName("MR_No");

                entity.Property(e => e.NAnalytique).HasColumnName("N_Analytique");

                entity.Property(e => e.NAnalytiqueIfrs).HasColumnName("N_AnalytiqueIFRS");

                entity.Property(e => e.NCatCompta).HasColumnName("N_CatCompta");

                entity.Property(e => e.NCatTarif).HasColumnName("N_CatTarif");

                entity.Property(e => e.NCondition).HasColumnName("N_Condition");

                entity.Property(e => e.NDevise).HasColumnName("N_Devise");

                entity.Property(e => e.NExpedition).HasColumnName("N_Expedition");

                entity.Property(e => e.NPeriod).HasColumnName("N_Period");

                entity.Property(e => e.NRisque).HasColumnName("N_Risque");

                entity.Property(e => e.PiNoEchange).HasColumnName("PI_NoEchange");

                entity.Property(e => e.RValeur)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("R_Valeur");

                entity.HasOne(d => d.CtRecouvreurNavigation)
                    .WithMany(p => p.DComptets)
                    .HasPrincipalKey(p => p.EmCode)
                    .HasForeignKey(d => d.CtRecouvreur)
                    .HasConstraintName("FK_D_COMPTET_D_EMPLOYES");

                entity.HasOne(d => d.MrNoNavigation)
                    .WithMany(p => p.DComptets)
                    .HasForeignKey(d => d.MrNo)
                    .HasConstraintName("FK_D_COMPTET_D_MODELER");
            });

            modelBuilder.Entity<DCreglement>(entity =>
            {
                entity.HasKey(e => e.RgNo);

                entity.ToTable("D_CREGLEMENT");

                entity.Property(e => e.RgNo)
                    .ValueGeneratedNever()
                    .HasColumnName("RG_No");

                entity.Property(e => e.CaCaissier)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CA_Caissier");

                entity.Property(e => e.CaNo).HasColumnName("CA_No");

                entity.Property(e => e.CaNumCaisse)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CA_NumCaisse");

                entity.Property(e => e.CarCode).HasColumnName("CAR_Code");

                entity.Property(e => e.CbCreateur)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cbCreateur");

                entity.Property(e => e.CbMarq)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("cbMarq");

                entity.Property(e => e.CbModification)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("cbModification");

                entity.Property(e => e.CgNum)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CG_Num");

                entity.Property(e => e.CgNumCont)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CG_NumCont");

                entity.Property(e => e.CgNumEcart)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CG_NumEcart");

                entity.Property(e => e.ChNumSerie)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CH_NumSerie");

                entity.Property(e => e.CoNoCaissier).HasColumnName("CO_NoCaissier");

                entity.Property(e => e.CtNumPayeur)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CT_NumPayeur");

                entity.Property(e => e.CtNumPayeurOrig)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CT_NumPayeurOrig");

                entity.Property(e => e.DlNumRetenue).HasColumnName("DL_NumRetenue");

                entity.Property(e => e.DoPiece)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DO_Piece");

                entity.Property(e => e.DoType).HasColumnName("DO_Type");

                entity.Property(e => e.EcNo).HasColumnName("EC_No");

                entity.Property(e => e.JoNum)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("JO_Num");

                entity.Property(e => e.JoNumEcart)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("JO_NumEcart");

                entity.Property(e => e.NDevise).HasColumnName("N_Devise");

                entity.Property(e => e.NReglement).HasColumnName("N_Reglement");

                entity.Property(e => e.RgBanque).HasColumnName("RG_Banque");

                entity.Property(e => e.RgCloture).HasColumnName("RG_Cloture");

                entity.Property(e => e.RgCommentaire)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("RG_Commentaire");

                entity.Property(e => e.RgCompta).HasColumnName("RG_Compta");

                entity.Property(e => e.RgCompteBq)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RG_CompteBQ");

                entity.Property(e => e.RgCours)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("RG_Cours");

                entity.Property(e => e.RgDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("RG_Date");

                entity.Property(e => e.RgDateEchCont)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("RG_DateEchCont");

                entity.Property(e => e.RgDateEscompte)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("RG_DateEscompte");

                entity.Property(e => e.RgDoc).HasColumnName("RG_Doc");

                entity.Property(e => e.RgEtatR).HasColumnName("RG_EtatR");

                entity.Property(e => e.RgHeure)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("RG_Heure")
                    .IsFixedLength(true);

                entity.Property(e => e.RgImpaye)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("RG_Impaye");

                entity.Property(e => e.RgImpute).HasColumnName("RG_Impute");

                entity.Property(e => e.RgLibelle)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RG_Libelle");

                entity.Property(e => e.RgMontant)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("RG_Montant");

                entity.Property(e => e.RgMontantDev)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("RG_MontantDev");

                entity.Property(e => e.RgMontantEcart)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("RG_MontantEcart");

                entity.Property(e => e.RgNoBonAchat).HasColumnName("RG_NoBonAchat");

                entity.Property(e => e.RgPiece)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("RG_Piece");

                entity.Property(e => e.RgPieceCloturer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RG_PieceCloturer");

                entity.Property(e => e.RgPieceRemplacer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RG_PieceRemplacer");

                entity.Property(e => e.RgPieceTransferer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RG_PieceTransferer");

                entity.Property(e => e.RgReference)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RG_Reference");

                entity.Property(e => e.RgSouche)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RG_Souche");

                entity.Property(e => e.RgTicket).HasColumnName("RG_Ticket");

                entity.Property(e => e.RgTransfere).HasColumnName("RG_Transfere");

                entity.Property(e => e.RgType).HasColumnName("RG_Type");

                entity.Property(e => e.RgTypeReg).HasColumnName("RG_TypeReg");

                entity.Property(e => e.RgValorise).HasColumnName("RG_Valorise");

                entity.Property(e => e.TrNumSerie)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TR_NumSerie");

                entity.HasOne(d => d.NReglementNavigation)
                    .WithMany(p => p.DCreglements)
                    .HasPrincipalKey(p => p.CbIndice)
                    .HasForeignKey(d => d.NReglement)
                    .HasConstraintName("FK_D_CREGLEMENT_P_REGLEMENT");
            });

            modelBuilder.Entity<DDocentete>(entity =>
            {
                entity.HasKey(e => e.CbMarq)
                    .HasName("PK_D_DOCENTETE_1");

                entity.ToTable("D_DOCENTETE");

                entity.HasIndex(e => e.DoPiece, "IX_D_DOCENTETE")
                    .IsUnique();

                entity.Property(e => e.CbMarq).HasColumnName("cbMarq");

                entity.Property(e => e.Bfprod)
                    .HasMaxLength(50)
                    .HasColumnName("BFPROD");

                entity.Property(e => e.BqNo).HasColumnName("BQ_No");

                entity.Property(e => e.BtCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BT_Code");

                entity.Property(e => e.CbCreateur)
                    .HasMaxLength(50)
                    .HasColumnName("cbCreateur");

                entity.Property(e => e.CbModification)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("cbModification");

                entity.Property(e => e.CcCode)
                    .HasMaxLength(50)
                    .HasColumnName("CC_Code");

                entity.Property(e => e.Central)
                    .HasMaxLength(50)
                    .HasColumnName("CENTRAL");

                entity.Property(e => e.Centraliste)
                    .HasMaxLength(50)
                    .HasColumnName("CENTRALISTE");

                entity.Property(e => e.CgNum)
                    .HasMaxLength(50)
                    .HasColumnName("CG_Num");

                entity.Property(e => e.DProjet)
                    .HasMaxLength(50)
                    .HasColumnName("D_Projet");

                entity.Property(e => e.DeCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DE_Code");

                entity.Property(e => e.DeCodeDest)
                    .HasMaxLength(50)
                    .HasColumnName("DE_CodeDest");

                entity.Property(e => e.DoArchive).HasColumnName("DO_ARCHIVE");

                entity.Property(e => e.DoBcpt).HasColumnName("DO_BCPT");

                entity.Property(e => e.DoCatCompta)
                    .HasMaxLength(50)
                    .HasColumnName("DO_CatCompta");

                entity.Property(e => e.DoCloture).HasColumnName("DO_Cloture");

                entity.Property(e => e.DoCoffre).HasColumnName("DO_Coffre");

                entity.Property(e => e.DoCommentaires).HasColumnName("DO_Commentaires");

                entity.Property(e => e.DoCondLiv)
                    .HasMaxLength(50)
                    .HasColumnName("DO_CondLiv");

                entity.Property(e => e.DoCoord01)
                    .HasMaxLength(100)
                    .HasColumnName("DO_Coord01");

                entity.Property(e => e.DoCoord02)
                    .HasMaxLength(100)
                    .HasColumnName("DO_Coord02");

                entity.Property(e => e.DoCours)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DO_Cours");

                entity.Property(e => e.DoDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DO_Date");

                entity.Property(e => e.DoDateBc)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DO_DateBC");

                entity.Property(e => e.DoDateBl)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DO_DateBL");

                entity.Property(e => e.DoDateDv)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DO_DateDV");

                entity.Property(e => e.DoDateExonoration)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DO_DateExonoration");

                entity.Property(e => e.DoDateFa)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DO_DateFA");

                entity.Property(e => e.DoDateLivPrev)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DO_DateLivPrev");

                entity.Property(e => e.DoDateLivr)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DO_DateLivr");

                entity.Property(e => e.DoDateLivrRealisee)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DO_DateLivrRealisee");

                entity.Property(e => e.DoDevise).HasColumnName("DO_Devise");

                entity.Property(e => e.DoDiffIndex)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DO_DiffIndex");

                entity.Property(e => e.DoDomaine).HasColumnName("DO_Domaine");

                entity.Property(e => e.DoEcart)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DO_Ecart");

                entity.Property(e => e.DoEcartDevise)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DO_EcartDevise");

                entity.Property(e => e.DoEscompte)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DO_Escompte");

                entity.Property(e => e.DoEtatPay).HasColumnName("DO_EtatPay");

                entity.Property(e => e.DoExonoration)
                    .HasMaxLength(50)
                    .HasColumnName("DO_Exonoration");

                entity.Property(e => e.DoIndDeb)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DO_IndDeb");

                entity.Property(e => e.DoIndFin)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DO_IndFin");

                entity.Property(e => e.DoLieuLiv).HasColumnName("DO_LieuLiv");

                entity.Property(e => e.DoModExpo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DO_ModExpo");

                entity.Property(e => e.DoMontantRest)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DO_MontantRest");

                entity.Property(e => e.DoNature).HasColumnName("DO_Nature");

                entity.Property(e => e.DoNbreColis)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("DO_NbreColis");

                entity.Property(e => e.DoNumBl)
                    .HasMaxLength(50)
                    .HasColumnName("DO_NumBL");

                entity.Property(e => e.DoNumFa)
                    .HasMaxLength(50)
                    .HasColumnName("DO_NumFA");

                entity.Property(e => e.DoPerte)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DO_Perte");

                entity.Property(e => e.DoPiece)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("DO_Piece");

                entity.Property(e => e.DoPieceBav)
                    .HasMaxLength(50)
                    .HasColumnName("DO_PieceBAV");

                entity.Property(e => e.DoPieceBc)
                    .HasMaxLength(50)
                    .HasColumnName("DO_PieceBC");

                entity.Property(e => e.DoPieceBl)
                    .HasMaxLength(50)
                    .HasColumnName("DO_PieceBL");

                entity.Property(e => e.DoPieceBret)
                    .HasMaxLength(50)
                    .HasColumnName("DO_PieceBRet");

                entity.Property(e => e.DoPieceDa)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DO_PieceDA");

                entity.Property(e => e.DoPieceDv)
                    .HasMaxLength(50)
                    .HasColumnName("DO_PieceDV");

                entity.Property(e => e.DoPieceFa)
                    .HasMaxLength(50)
                    .HasColumnName("DO_PieceFA");

                entity.Property(e => e.DoPieceOp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DO_PieceOP");

                entity.Property(e => e.DoPoidsBrut)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DO_PoidsBrut");

                entity.Property(e => e.DoPoidsNet)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DO_PoidsNet");

                entity.Property(e => e.DoPrint).HasColumnName("DO_Print");

                entity.Property(e => e.DoProvenance).HasColumnName("DO_Provenance");

                entity.Property(e => e.DoRecouvreur)
                    .HasMaxLength(50)
                    .HasColumnName("DO_Recouvreur");

                entity.Property(e => e.DoRemise)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DO_Remise");

                entity.Property(e => e.DoRepresentant)
                    .HasMaxLength(50)
                    .HasColumnName("DO_Representant");

                entity.Property(e => e.DoSommeQte)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DO_SommeQte");

                entity.Property(e => e.DoSouche)
                    .HasMaxLength(50)
                    .HasColumnName("DO_Souche");

                entity.Property(e => e.DoSt).HasColumnName("DO_ST");

                entity.Property(e => e.DoStatut)
                    .HasMaxLength(50)
                    .HasColumnName("DO_Statut");

                entity.Property(e => e.DoTauxEscompte)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DO_TauxEscompte");

                entity.Property(e => e.DoTauxEscompteDevise)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DO_TauxEscompteDevise");

                entity.Property(e => e.DoTiers)
                    .HasMaxLength(50)
                    .HasColumnName("DO_Tiers");

                entity.Property(e => e.DoTotalHt)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DO_TotalHT");

                entity.Property(e => e.DoTotalHtdev)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DO_TotalHTDev");

                entity.Property(e => e.DoTotalNetHt)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DO_TotalNetHT");

                entity.Property(e => e.DoTotalNetHtdev)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DO_TotalNetHTDev");

                entity.Property(e => e.DoTotalTtc)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DO_TotalTTC");

                entity.Property(e => e.DoType).HasColumnName("DO_Type");

                entity.Property(e => e.DoTypeColis)
                    .HasMaxLength(50)
                    .HasColumnName("DO_TypeColis");

                entity.Property(e => e.DoTypeRemise).HasColumnName("DO_TypeRemise");

                entity.Property(e => e.DoValide).HasColumnName("DO_Valide");

                entity.Property(e => e.DoValiditeExonoration)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DO_ValiditeExonoration");

                entity.Property(e => e.DoValorisation).HasColumnName("DO_Valorisation");

                entity.Property(e => e.DoValorisationDevise).HasColumnName("DO_ValorisationDevise");

                entity.Property(e => e.EbNo).HasColumnName("EB_No");

                entity.Property(e => e.EcNo).HasColumnName("EC_No");

                entity.Property(e => e.EmCode)
                    .HasMaxLength(50)
                    .HasColumnName("EM_Code");

                entity.Property(e => e.EmCodeDemandeur)
                    .HasMaxLength(50)
                    .HasColumnName("EM_CodeDemandeur");

                entity.Property(e => e.EmCodeDemarcheur)
                    .HasMaxLength(50)
                    .HasColumnName("EM_CodeDemarcheur");

                entity.Property(e => e.EmCodeRespProd)
                    .HasMaxLength(50)
                    .HasColumnName("EM_CodeRespPROD");

                entity.Property(e => e.EmCodeTransProd)
                    .HasMaxLength(50)
                    .HasColumnName("EM_CodeTransPROD");

                entity.Property(e => e.EmCodeTransporteur)
                    .HasMaxLength(50)
                    .HasColumnName("EM_CodeTransporteur");

                entity.Property(e => e.EmpCode)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMP_Code");

                entity.Property(e => e.GrCode)
                    .HasMaxLength(50)
                    .HasColumnName("GR_Code");

                entity.Property(e => e.Heure)
                    .HasMaxLength(50)
                    .HasColumnName("HEURE");

                entity.Property(e => e.LivraisonSemaine)
                    .HasMaxLength(50)
                    .HasColumnName("LIVRAISON (Semaine)");

                entity.Property(e => e.MeNo).HasColumnName("ME_No");

                entity.Property(e => e.MrNo).HasColumnName("MR_No");

                entity.Property(e => e.NCatCompta).HasColumnName("N_CatCompta");

                entity.Property(e => e.Pompe)
                    .HasMaxLength(50)
                    .HasColumnName("POMPE");

                entity.Property(e => e.Pompiste)
                    .HasMaxLength(50)
                    .HasColumnName("POMPISTE");

                entity.Property(e => e.Prodqtebl)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("PRODQTEBL");

                entity.Property(e => e.RpCode)
                    .HasMaxLength(50)
                    .HasColumnName("RP_Code");

                entity.Property(e => e.RpCodeTransProd)
                    .HasMaxLength(50)
                    .HasColumnName("RP_CodeTransPROD");

                entity.Property(e => e.RpCodeUniteProd)
                    .HasMaxLength(50)
                    .HasColumnName("RP_CodeUnitePROD");

                entity.Property(e => e.Silos)
                    .HasMaxLength(50)
                    .HasColumnName("SILOS");

                entity.HasOne(d => d.DoTiersNavigation)
                    .WithMany(p => p.DDocentetes)
                    .HasPrincipalKey(p => p.CtNum)
                    .HasForeignKey(d => d.DoTiers)
                    .HasConstraintName("FK_D_DOCENTETE_D_COMPTET");
            });

            modelBuilder.Entity<DDocligne>(entity =>
            {
                entity.HasKey(e => e.CbMarq);

                entity.ToTable("D_DOCLIGNE");

                entity.Property(e => e.CbMarq).HasColumnName("cbMarq");

                entity.Property(e => e.ARecevoir)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("A RECEVOIR");

                entity.Property(e => e.AeCommentaire)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("AE_Commentaire");

                entity.Property(e => e.AfRefFourniss)
                    .HasMaxLength(50)
                    .HasColumnName("AF_RefFourniss");

                entity.Property(e => e.AgCodeBarre)
                    .HasMaxLength(50)
                    .HasColumnName("AG_CodeBarre");

                entity.Property(e => e.AgRef)
                    .HasMaxLength(50)
                    .HasColumnName("AG_Ref");

                entity.Property(e => e.ArRef)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AR_Ref");

                entity.Property(e => e.ArRefComp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AR_RefComp");

                entity.Property(e => e.BtCode)
                    .HasMaxLength(50)
                    .HasColumnName("BT_Code");

                entity.Property(e => e.CaNum)
                    .HasMaxLength(50)
                    .HasColumnName("CA_Num");

                entity.Property(e => e.CbCreateur)
                    .HasMaxLength(50)
                    .HasColumnName("cbCreateur");

                entity.Property(e => e.CbMarqArt).HasColumnName("cbMarqArt");

                entity.Property(e => e.CbMarqArtComp).HasColumnName("cbMarqArtComp");

                entity.Property(e => e.CbMarqCr).HasColumnName("cbMarqCR");

                entity.Property(e => e.CbModification)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("cbModification");

                entity.Property(e => e.CcCode)
                    .HasMaxLength(50)
                    .HasColumnName("CC_Code");

                entity.Property(e => e.CgNum)
                    .HasMaxLength(50)
                    .HasColumnName("CG_Num");

                entity.Property(e => e.CoBa)
                    .HasMaxLength(50)
                    .HasColumnName("CO_BA");

                entity.Property(e => e.CoBc)
                    .HasMaxLength(50)
                    .HasColumnName("CO_BC");

                entity.Property(e => e.CoBl)
                    .HasMaxLength(50)
                    .HasColumnName("CO_BL");

                entity.Property(e => e.CoBp)
                    .HasMaxLength(50)
                    .HasColumnName("CO_BP");

                entity.Property(e => e.CoBr)
                    .HasMaxLength(50)
                    .HasColumnName("CO_BR");

                entity.Property(e => e.CoDv)
                    .HasMaxLength(50)
                    .HasColumnName("CO_DV");

                entity.Property(e => e.CoFa)
                    .HasMaxLength(50)
                    .HasColumnName("CO_FA");

                entity.Property(e => e.CoFaa)
                    .HasMaxLength(50)
                    .HasColumnName("CO_FAA");

                entity.Property(e => e.CoFar)
                    .HasMaxLength(50)
                    .HasColumnName("CO_FAR");

                entity.Property(e => e.CtNum)
                    .HasMaxLength(50)
                    .HasColumnName("CT_Num");

                entity.Property(e => e.DProjet)
                    .HasMaxLength(50)
                    .HasColumnName("D_Projet");

                entity.Property(e => e.DateVisitTech).HasColumnType("datetime");

                entity.Property(e => e.DeCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DE_Code");

                entity.Property(e => e.DeCodeDest)
                    .HasMaxLength(50)
                    .HasColumnName("DE_CodeDest");

                entity.Property(e => e.DlCmup)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_CMUP");

                entity.Property(e => e.DlCodeFormule)
                    .HasMaxLength(50)
                    .HasColumnName("DL_CodeFormule");

                entity.Property(e => e.DlCodeTaxe1)
                    .HasMaxLength(25)
                    .HasColumnName("DL_CodeTaxe1");

                entity.Property(e => e.DlCodeTaxe2)
                    .HasMaxLength(25)
                    .HasColumnName("DL_CodeTaxe2");

                entity.Property(e => e.DlCodeTaxe3)
                    .HasMaxLength(25)
                    .HasColumnName("DL_CodeTaxe3");

                entity.Property(e => e.DlDatePieceBav)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DL_DatePieceBAV");

                entity.Property(e => e.DlDatePieceBc)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DL_DatePieceBC");

                entity.Property(e => e.DlDatePieceBl)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DL_DatePieceBL");

                entity.Property(e => e.DlDatePieceBp)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DL_DatePieceBP");

                entity.Property(e => e.DlDatePieceBret)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DL_DatePieceBRet");

                entity.Property(e => e.DlDatePieceCr)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DL_DatePieceCR");

                entity.Property(e => e.DlDatePieceDa)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DL_DatePieceDA");

                entity.Property(e => e.DlDatePieceDv)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DL_DatePieceDV");

                entity.Property(e => e.DlDatePieceFa)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DL_DatePieceFA");

                entity.Property(e => e.DlDatePieceFaa)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DL_DatePieceFAA");

                entity.Property(e => e.DlDatePieceFar)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DL_DatePieceFAR");

                entity.Property(e => e.DlDatePieceOp)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DL_DatePieceOP");

                entity.Property(e => e.DlDescription).HasColumnName("DL_Description");

                entity.Property(e => e.DlDesign).HasColumnName("DL_Design");

                entity.Property(e => e.DlDesignGamme)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DL_DesignGamme");

                entity.Property(e => e.DlEscompte).HasColumnName("DL_Escompte");

                entity.Property(e => e.DlHauteur)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_Hauteur");

                entity.Property(e => e.DlKiloAct)
                    .HasColumnType("numeric(26, 4)")
                    .HasColumnName("DL_KiloAct");

                entity.Property(e => e.DlKilometrage)
                    .HasColumnType("numeric(26, 4)")
                    .HasColumnName("DL_Kilometrage");

                entity.Property(e => e.DlLargeur)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_Largeur");

                entity.Property(e => e.DlLongueur)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_Longueur");

                entity.Property(e => e.DlMontantHt)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_MontantHT");

                entity.Property(e => e.DlMontantHtnet)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_MontantHTNet");

                entity.Property(e => e.DlMontantTtc)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_MontantTTC");

                entity.Property(e => e.DlMvtStock).HasColumnName("DL_MvtStock");

                entity.Property(e => e.DlNatureFormule)
                    .HasMaxLength(50)
                    .HasColumnName("DL_NatureFormule");

                entity.Property(e => e.DlNbreColis)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_NbreColis");

                entity.Property(e => e.DlNo).HasColumnName("DL_No");

                entity.Property(e => e.DlNombreArt)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_NombreArt");

                entity.Property(e => e.DlPieceBav)
                    .HasMaxLength(50)
                    .HasColumnName("DL_PieceBAV");

                entity.Property(e => e.DlPieceBc)
                    .HasMaxLength(50)
                    .HasColumnName("DL_PieceBC");

                entity.Property(e => e.DlPieceBl)
                    .HasMaxLength(50)
                    .HasColumnName("DL_PieceBL");

                entity.Property(e => e.DlPieceBp)
                    .HasMaxLength(50)
                    .HasColumnName("DL_PieceBP");

                entity.Property(e => e.DlPieceBret)
                    .HasMaxLength(50)
                    .HasColumnName("DL_PieceBRet");

                entity.Property(e => e.DlPieceCr)
                    .HasMaxLength(50)
                    .HasColumnName("DL_PieceCR");

                entity.Property(e => e.DlPieceDa)
                    .HasMaxLength(50)
                    .HasColumnName("DL_PieceDA");

                entity.Property(e => e.DlPieceDv)
                    .HasMaxLength(50)
                    .HasColumnName("DL_PieceDV");

                entity.Property(e => e.DlPieceFa)
                    .HasMaxLength(50)
                    .HasColumnName("DL_PieceFA");

                entity.Property(e => e.DlPieceFaa)
                    .HasMaxLength(50)
                    .HasColumnName("DL_PieceFAA");

                entity.Property(e => e.DlPieceFar)
                    .HasMaxLength(50)
                    .HasColumnName("DL_PieceFAR");

                entity.Property(e => e.DlPieceOp)
                    .HasMaxLength(50)
                    .HasColumnName("DL_PieceOP");

                entity.Property(e => e.DlPoidBrut)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_PoidBrut");

                entity.Property(e => e.DlPoidNet)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_PoidNet");

                entity.Property(e => e.DlPrixUnitaire)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_PrixUnitaire");

                entity.Property(e => e.DlPrixUnitaireDev)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_PrixUnitaireDev");

                entity.Property(e => e.DlPunetHt)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_PUNetHT");

                entity.Property(e => e.DlPunetHtdev)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_PUNetHTDev");

                entity.Property(e => e.DlPuttc)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_PUTTC");

                entity.Property(e => e.DlQte)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_Qte");

                entity.Property(e => e.DlQteBav)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_Qte_BAV");

                entity.Property(e => e.DlQteBc)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_Qte_BC");

                entity.Property(e => e.DlQteBl)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_Qte_BL");

                entity.Property(e => e.DlQteBp)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_Qte_BP");

                entity.Property(e => e.DlQteBret)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_Qte_BRet");

                entity.Property(e => e.DlQteCr)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_Qte_CR");

                entity.Property(e => e.DlQteDa)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_Qte_DA");

                entity.Property(e => e.DlQteDepot)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_QteDepot");

                entity.Property(e => e.DlQteDv)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_Qte_DV");

                entity.Property(e => e.DlQteFa)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_Qte_FA");

                entity.Property(e => e.DlQteFaa)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_Qte_FAA");

                entity.Property(e => e.DlQteFar)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_Qte_FAR");

                entity.Property(e => e.DlQteOp)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_Qte_OP");

                entity.Property(e => e.DlQteParColis)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_QteParColis");

                entity.Property(e => e.DlQteRes)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_QteRes");

                entity.Property(e => e.DlQteSto)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_QteSto");

                entity.Property(e => e.DlRefOrig)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DL_RefOrig");

                entity.Property(e => e.DlRemise)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_Remise");

                entity.Property(e => e.DlRemise2)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_Remise_2");

                entity.Property(e => e.DlRemise3)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_Remise_3");

                entity.Property(e => e.DlSolde).HasColumnName("DL_Solde");

                entity.Property(e => e.DlTaxe1)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_Taxe1");

                entity.Property(e => e.DlTaxe2)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_Taxe2");

                entity.Property(e => e.DlTaxe3)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_Taxe3");

                entity.Property(e => e.DlTnomencl).HasColumnName("DL_TNomencl");

                entity.Property(e => e.DlTtc).HasColumnName("DL_TTC");

                entity.Property(e => e.DlTypeColis)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DL_TypeColis");

                entity.Property(e => e.DlUnite)
                    .HasMaxLength(50)
                    .HasColumnName("DL_Unite");

                entity.Property(e => e.DlUtilisation)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_Utilisation");

                entity.Property(e => e.DlUtilisationAct)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("DL_UtilisationAct");

                entity.Property(e => e.DlValorise).HasColumnName("DL_Valorise");

                entity.Property(e => e.DlZone)
                    .HasMaxLength(50)
                    .HasColumnName("DL_Zone");

                entity.Property(e => e.DoAvenant).HasColumnName("DO_Avenant");

                entity.Property(e => e.DoDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DO_Date");

                entity.Property(e => e.DoDateBl)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DO_DateBL");

                entity.Property(e => e.DoDateFa)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DO_DateFA");

                entity.Property(e => e.DoDateLivr)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DO_DateLivr");

                entity.Property(e => e.DoDomaine).HasColumnName("DO_Domaine");

                entity.Property(e => e.DoModExpo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DO_ModExpo");

                entity.Property(e => e.DoNumBl)
                    .HasMaxLength(50)
                    .HasColumnName("DO_NumBL");

                entity.Property(e => e.DoNumFa)
                    .HasMaxLength(50)
                    .HasColumnName("DO_NumFA");

                entity.Property(e => e.DoPiece)
                    .HasMaxLength(50)
                    .HasColumnName("DO_Piece");

                entity.Property(e => e.DoRecouvreur)
                    .HasMaxLength(50)
                    .HasColumnName("DO_Recouvreur");

                entity.Property(e => e.DoRepresentant)
                    .HasMaxLength(50)
                    .HasColumnName("DO_Representant");

                entity.Property(e => e.DoSouche)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DO_Souche");

                entity.Property(e => e.DoType).HasColumnName("DO_Type");

                entity.Property(e => e.EgEnumere1)
                    .HasMaxLength(100)
                    .HasColumnName("EG_Enumere1");

                entity.Property(e => e.EgEnumere2)
                    .HasMaxLength(100)
                    .HasColumnName("EG_Enumere2");

                entity.Property(e => e.EmCode)
                    .HasMaxLength(50)
                    .HasColumnName("EM_Code");

                entity.Property(e => e.EmCodeRespProd)
                    .HasMaxLength(50)
                    .HasColumnName("EM_CodeRespPROD");

                entity.Property(e => e.EmCodeTransProd)
                    .HasMaxLength(50)
                    .HasColumnName("EM_CodeTransPROD");

                entity.Property(e => e.EmCodeTransporteur)
                    .HasMaxLength(50)
                    .HasColumnName("EM_CodeTransporteur");

                entity.Property(e => e.Gamme1).HasMaxLength(50);

                entity.Property(e => e.Gamme2).HasMaxLength(50);

                entity.Property(e => e.Heure)
                    .HasMaxLength(50)
                    .HasColumnName("HEURE");

                entity.Property(e => e.LsNoSerie)
                    .HasMaxLength(50)
                    .HasColumnName("LS_NoSerie");

                entity.Property(e => e.NumeroFicheTech).HasMaxLength(50);

                entity.Property(e => e.PaiementCompl)
                    .HasMaxLength(50)
                    .HasColumnName("PAIEMENT COMPL");

                entity.Property(e => e.Pompe)
                    .HasMaxLength(50)
                    .HasColumnName("POMPE");

                entity.Property(e => e.Pompiste)
                    .HasMaxLength(50)
                    .HasColumnName("POMPISTE");

                entity.Property(e => e.Prodqtebl)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("PRODQTEBL");

                entity.Property(e => e.RpCode)
                    .HasMaxLength(50)
                    .HasColumnName("RP_Code");

                entity.Property(e => e.RpCodeTransProd)
                    .HasMaxLength(50)
                    .HasColumnName("RP_CodeTransPROD");

                entity.Property(e => e.RpCodeUniteProd)
                    .HasMaxLength(50)
                    .HasColumnName("RP_CodeUnitePROD");

                entity.Property(e => e.Silos)
                    .HasMaxLength(50)
                    .HasColumnName("SILOS");

                entity.HasOne(d => d.DoPieceNavigation)
                    .WithMany(p => p.DDoclignes)
                    .HasPrincipalKey(p => p.DoPiece)
                    .HasForeignKey(d => d.DoPiece)
                    .HasConstraintName("FK_D_DOCLIGNE_D_DOCENTETE");
            });

            modelBuilder.Entity<DEmodeler>(entity =>
            {
                entity.HasKey(e => e.CbMarq);

                entity.ToTable("D_EMODELER");

                entity.Property(e => e.CbMarq).HasColumnName("cbMarq");

                entity.Property(e => e.CbCreateur)
                    .HasMaxLength(50)
                    .HasColumnName("cbCreateur");

                entity.Property(e => e.CbModification)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("cbModification");

                entity.Property(e => e.ErCondition).HasColumnName("ER_Condition");

                entity.Property(e => e.ErJourTb01).HasColumnName("ER_JourTb01");

                entity.Property(e => e.ErJourTb02).HasColumnName("ER_JourTb02");

                entity.Property(e => e.ErJourTb03).HasColumnName("ER_JourTb03");

                entity.Property(e => e.ErJourTb04).HasColumnName("ER_JourTb04");

                entity.Property(e => e.ErJourTb05).HasColumnName("ER_JourTb05");

                entity.Property(e => e.ErJourTb06).HasColumnName("ER_JourTb06");

                entity.Property(e => e.ErNbJour).HasColumnName("ER_NbJour");

                entity.Property(e => e.ErTrepart).HasColumnName("ER_TRepart");

                entity.Property(e => e.ErVrepart)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("ER_VRepart");

                entity.Property(e => e.MrNo).HasColumnName("MR_No");

                entity.Property(e => e.NReglement).HasColumnName("N_Reglement");
            });

            modelBuilder.Entity<DEmploye>(entity =>
            {
                entity.HasKey(e => e.CbMarq);

                entity.ToTable("D_EMPLOYES");

                entity.HasIndex(e => e.EmCode, "IX_D_EMPLOYES")
                    .IsUnique();

                entity.Property(e => e.CbMarq).HasColumnName("cbMarq");

                entity.Property(e => e.CbCreateur)
                    .HasMaxLength(50)
                    .HasColumnName("cbCreateur");

                entity.Property(e => e.CbModification)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("cbModification");

                entity.Property(e => e.CcCode)
                    .HasMaxLength(50)
                    .HasColumnName("CC_Code");

                entity.Property(e => e.EmAdresse)
                    .HasMaxLength(50)
                    .HasColumnName("EM_Adresse");

                entity.Property(e => e.EmCin)
                    .HasMaxLength(50)
                    .HasColumnName("EM_CIN");

                entity.Property(e => e.EmCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("EM_Code");

                entity.Property(e => e.EmCodeExterne)
                    .HasMaxLength(50)
                    .HasColumnName("EM_CodeExterne");

                entity.Property(e => e.EmCodePostal)
                    .HasMaxLength(50)
                    .HasColumnName("EM_CodePostal");

                entity.Property(e => e.EmCodeResp)
                    .HasMaxLength(50)
                    .HasColumnName("EM_CodeResp");

                entity.Property(e => e.EmCollaborateur).HasColumnName("EM_Collaborateur");

                entity.Property(e => e.EmCommentaire)
                    .HasMaxLength(500)
                    .HasColumnName("EM_Commentaire");

                entity.Property(e => e.EmCoutStd)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("EM_CoutStd");

                entity.Property(e => e.EmDateCreation)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("EM_DateCreation");

                entity.Property(e => e.EmEmail)
                    .HasMaxLength(50)
                    .HasColumnName("EM_EMail");

                entity.Property(e => e.EmFonction)
                    .HasMaxLength(50)
                    .HasColumnName("EM_Fonction");

                entity.Property(e => e.EmGsm)
                    .HasMaxLength(50)
                    .HasColumnName("EM_GSM");

                entity.Property(e => e.EmNaissance)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("EM_Naissance");

                entity.Property(e => e.EmNom)
                    .HasMaxLength(50)
                    .HasColumnName("EM_Nom");

                entity.Property(e => e.EmPays)
                    .HasMaxLength(50)
                    .HasColumnName("EM_Pays");

                entity.Property(e => e.EmPrenom)
                    .HasMaxLength(50)
                    .HasColumnName("EM_Prenom");

                entity.Property(e => e.EmQualification)
                    .HasMaxLength(50)
                    .HasColumnName("EM_Qualification");

                entity.Property(e => e.EmRegion)
                    .HasMaxLength(50)
                    .HasColumnName("EM_Region");

                entity.Property(e => e.EmTel)
                    .HasMaxLength(50)
                    .HasColumnName("EM_Tel");

                entity.Property(e => e.EmTelFix)
                    .HasMaxLength(50)
                    .HasColumnName("EM_Tel_Fix");

                entity.Property(e => e.EmUnite)
                    .HasMaxLength(50)
                    .HasColumnName("EM_Unite");

                entity.Property(e => e.EmVille)
                    .HasMaxLength(50)
                    .HasColumnName("EM_Ville");
            });

            modelBuilder.Entity<DLitige>(entity =>
            {
                entity.HasKey(e => e.CodeLitige);

                entity.ToTable("D_LITIGE");

                entity.Property(e => e.CodeLitige).HasColumnName("CODE_Litige");

                entity.Property(e => e.CtNum)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("CT_Num");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.CtNumNavigation)
                    .WithMany(p => p.DLitiges)
                    .HasPrincipalKey(p => p.CtNum)
                    .HasForeignKey(d => d.CtNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_D_LITIGE_D_COMPTET");
            });

            modelBuilder.Entity<DMecheance>(entity =>
            {
                entity.HasKey(e => e.CbMarq)
                    .HasName("PK_D_MECHEANCE_1");

                entity.ToTable("D_MECHEANCE");

                entity.HasIndex(e => e.MeNo, "IX_D_MECHEANCE")
                    .IsUnique();

                entity.Property(e => e.CbMarq).HasColumnName("cbMarq");

                entity.Property(e => e.CbCreateur)
                    .HasMaxLength(50)
                    .HasColumnName("cbCreateur");

                entity.Property(e => e.CbModification)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("cbModification");

                entity.Property(e => e.CtNum)
                    .HasMaxLength(50)
                    .HasColumnName("CT_Num");

                entity.Property(e => e.DatePromis)
                    .HasColumnType("date")
                    .HasColumnName("Date_Promis");

                entity.Property(e => e.DoRecouvreur)
                    .HasMaxLength(50)
                    .HasColumnName("DO_Recouvreur");

                entity.Property(e => e.DoRepresentant)
                    .HasMaxLength(50)
                    .HasColumnName("DO_Representant");

                entity.Property(e => e.MeDateDoc)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("ME_DateDoc");

                entity.Property(e => e.MeDateEcheance)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("ME_DateEcheance");

                entity.Property(e => e.MeDatePrevu)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("ME_DatePrevu");

                entity.Property(e => e.MeDomaine).HasColumnName("ME_Domaine");

                entity.Property(e => e.MeId).HasColumnName("ME_ID");

                entity.Property(e => e.MeModeReglement).HasColumnName("ME_ModeReglement");

                entity.Property(e => e.MeMontant)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("ME_Montant");

                entity.Property(e => e.MeMontantReste)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("ME_MontantReste");

                entity.Property(e => e.MeNbrJour).HasColumnName("ME_NbrJour");

                entity.Property(e => e.MeNo).HasColumnName("ME_No");

                entity.Property(e => e.MePiece)
                    .HasMaxLength(50)
                    .HasColumnName("ME_Piece");

                entity.Property(e => e.MePourcent)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("ME_Pourcent");

                entity.Property(e => e.MeRegle).HasColumnName("ME_Regle");

                entity.Property(e => e.MeType).HasColumnName("ME_Type");

                entity.Property(e => e.MontantPromis)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("Montant_Promis");

                entity.HasOne(d => d.CtNumNavigation)
                    .WithMany(p => p.DMecheances)
                    .HasPrincipalKey(p => p.CtNum)
                    .HasForeignKey(d => d.CtNum)
                    .HasConstraintName("FK_D_MECHEANCE_D_COMPTET");

                entity.HasOne(d => d.MePieceNavigation)
                    .WithMany(p => p.DMecheances)
                    .HasPrincipalKey(p => p.DoPiece)
                    .HasForeignKey(d => d.MePiece)
                    .HasConstraintName("FK_D_MECHEANCE_D_DOCENTETE");
            });

            modelBuilder.Entity<DModeler>(entity =>
            {
                entity.HasKey(e => e.MrNo);

                entity.ToTable("D_MODELER");

                entity.Property(e => e.MrNo)
                    .ValueGeneratedNever()
                    .HasColumnName("MR_No");

                entity.Property(e => e.CbCreateur)
                    .HasMaxLength(50)
                    .HasColumnName("cbCreateur");

                entity.Property(e => e.CbMarq)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("cbMarq");

                entity.Property(e => e.CbMarqSage).HasColumnName("cbMarqSage");

                entity.Property(e => e.CbModification)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("cbModification");

                entity.Property(e => e.MrIntitule)
                    .HasMaxLength(50)
                    .HasColumnName("MR_Intitule");
            });

            modelBuilder.Entity<DNotification>(entity =>
            {
                entity.HasKey(e => new { e.CtNum, e.NumScenario });

                entity.ToTable("D_NOTIFICATION");

                entity.Property(e => e.CtNum)
                    .HasMaxLength(50)
                    .HasColumnName("CT_Num");

                entity.Property(e => e.NumScenario).HasColumnName("NUM_Scenario");

                entity.HasOne(d => d.CtNumNavigation)
                    .WithMany(p => p.DNotifications)
                    .HasPrincipalKey(p => p.CtNum)
                    .HasForeignKey(d => d.CtNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_D_NOTIFICATION_D_SCENARIO");

                entity.HasOne(d => d.NumScenarioNavigation)
                    .WithMany(p => p.DNotifications)
                    .HasForeignKey(d => d.NumScenario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_D_NOTIFICATION_D_SCENARIO1");
            });

            modelBuilder.Entity<DReglech>(entity =>
            {
                entity.HasKey(e => e.CbMarq);

                entity.ToTable("D_REGLECH");

                entity.Property(e => e.CbMarq).HasColumnName("cbMarq");

                entity.Property(e => e.CbCreateur)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cbCreateur");

                entity.Property(e => e.CbModification)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("cbModification");

                entity.Property(e => e.DoDomaine).HasColumnName("DO_Domaine");

                entity.Property(e => e.DoPiece)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DO_Piece");

                entity.Property(e => e.DoPieceOrigine)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DO_PieceOrigine");

                entity.Property(e => e.DoType).HasColumnName("DO_Type");

                entity.Property(e => e.DrNo).HasColumnName("DR_No");

                entity.Property(e => e.MeId).HasColumnName("ME_ID");

                entity.Property(e => e.MeNo).HasColumnName("ME_No");

                entity.Property(e => e.RcEtat).HasColumnName("RC_Etat");

                entity.Property(e => e.RcMontant)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("RC_Montant");

                entity.Property(e => e.RcMontantImpute)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("RC_MontantImpute");

                entity.Property(e => e.RgNo).HasColumnName("RG_No");

                entity.Property(e => e.RgTypeReg).HasColumnName("RG_TypeReg");

                entity.HasOne(d => d.MeNoNavigation)
                    .WithMany(p => p.DRegleches)
                    .HasPrincipalKey(p => p.MeNo)
                    .HasForeignKey(d => d.MeNo)
                    .HasConstraintName("FK_D_REGLECH_D_MECHEANCE");

                entity.HasOne(d => d.RgNoNavigation)
                    .WithMany(p => p.DRegleches)
                    .HasForeignKey(d => d.RgNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_D_REGLECH_D_CREGLEMENT");
            });

            modelBuilder.Entity<DScenario>(entity =>
            {
                entity.HasKey(e => e.NumScenario);

                entity.ToTable("D_SCENARIO");

                entity.Property(e => e.NumScenario).HasColumnName("NUM_Scenario");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.EnvoieAuto).HasColumnName("ENVOIE_Auto");

                entity.Property(e => e.IdAttachement).HasColumnName("ID_Attachement");

                entity.Property(e => e.NbJour).HasColumnName("NB_Jour");

                entity.HasOne(d => d.IdAttachementNavigation)
                    .WithMany(p => p.DScenarios)
                    .HasForeignKey(d => d.IdAttachement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_D_SCENARIO_D_ATTACHEMENT");
            });

            modelBuilder.Entity<PReglement>(entity =>
            {
                entity.HasKey(e => e.CbMarq);

                entity.ToTable("P_REGLEMENT");

                entity.HasIndex(e => e.CbIndice, "IX_P_REGLEMENT")
                    .IsUnique();

                entity.Property(e => e.CbMarq).HasColumnName("cbMarq");

                entity.Property(e => e.CbCreateur)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cbCreateur");

                entity.Property(e => e.CbIndice)
                    .IsRequired()
                    .HasColumnName("cbIndice");

                entity.Property(e => e.CbModification)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("cbModification");

                entity.Property(e => e.EbNoDecaiss).HasColumnName("EB_NoDecaiss");

                entity.Property(e => e.EbNoEncaiss).HasColumnName("EB_NoEncaiss");

                entity.Property(e => e.IbAfbdecaissPrinc)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("IB_AFBDecaissPrinc");

                entity.Property(e => e.IbAfbencaissPrinc)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("IB_AFBEncaissPrinc");

                entity.Property(e => e.JoCnum)
                    .HasMaxLength(50)
                    .HasColumnName("JO_CNum");

                entity.Property(e => e.JoFnum)
                    .HasMaxLength(50)
                    .HasColumnName("JO_FNum");

                entity.Property(e => e.RActive).HasColumnName("R_active");

                entity.Property(e => e.RCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("R_Code");

                entity.Property(e => e.REdiCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("R_EdiCode");

                entity.Property(e => e.RIntitule)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("R_Intitule");

                entity.Property(e => e.RModePaieCredit).HasColumnName("R_ModePaieCredit");

                entity.Property(e => e.RModePaieDebit).HasColumnName("R_ModePaieDebit");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
