using ServerSide.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace GeradorRelatorioEmprestimos
{
    public class Program
    {

        public static void Main(string[] args)
        {
            new Helper().GerarTxt(@"C:\temp\" + DateTime.Now.ToString("YYYY-DD-MM") +".txt");
        }
    }

    public class Helper
    {
        public void GerarTxt(string caminhoDoArquivo)
        {
            BancoDigitalContext bd = new BancoDigitalContext();
            StringBuilder sb = new StringBuilder();

            //Cabecalho
            sb.AppendLine(GaranteTamanho(10, DateTime.Now.Date.ToString()));

            using (bd)
            {
                List<Emprestimo> emprestimos = bd.Emprestimo.ToList<Emprestimo>();
                List<Clientes> Clientes = bd.Clientes.ToList<Clientes>();

                int qtdEmprestimos = 0;
                decimal? valorTotal = 0;
                foreach (var item in emprestimos.Where(p => p.DataEmprestimo == DateTime.Today).ToList())
                {
                    qtdEmprestimos++;
                    valorTotal += item.Valor;
                    //Registros
                    sb.Append(GaranteTamanho(14, Clientes.Where(p => p.Idcliente == item.Cliente).FirstOrDefault().Cpf) + " ");
                    sb.Append(GaranteTamanho(10, item.Valor.ToString()) + " ");
                    sb.AppendLine(GaranteTamanho(10, Convert.ToDateTime(item.DataEmprestimo).Date.ToString() + " "));
                }
                //Rodapé
                sb.AppendLine(GaranteTamanho(3, qtdEmprestimos.ToString()));
                sb.AppendLine(GaranteTamanho(15, valorTotal.ToString()));

            }

            using (StreamWriter file = new StreamWriter(File.Create(caminhoDoArquivo)))
            {
                file.WriteLine(sb.ToString());
            }
        }

        public string GaranteTamanho(int tamanho, string texto)
        {
            if (texto.Length < tamanho)
            {
                for (int i = 0; i < tamanho - texto.Length; i++)
                {
                    texto = " " + texto;
                }
            }
            if (texto.Length > tamanho)
            {
                texto = texto.Substring(0, tamanho);
            }

            return texto;
        }
    }
}
