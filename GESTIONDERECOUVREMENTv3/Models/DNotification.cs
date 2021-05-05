using System;
using System.Collections.Generic;

#nullable disable

namespace GESTIONDERECOUVREMENT.Models
{
    public partial class DNotification
    {
        public string CtNum { get; set; }
        public int NumScenario { get; set; }

        public virtual DComptet CtNumNavigation { get; set; }
        public virtual DScenario NumScenarioNavigation { get; set; }
    }
}
