using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp2_oop
{
    internal class Brasse
    {
        private List<De> desPas = new List<De>();
        private List<De> desBalles = new List<De>();
        private List<De> desCerveaux = new List<De>();
        private int nbCerveauxRestants;
        public Joueur Proprio { get; }

        public Brasse(Joueur proprio)
        {
            this.Proprio = proprio;
        }

        public List<De> DesPas { get => desPas;}
    
        public List<De> DesBalles { get => desBalles; }

        public List<De> DesCerveaux { get => desCerveaux; }

        public int NbCerveaux { get => desCerveaux.Count; }

        public int NbPas { get => desPas.Count; }

        public int NbBalles { get => desBalles.Count; }

        public List<De> ReturnDesToGobelet()
        {
            List<De> desToGobelet = new List<De>();
            
            desToGobelet.AddRange(desPas);
            desPas.Clear();
            
            desToGobelet.AddRange(desBalles);
            desBalles.Clear();

            desToGobelet.AddRange(desCerveaux);
            desCerveaux.Clear();

            return desToGobelet;
        }

        public List<De> ReturnDesPas()
        {
            List<De> tempPas = new List<De>();

            tempPas.AddRange(desPas);
            desPas.Clear();

            return tempPas;
        }

        public List<De> ReturnDesCerveaux()
        {
            List<De> tempCerveaux = new List<De>();

            tempCerveaux.AddRange(desCerveaux);
            desCerveaux.Clear();

            this.nbCerveauxRestants += tempCerveaux.Count;

            return tempCerveaux;
        }

        public void TrierBrasse(List<De> desBrasses)
        {
            foreach (De de in desBrasses)
            {
                if (de.Valeur == Valeur.Pas) 
                {
                    desPas.Add(de);
                }

                if (de.Valeur == Valeur.Balle)
                {
                    desBalles.Add(de);
                }

                if (de.Valeur == Valeur.Cerveau)
                {
                    desCerveaux.Add(de);
                }
            }
        }

        public int MarquerPoints()
        {
            this.Proprio.Pointage += nbCerveauxRestants + NbCerveaux;

            return nbCerveauxRestants + NbCerveaux;
        }

    }
}
