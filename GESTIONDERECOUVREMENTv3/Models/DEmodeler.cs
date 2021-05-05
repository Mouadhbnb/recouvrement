using System;
using System.Collections.Generic;

#nullable disable

namespace GESTIONDERECOUVREMENT.Models
{
    public partial class DEmodeler
    {
        public int MrNo { get; set; }
        public short? NReglement { get; set; }
        public short? ErCondition { get; set; }
        public short? ErNbJour { get; set; }
        public short? ErJourTb01 { get; set; }
        public short? ErJourTb02 { get; set; }
        public short? ErJourTb03 { get; set; }
        public short? ErJourTb04 { get; set; }
        public short? ErJourTb05 { get; set; }
        public short? ErJourTb06 { get; set; }
        public short? ErTrepart { get; set; }
        public decimal? ErVrepart { get; set; }
        public int CbMarq { get; set; }
        public string CbCreateur { get; set; }
        public DateTime? CbModification { get; set; }
    }
}
