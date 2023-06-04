using Microsoft.VisualStudio.TestTools.UnitTesting;
using haromszogekCLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace haromszogekCLI.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void DerekszoguTest()
        {
           
            Haromszog haromszog = new Haromszog("3,4,5");
            Haromszog haromszog2 = new Haromszog("2,4,5");

            
            Assert.AreEqual(true, Program.Derekszogu(haromszog));
            Assert.AreEqual(false, Program.Derekszogu(haromszog2));
        }
    }
}