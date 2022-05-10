using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace tp2_oop
{
    internal class Program
    {
        /// <summary>
        /// Demande et lit le nombre de joueurs dans la partie
        /// </summary>
        /// <returns>Le nombre de joueurs</returns>
        static byte LireNbJoueurs()
        {
            byte nbJoueurs = 2;
            bool parsed = false;
            Console.WriteLine("Bienvenue à ZombieDice!");
            Console.Write("Veuillez entrer le nombre de joueurs: ");
            nbJoueurs = byte.Parse(Console.ReadLine());

            return nbJoueurs;
        }

        /// <summary>
        /// Demande et lit le nom des joueurs dans la partie
        /// </summary>
        /// <param name="nbJoueurs"></param>
        /// <returns>Le nom des joueurs</returns>
        static string[] LireNomJoueurs(byte nbJoueurs)
        {
            
            Console.Clear();

            string[] nomJoueurs = new string[nbJoueurs];

            for (int i = 0; i < nbJoueurs; i++)
            {
                Console.Clear();
                Console.Write("Veuillez entrer le nom du joueur " + (i + 1) + ": ");
                nomJoueurs[i] = Console.ReadLine();
            }
            
            return nomJoueurs;
        }
        private static void afficherIdParties(List<Guid> idParties)
        {
            for (int i = 0; i < idParties.Count; i++)
            {
                Console.Write($"\n{i + 1} : {idParties[i]}");
            }
        }

        private static void afficherInfoParties(Guid id, ZombieDice partie)
        {
            List<Joueur> listeJoueurs = partie.LireInfosParties(id);
            foreach (Joueur joueur in listeJoueurs)
            {
                Console.Write($"\n{joueur.Nom} : {joueur.Pointage}");
            }
        }

        private static int choisirIdParties()
        {
            int choice = 0;
            Console.Write("\nVeuillez choisir la partie à consulter: ");
            choice = Convert.ToInt32(Console.ReadLine());
            return choice - 1;
        }

        private static void gererChoixHistorique(IZombieDice jeu)
        {
            throw new NotImplementedException();
        }

        private static bool jouerOuConsulterHistorique()
        {
            Console.Clear();
            Console.Write("Voulez vous regarder l'historique(h) ou jouer une partie?(p): ");
            while (true)
            {
                var choix = Console.ReadKey(true).Key;

                switch (choix)
                {
                    case ConsoleKey.H:
                        return true;
                    case ConsoleKey.P:
                        return false;
                }
            }
        }
        

        /// <summary>
        /// Print les couleurs des dés pigés copyright Brandon Gauthier
        /// </summary>
        /// <param name="des"></param>
        /// <returns></returns>
        static string GenererCouleurDes(List<De> des)
        {
            string couleurDe = "";
            couleurDe += "[";
            foreach (De de in des)
            {
                if (de.Couleur == Couleur.Rouge)
                {
                    couleurDe += "R";
                }
                
                else if (de.Couleur == Couleur.Vert)
                {
                    couleurDe += "V";
                }

                else if (de.Couleur == Couleur.Jaune)
                {
                    couleurDe += "J";
                }
                if (couleurDe[couleurDe.Length - 1] != '[' )
                {
                    couleurDe += ",";
                }
            }
            if (couleurDe[couleurDe.Length - 1] == ',')
            {
                couleurDe = couleurDe.Substring(0, couleurDe.Length - 1);
            }
            couleurDe += "]";
            
            if (couleurDe.Length == 2)
            {
                couleurDe = "";
            }
            return couleurDe;
        }

        /// <summary>
        /// Demande si le joueur veut refaire une brasse
        /// </summary>
        /// <returns>Le choix</returns>
        static bool voulezContinuer()
        {
            Console.WriteLine("Voulez-vous continuer? (y/n)");

            while (true)
            {
                ConsoleKeyInfo confirm;
                confirm = Console.ReadKey(true);
                if (confirm.Key == ConsoleKey.Y)
                {
                    return true;

                }
                else if (confirm.Key == ConsoleKey.N)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Print le résultat de la partie fini
        /// </summary>
        /// <param name="partie"></param>
        static void messageFin(ZombieDice partie)
        {
            Console.Clear();
            foreach (Joueur joueur in partie.Joueurs)
            {
                Console.WriteLine("Nom: " + joueur.Nom + " // Points: " + joueur.Pointage);
                
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Print le résultat d'une brasse
        /// </summary>
        /// <param name="brasse"></param>
        static void AfficherResultatBrasse(Brasse brasse)
        {
            string couleurPas = GenererCouleurDes(brasse.DesPas);
            string couleurBalle = GenererCouleurDes(brasse.DesBalles);
            string couleurCerveau = GenererCouleurDes(brasse.DesCerveaux);
            
            Console.WriteLine("[Tour: " + brasse.Proprio.Nom + "] ------- [Points: " + brasse.Proprio.Pointage + "]");
            Console.WriteLine(brasse.NbPas + " pas pigés" + couleurPas);
            Console.WriteLine(brasse.NbBalles + " balles pigés" + couleurBalle);
            Console.WriteLine(brasse.NbCerveaux + " cerveaux pigés" + couleurCerveau);
            Console.WriteLine("----------------------------------");

        }

        /// <summary>
        /// Fait les tours de tout le monde, 1 fois.
        /// </summary>
        /// <param name="partie"></param>
        /// <param name="nbJoueurs"></param>
        static void FaireTourJeuComplet(ZombieDice partie, byte nbJoueurs)
        {
            for (int i = 0; i < nbJoueurs; i++)
            {
                Console.Clear();
                
                partie.ChangerJoueurActif(i);
                
                FaireTourUnJoueur(partie);
            }
        }
        /// <summary>
        /// Fait un tour complet du joueur et vérifie si il gagne
        /// </summary>
        /// <param name="partie"></param>
        static void FaireTourUnJoueur(ZombieDice partie)
        {
            //1. piger 3 des
            //2. afficher les 3 des
            //3. remettre des dans gobelet
            //4. demander continer
            
            bool continuer = true;
            
            while (continuer)
            {
                Gobelet gobelet = partie.GetGobelet();

                Brasse brasse = partie.JoueurActif.FaireBrasse(gobelet);
                AfficherResultatBrasse(brasse);
                if (gobelet.GetNbDesDisponibles() <= 3)
                {
                    gobelet.Remplir(brasse.ReturnDesCerveaux());
                }
                if (brasse.NbBalles >= 3)
                {
                    Console.WriteLine("Vous êtez mort et vous ne receverez aucun point. (3 balles)");
                    List<De> tousDes = brasse.ReturnDesToGobelet();
                    gobelet.Remplir(tousDes);
                    Console.ReadKey();
                    break;
                }   
                
                continuer = voulezContinuer();
                
                if (continuer == false)
                {
                    int tempPoints = brasse.MarquerPoints();
                    Console.WriteLine(tempPoints + " points gagnés.");
                    Console.ReadKey();
                    List<De> tousDes = brasse.ReturnDesToGobelet();
                    gobelet.Remplir(tousDes);
                }
                if (brasse.Proprio.Pointage >= 13)
                {
                    partie.PartieTermine = true;
                }
            }
            
        }
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            bool started = false;

            bool choix = jouerOuConsulterHistorique();

            if (choix)
            {
                ZombieDice historique = new ZombieDice();
                afficherIdParties(historique.LireIdParties());
                Guid chosenGuid = Fichier.LireIdPartie()[choisirIdParties()];
                afficherInfoParties(chosenGuid, historique);

                Console.ReadKey();
                Environment.Exit(69420);
            }

            ZombieDice partie = null;
            byte nbJoueurs = 0;
            
            while (!started)
                
                try
                {
                    nbJoueurs = LireNbJoueurs();
                    string[] nomJoueurs = LireNomJoueurs(nbJoueurs);
                    partie = new ZombieDice(nbJoueurs, nomJoueurs);
                    started = true;
                }
                
                catch (Exception ex)
                {
                    Journal.journaliserErreur(ex);
                    Console.WriteLine("Erreur, journalisé dans Fichiers/Journal.txt");
                }



            while (!partie.PartieTermine)
            {
                FaireTourJeuComplet(partie, nbJoueurs);
            }
            
            partie.EcrireInfosPartie();
            messageFin(partie);
            
        }
    }
}
