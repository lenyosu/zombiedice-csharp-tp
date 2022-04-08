﻿
using System;


namespace tp2_oop
{
    internal class ZombieDice
    {
        private byte nbJoueur;
        private Gobelet gobelet;
        private Joueur[] arrJoueurs;
        private int intJoueurActif = 0;
        
        private byte nbJoueurs;
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

        public Joueur ChangerJoueurActif(int numeroJoueur)
        {
            this.intJoueurActif = numeroJoueur;
            
            return this.arrJoueurs[numeroJoueur];
        }

    }
}