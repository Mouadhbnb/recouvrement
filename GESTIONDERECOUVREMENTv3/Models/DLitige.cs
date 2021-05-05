using System;
using System.Collections.Generic;

#nullable disable

namespace GESTIONDERECOUVREMENT.Models
{
    public partial class DLitige
    {
        public int CodeLitige { get; set; }
        public string CtNum { get; set; }
        public DateTime? Date { get; set; }

        public virtual DComptet CtNumNavigation { get; set; }
    }
}
