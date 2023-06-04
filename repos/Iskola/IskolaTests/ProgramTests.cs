using Microsoft.VisualStudio.TestTools.UnitTesting;
using Iskola;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iskola.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void createazonositoTest()
        {
            Tanulo t = new Tanulo(@"2006;c;Bodnar Szilvia");
            Assert.AreEqual("6cbodszi", Program.createazonosito(t));
            Assert.AreNotEqual("8cbodszi", Program.createazonosito(t));
            Tanulo t2 = new Tanulo(@"2006;c;Krizsan Vivien Evelin");
            Assert.AreEqual("6ckriviv", Program.createazonosito(t2));
            Assert.AreNotEqual("7akrivi", Program.createazonosito(t2));
        }
    }
}