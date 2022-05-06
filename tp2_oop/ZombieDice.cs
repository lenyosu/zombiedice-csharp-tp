
using System;


namespace tp2_oop
{
    internal class ZombieDice
    {
        private const byte MIN_JOUEURS = 2;
        private const byte MAX_JOUEURS = 4;
        private const byte FIN_PARTIE = 3;
        private Gobelet gobelet;
        private Joueur[] arrJoueurs;
        private int intJoueurActif = 0;

        private byte nbJoueurs;
        
        public Guid IdPartie { get; } = Guid.NewGuid();
        public Gobelet Gobelet { get => gobelet; }
        public Joueur[] Joueurs { get => arrJoueurs; }
        public bool PartieTermine { get; set; }
        public Joueur JoueurActif { get => arrJoueurs[intJoueurActif]; }

        /// <summary>
        /// Constructeur de la classe ZombieDice
        /// </summary>
        /// <param name="nbJoueurs"></param>
        public ZombieDice(byte nbJoueurs, string[] nomJoueurs)
        {
            Joueur[] arrJoueurs = new Joueur[nbJoueurs];
            for (int i = 0; i < nbJoueurs; i++)
            {
                arrJoueurs[i] = new Joueur(nomJoueurs[i]);
            }
            this.arrJoueurs = arrJoueurs;
            this.nbJoueurs = nbJoueurs;
            this.gobelet = new Gobelet();
        }
        
        /// <summary>
        /// Méthode qui va chercher le gobelet
        /// </summary>
        /// <returns> Le gobelet </returns>
        public Gobelet GetGobelet()
        {
            return Gobelet;
        }
        /// <summary>
        /// Change le joueur actif
        /// </summary>
        /// <param name="numeroJoueur"></param>
        /// <returns>À Qui revient le tour</returns>
        public Joueur ChangerJoueurActif(int numeroJoueur)
        {
            this.intJoueurActif = numeroJoueur;
            
            return this.arrJoueurs[numeroJoueur];
        }

    }
}