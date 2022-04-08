using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp2_oop
{
    abstract class De
    {
        // Variables
        protected const int NB_FACES = 6;
        private int valeur = 0;
        protected Couleur couleur;
        protected Valeur[] valeurs = new Valeur[NB_FACES];

        /// <summary>
        /// Constructeur de la classe De.
        /// </summary>
        public De()
        {
            EnregistrerValeursPossibles();
        }

        /// <summary>
        /// Génère un nombre aléatoire et le return
        /// </summary>
        /// <returns>valeur du dé</returns>
        public Valeur Brasser()
        {
            Random rnd = new();
            this.valeur = rnd.Next(0, 5);

            return valeurs[valeur];
        }
        public Valeur Valeur { get => valeurs[valeur];}

        public Couleur Couleur { get => couleur; }
        protected abstract void EnregistrerValeursPossibles();

        public Couleur GetCouleur()
        {
            return Couleur;
        }

        public Valeur GetValeur()
        {
            return Valeur;
        }
    }
}
