using NUnit.Framework;
using ServerSide.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void VerificaAcessoEF()
        {
            BancoDigitalContext bd = new BancoDigitalContext();
            List<Clientes> Clientes = bd.Clientes.ToList<Clientes>();
            Assert.Pass();
        }
        [Test]
        public void ChecaPermissaoEscreverPasta()
        {
            using (StreamWriter file = new StreamWriter(File.Create(@"C:\temp\teste.txt")))
            {
                file.WriteLine("teste");
            }
            File.Delete(@"C:\temp\teste.txt");
        }
    }
}