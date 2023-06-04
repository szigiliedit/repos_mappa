using BalatonCLI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalatonCLITests
{
    [TestClass]
    public class ProgramTests
    {
        int[] adosavok = { 800, 600, 100 };

        [TestMethod]
        public void Ado_Test1()
        {
            // Arrange
            char Ado_sav = 'C';
            int Terulet = 80;

            // Act
            int result = Program.Adok(Ado_sav, Terulet, adosavok);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Ado_Test2()
        {
            // Arrange
            char Ado_sav = 'B';
            int Terulet = 48;

            // Act
            int result = Program.Adok(Ado_sav, Terulet, adosavok);

            // Assert
            Assert.AreEqual(28800, result);
        }

        [TestMethod]
        public void Ado_Test3()
        {
            // Arrange
            char Ado_sav = 'A';
            int Terulet = 1500;

            // Act
            int result = Program.Adok(Ado_sav, Terulet, adosavok);

            // Assert
            Assert.AreNotEqual(0, result);
        }

        [TestMethod]
        public void Ado_Test4()
        {
            // Arrange
            char Ado_sav = 'C';
            int Terulet = 3000;

            // Act
            int result = Program.Adok(Ado_sav, Terulet, adosavok);

            // Assert
            Assert.AreEqual(300000, result);
        }
    }
}
