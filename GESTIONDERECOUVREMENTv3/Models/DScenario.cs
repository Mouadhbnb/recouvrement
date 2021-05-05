using System;
using System.Collections.Generic;

#nullable disable

namespace GESTIONDERECOUVREMENT.Models
{
    public partial class DScenario
    {
        public DScenario()
        {
            DNotifications = new HashSet<DNotification>();
        }

        public int NumScenario { get; set; }
        public int Type { get; set; }
        public int NbJour { get; set; }
        public DateTime Date { get; set; }
        public int Media { get; set; }
        public int EnvoieAuto { get; set; }
        public int IdAttachement { get; set; }

        public virtual DAttachement IdAttachementNavigation { get; set; }
        public virtual ICollection<DNotification> DNotifications { get; set; }
    }
}
