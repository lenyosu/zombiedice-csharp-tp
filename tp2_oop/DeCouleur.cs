using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp2_oop
{
    internal class DeJaune : De
    {
        /// <summary>
        /// Constructeur de la classe DeJaune
        /// </summary>
        public DeJaune()
        {
            couleur = Couleur.Jaune;
        }

        /// <summary>
        /// Assigne les faces des dés pour la couleur jaune
        /// </summary>
        protected override void EnregistrerValeursPossibles()
        {
            valeurs[0] = Valeur.Pas;
            valeurs[1] = Valeur.Pas;
            valeurs[2] = Valeur.Balle;
            valeurs[3] = Valeur.Balle;
            valeurs[4] = Valeur.Cerveau;
            valeurs[5] = Valeur.Cerveau;
        }
    }

    internal class DeRouge : De
    {
        /// <summary>
        /// Constructeur de la classe DeRouge
        /// </summary>
        public DeRouge()
        {
            couleur = Couleur.Rouge;
        }

        /// <summary>
        /// Assigne les faces des dés pour la couleur rouge
        /// </summary>
        protected override void EnregistrerValeursPossibles()
        {
            valeurs[0] = Valeur.Pas;
            valeurs[1] = Valeur.Pas;
            valeurs[2] = Valeur.Balle;
            valeurs[3] = Valeur.Balle;
            valeurs[4] = Valeur.Balle;
            valeurs[5] = Valeur.Cerveau;
        }
    }

    internal class DeVert : De
    {
        /// <summary>
        /// Constructeur de la classe DeVert
        /// </summary>
        public DeVert()
        {
            couleur = Couleur.Vert;
        }

        /// <summary>
        /// Assigne les faces des dés pour la couleur vert
        /// </summary>
        protected override void EnregistrerValeursPossibles()
        {
            valeurs[0] = Valeur.Pas;
            valeurs[1] = Valeur.Pas;
            valeurs[2] = Valeur.Balle;
            valeurs[3] = Valeur.Cerveau;
            valeurs[4] = Valeur.Cerveau;
            valeurs[5] = Valeur.Cerveau;
        }
    }
}
