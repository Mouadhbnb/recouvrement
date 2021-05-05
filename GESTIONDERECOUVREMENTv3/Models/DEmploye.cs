using System;
using System.Collections.Generic;

#nullable disable

namespace GESTIONDERECOUVREMENT.Models
{
    public partial class DEmploye
    {
        public DEmploye()
        {
            DComptets = new HashSet<DComptet>();
        }

        public string EmCode { get; set; }
        public string EmPrenom { get; set; }
        public string EmNom { get; set; }
        public string EmFonction { get; set; }
        public decimal? EmCoutStd { get; set; }
        public string EmCodeResp { get; set; }
        public string CcCode { get; set; }
        public short? EmCollaborateur { get; set; }
        public DateTime? EmDateCreation { get; set; }
        public string EmCodeExterne { get; set; }
        public string EmAdresse { get; set; }
        public string EmCodePostal { get; set; }
        public string EmVille { get; set; }
        public string EmRegion { get; set; }
        public string EmPays { get; set; }
        public string EmEmail { get; set; }
        public string EmUnite { get; set; }
        public string EmCin { get; set; }
        public DateTime? EmNaissance { get; set; }
        public string EmTel { get; set; }
        public string EmTelFix { get; set; }
        public string EmGsm { get; set; }
        public string EmQualification { get; set; }
        public int CbMarq { get; set; }
        public string CbCreateur { get; set; }
        public DateTime? CbModification { get; set; }
        public string EmCommentaire { get; set; }

        public virtual ICollection<DComptet> DComptets { get; set; }
    }
}
