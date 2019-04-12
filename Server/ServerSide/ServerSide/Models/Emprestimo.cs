using System;
using System.Collections.Generic;

namespace ServerSide.Models
{
    public partial class Emprestimo
    {
        public int IdEmprestimo { get; set; }
        public int? Cliente { get; set; }
        public decimal? Valor { get; set; }
        public DateTime? DataEmprestimo { get; set; }

        public Clientes ClienteNavigation { get; set; }
    }
}
