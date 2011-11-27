using NUnit.Framework;

namespace KataTintin
{
    [TestFixture]
    public class TintinTest
    {
        private PanierTintin panier;

        [SetUp]
        public void TestSetUp()
        {
            panier = new PanierTintin();
        }

        private void Ajouter(int nbFigurinesIdentiques, string figurine)
        {
            for (int i = 0; i < nbFigurinesIdentiques; i++)
                panier.AjouterFigurine(figurine);
        }

        [Test]
        public void PanierVideCOuteZéroEuros()
        {
            Assert.AreEqual(0, panier.CalculeTotal());
        }

        [Test]
        public void UneFigurineCouteHuitEuros()
        {
            panier.AjouterFigurine("Milou");

            Assert.AreEqual(PanierTintin.PRIX_UNITAIRE_FIGURINE, panier.CalculeTotal());
        }

        [Test]
        public void DeuxFigurinesDifférentesOntRéduction5Pct()
        {
            panier.AjouterFigurine("Milou");
            panier.AjouterFigurine("Tintin");

            Assert.AreEqual(PanierTintin.PRIX_UNITAIRE_FIGURINE * 2 * 0.95f, panier.CalculeTotal());
        }
        
        [Test]
        public void TroisFigurinesDifférentesOntRéduction10Pct()
        {
            panier.AjouterFigurine("Milou");
            panier.AjouterFigurine("Tintin");
            panier.AjouterFigurine("Capitaine Haddock");

            Assert.AreEqual(PanierTintin.PRIX_UNITAIRE_FIGURINE * 3 * 0.90f, panier.CalculeTotal());
        }
        
        [Test]
        public void QuatreFigurinesDifférentesOntRéduction25Pct()
        {
            panier.AjouterFigurine("Milou");
            panier.AjouterFigurine("Tintin");
            panier.AjouterFigurine("Capitaine Haddock");
            panier.AjouterFigurine("Les Dupondt");

            Assert.AreEqual(PanierTintin.PRIX_UNITAIRE_FIGURINE * 4 * 0.75f, panier.CalculeTotal());
        }

        [Test]
        public void DeuxFigurinesIdentiquesNOntPasDeRéduction()
        {
            Ajouter(2, "Tintin");

            Assert.AreEqual(2 * PanierTintin.PRIX_UNITAIRE_FIGURINE, panier.CalculeTotal());
        }
        
        [Test]
        public void TroisFigurinesIdentiquesNOntPasDeRéduction()
        {
            Ajouter(3, "Tintin");

            Assert.AreEqual(3 * PanierTintin.PRIX_UNITAIRE_FIGURINE, panier.CalculeTotal());
        }

        [Test]
        public void DeuxFigurinesIdentiquesEtUneDifférenteOntRéduction5Pct()
        {
            Ajouter(2, "Tintin");
            Ajouter(1, "Milou");

            Assert.AreEqual(2 * PanierTintin.PRIX_UNITAIRE_FIGURINE * 0.95f
                            + PanierTintin.PRIX_UNITAIRE_FIGURINE, panier.CalculeTotal());
        }
        
        [Test]
        public void DeuxFigurinesIdentiquesEtDeuxDifférentesOntRéduction10Pct()
        {
            Ajouter(2, "Tintin");
            Ajouter(1, "Milou");
            Ajouter(1, "Capitaine Haddock");

            Assert.AreEqual(3 * PanierTintin.PRIX_UNITAIRE_FIGURINE * 0.90f
                            + PanierTintin.PRIX_UNITAIRE_FIGURINE, panier.CalculeTotal());
        }

        [Test]
        public void PanierAvecFigurinesAABBDonne5PctRéduction()
        {
            Ajouter(2, "Tintin");
            Ajouter(2, "Milou");

            Assert.AreEqual(4 * 0.95f * PanierTintin.PRIX_UNITAIRE_FIGURINE, panier.CalculeTotal());
        }
        
        [Test]
        public void PanierAvecFigurinesAABBCDonne10PctPlus5PctRéduction()
        {
            Ajouter(2, "Tintin");
            Ajouter(2, "Milou");
            Ajouter(1, "Capitaine Haddock");

            Assert.AreEqual(2 * 0.95f * PanierTintin.PRIX_UNITAIRE_FIGURINE
                            + 3 * 0.90f * PanierTintin.PRIX_UNITAIRE_FIGURINE, 
                            panier.CalculeTotal());
        }


    }

}
