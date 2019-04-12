using NUnit.Framework;
using ServerSide.Controllers;
using ServerSide.Models;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            BancoDigitalContext bd = new BancoDigitalContext();
            EmprestimoesController controller = new EmprestimoesController(bd);
            dynamic teste = controller.GetEmprestimos(1, 1000);
            Assert.Pass();
        }
    }
}