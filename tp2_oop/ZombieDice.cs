
using System;
using System.Net.NetworkInformation;


namespace tp2_oop
{
    internal class ZombieDice : IZombieDice
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
        public Joueur[] Joueurs
        {
            get => arrJoueurs;
            set => arrJoueurs = value;
        }

        public bool PartieTermine { get; set; }
        public Joueur JoueurActif { 
            get => arrJoueurs[intJoueurActif];
            set => arrJoueurs[intJoueurActif] = value;
        }

        public ZombieDice()
        {
            
        }

        /// <summary>
        /// Constructeur de la classe ZombieDice
        /// </summary>
        /// <param name="nbJoueurs"></param>
        public ZombieDice(byte nbJoueurs, string[] nomJoueurs)
        {
            if (nbJoueurs < 2 || nbJoueurs > 4)
            {
                throw new FormatException();
            }
            
            if (nomJoueurs.Length != nbJoueurs)
            {
                throw new OverflowException();
            }
            
            Joueur[] arrJoueurs = new Joueur[nbJoueurs];
            
            for (int i = 0; i < nbJoueurs; i++)
            {
                arrJoueurs[i] = new Joueur(nomJoueurs[i]);
            }
            this.arrJoueurs = arrJoueurs;
            this.nbJoueurs = nbJoueurs;
            this.gobelet = new Gobelet();
        }

        public List<Joueur> LireInfosParties(Guid idPartie)
        {
            return Fichier.LireInfosPartie(idPartie, this);
        }

        public List<Guid> LireIdParties()
        {
            return Fichier.LireIdPartie();
        }
        public void EcrireInfosPartie()
        {
            foreach (Joueur joueurs in Joueurs)
            {
                Fichier.EcrireInfosFinPartie($"\n{IdPartie};{joueurs.Nom};{joueurs.Pointage}");
            }
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