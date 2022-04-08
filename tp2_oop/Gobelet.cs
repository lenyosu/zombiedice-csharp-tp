using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp2_oop
{
    internal class Gobelet
    {
        //Variables
        public List<De> listeDes = new List<De>();

        //private const byte NB_DES = 13;

        /// <summary>
        /// Constructeur de la classe Gobelet
        /// </summary>
        public Gobelet()
        {
            RemplirGobelet();
        }
        public int GetNbDesDisponibles()
        {
            return listeDes.Count;

        }
        /// <summary>
        /// Remplit le gobelet avec le nombre correct de dés de chaque couleur
        /// </summary>
        private void RemplirGobelet()
        {
            int nbVert = 6;
            int nbJaune = 4;
            int nbRouge = 3;

            for(int i = 0; i < nbVert; i++)
            {
                this.listeDes.Add(new DeVert());
            }
            
            for(int i = 0; i < nbJaune; i++)
            {
                this.listeDes.Add(new DeJaune());
            }

            for(int i = 0; i < nbRouge; i++)
            {
                this.listeDes.Add(new DeRouge());
            }
        }
        /// <summary>
        /// Prend l'array des dés du jeu et le met dans la liste de dés du Gobelet.
        /// </summary>
        /// <param name="des"></param>
        public void Remplir(List<De> des)
        {
            for(int i = 0; i < des.Count; i++)
            {
                listeDes.Add(des[i]);
            }
        }
        /// <summary>
        /// Méthode qui permet de tirer un dé de la liste des dés et l'enlève de celle ci.
        /// </summary>
        /// <param name="nbDes"></param>
        /// <returns> la liste des dés après la pige </returns>
        public List<De> PigerDes(byte nbDes)
        {
            List<De> des = new List<De>();

            for(int i = 0; i < nbDes; i++)
            {
                Random rnd = new Random();
                int nbDesDispo = GetNbDesDisponibles();
                int chosenDice = rnd.Next(nbDesDispo);

                des.Add(listeDes[chosenDice]);
                listeDes.RemoveAt(chosenDice);
            }

            return des;
        }
        
        
    }
}
