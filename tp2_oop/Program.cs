using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp2_oop
{
    internal class Program
    {
        
        static byte LireNbJoueurs()
        {
            byte nbJoueurs;

            Console.WriteLine("Bienvenue à ZombieDice!");
            Console.Write("Veuillez entrer le nombre de joueurs: ");
            nbJoueurs = byte.Parse(Console.ReadLine());

            return nbJoueurs;
        }

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

        static void messageFin(ZombieDice partie)
        {
            Console.Clear();
            foreach (Joueur joueur in partie.Joueurs)
            {
                Console.WriteLine("Nom: " + joueur.Nom + " // Points: " + joueur.Pointage);
                
            }
            Console.ReadKey();
        }
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

        static void FaireTourJeuComplet(ZombieDice partie, byte nbJoueurs)
        {
            for (int i = 0; i < nbJoueurs; i++)
            {
                Console.Clear();
                
                partie.ChangerJoueurActif(i);
                
                FaireTourUnJoueur(partie);
            }
        }

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

        static void Main(string[] args)
        {
            byte nbJoueurs = LireNbJoueurs();
            string[] nomJoueurs = LireNomJoueurs(nbJoueurs);
            ZombieDice partie = new ZombieDice(nbJoueurs, nomJoueurs);


            while (!partie.PartieTermine)
            {
                FaireTourJeuComplet(partie, nbJoueurs);
            }

            messageFin(partie);
            
        }
    }
}
