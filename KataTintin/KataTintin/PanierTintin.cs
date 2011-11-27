using System;
using System.Collections.Generic;
using System.Linq;

namespace KataTintin
{
    public class PanierTintin
    {
        internal const int PRIX_UNITAIRE_FIGURINE = 8;
        private float[] coefficientsR�duction = new[] {0, 1, 0.95f, 0.90f, 0.75f};
        private IList<string> figurines = new List<string>();

        public float CalculeTotal()
        {
            if (ToutesFigurinesIdentiques())
                return PRIX_UNITAIRE_FIGURINE*figurines.Count;

            if (ToutesFigurinesDistinctes())
                return CalculeTotalAvecR�duction(figurines.Count);

            return SousPanierContenantLaPlusLongueS�rie().CalculeTotal()
                   + SousPanierContenantLeReste().CalculeTotal();
        }

        private PanierTintin SousPanierContenantLaPlusLongueS�rie()
        {
            return new PanierTintin()
            {
                figurines = figurines.Distinct().ToList()
            };
        }

        private PanierTintin SousPanierContenantLeReste()
        {
            return new PanierTintin()
            {
                figurines = figurines.GroupBy(f => f)
                    .Where(group => group.Count() > 1)
                    .SelectMany(f => f)
                    .Distinct()
                    .ToList()
            };
        }

        private bool ToutesFigurinesDistinctes()
        {
            return NbFigurinesDistinctes() == figurines.Count;
        }

        private bool ToutesFigurinesIdentiques()
        {
            return figurines.All(f => f == figurines[0]);
        }

        private int NbFigurinesDistinctes()
        {
            return figurines.Distinct().Count();
        }

        private float CalculeTotalAvecR�duction(int nbFigurines)
        {
            return coefficientsR�duction[nbFigurines]*PRIX_UNITAIRE_FIGURINE*nbFigurines;
        }

        public void AjouterFigurine(string figurine)
        {
            figurines.Add(figurine);
        }
    }
}