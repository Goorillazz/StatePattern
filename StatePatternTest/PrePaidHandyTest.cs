using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatePattern;

namespace StatePatternTest
{
    [TestClass]
    public class PrePaidHandyTest
    {
        [TestMethod]
        public void Telefonieren_GenugGuthabenVorhanden_True()
        {
            //Arrange
            var anrufKosten = 0.2;
            var prePaidHandy = new PrePaidHandy(anrufKosten);

            var einzahlung = 1.0;
            prePaidHandy.GuthabenAufladen(einzahlung);

            //Act
            var anrufHatGeklappt = prePaidHandy.Telefonieren();

            //Assert
            Assert.AreEqual(true, anrufHatGeklappt);
        }

        [TestMethod]
        public void Telefonieren_NichtMehrGenugGuthabenVorhanden_False()
        {
            //Arrange
            var anrufKosten = 0.2;
            var prePaidHandy = new PrePaidHandy(anrufKosten);

            var einzahlung = 1.0;
            prePaidHandy.GuthabenAufladen(einzahlung);

            //Act
            prePaidHandy.Telefonieren();
            prePaidHandy.Telefonieren();
            prePaidHandy.Telefonieren();
            prePaidHandy.Telefonieren();
            prePaidHandy.Telefonieren();
            var anrufHatGeklappt = prePaidHandy.Telefonieren();

            //Assert
            Assert.AreEqual(false, anrufHatGeklappt);
        }

        [TestMethod]
        public void Telefonieren_NichtMehrGenugGuthabenVorhanden_False_True()
        {
            //Arrange
            var anrufKosten = 0.2;
            var prePaidHandy = new PrePaidHandy(anrufKosten);

            var einzahlung = 1.0;
            prePaidHandy.GuthabenAufladen(einzahlung);

            //Act
            prePaidHandy.Telefonieren();
            prePaidHandy.Telefonieren();
            prePaidHandy.Telefonieren();
            prePaidHandy.Telefonieren();
            prePaidHandy.Telefonieren();
            var ersterAnrufHatGeklappt = prePaidHandy.Telefonieren();
            var auflaen = 0.5;
            prePaidHandy.GuthabenAufladen(auflaen);
            var zweiterAnrufHatGeklappt = prePaidHandy.Telefonieren();

            //Assert
            Assert.AreEqual(false, ersterAnrufHatGeklappt);
            Assert.AreEqual(true, zweiterAnrufHatGeklappt);
        }
    }
}
