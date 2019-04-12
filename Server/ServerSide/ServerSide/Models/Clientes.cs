using System;
using System.Collections.Generic;

namespace ServerSide.Models
{
    public partial class Clientes
    {
        public Clientes()
        {
            Emprestimo = new HashSet<Emprestimo>();
        }

        public int Idcliente { get; set; }
        public string Cpf { get; set; }
        public decimal? LimiteEmprestimo { get; set; }
        public string Usuário { get; set; }
        public string Senha { get; set; }
        public bool EhAdm { get; set; }

        public ICollection<Emprestimo> Emprestimo { get; set; }
    }
}
