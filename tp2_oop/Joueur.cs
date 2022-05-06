using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp2_oop
{
    internal class Joueur
    {
        public string InfosFinPartie { get; }

        
        
        private bool premierJoueur { get; set; }
        
        private Brasse brasse;
        public Joueur(string nom)
        {
            Nom = nom;
            Pointage = 0;
            this.brasse = new Brasse(this);
        }

        public string Nom { get; set; }

        public int Pointage { get; set; }
        /// <summary>
        /// Fait une brasse en prenant compte du nombre de pas pigés avant celle-ci
        /// </summary>
        /// <param name="gobelet"></param>
        /// <returns>La brasse</returns>
        public Brasse FaireBrasse(Gobelet gobelet)
        {
            List<De> listeDesPas = brasse.ReturnDesPas();
            
            int desMissing = 3 - listeDesPas.Count;
            
            byte desMissingByte = (byte)desMissing;

            List<De> currentDes = gobelet.PigerDes(desMissingByte);

            currentDes.AddRange(listeDesPas);


            foreach (De de in currentDes)
            {
                de.Brasser();
            }

            brasse.TrierBrasse(currentDes);

            return brasse;
        }
    }
}
