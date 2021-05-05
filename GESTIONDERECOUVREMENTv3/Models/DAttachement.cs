using System;
using System.Collections.Generic;

#nullable disable

namespace GESTIONDERECOUVREMENT.Models
{
    public partial class DAttachement
    {
        public DAttachement()
        {
            DScenarios = new HashSet<DScenario>();
        }

        public int IdAtt { get; set; }
        public string Audio { get; set; }
        public string Contenu { get; set; }
        public string Document { get; set; }

        public virtual ICollection<DScenario> DScenarios { get; set; }
    }
}
