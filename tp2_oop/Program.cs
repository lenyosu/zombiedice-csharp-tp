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
            Console.WriteLine("Veuillez entrer le nombre de joueurs:");
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
                Console.WriteLine("Veuillez entrer le nom du joueur " + (i + 1) + ":");
                nomJoueurs[i] = Console.ReadLine();
            }

            return nomJoueurs;
        }
        static bool AfficherResultatBrasse(Brasse brasse)
        {
            Console.Clear();
            ConsoleKeyInfo confirm;
            Console.WriteLine("-------Tour: " + brasse.Proprio.Nom + "-------");
            Console.WriteLine(brasse.NbPas + " pas pigés");
            Console.WriteLine(brasse.NbBalles + " balles pigés");
            Console.WriteLine(brasse.NbCerveaux + " cerveaux pigés");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Voulez-vous continuer? (y/n)");
            
            while (true)
            {
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
                continuer = AfficherResultatBrasse(brasse);
                if (continuer == false)
                {
                    List<De> tousDes = brasse.ReturnDesToGobelet();
                    gobelet.Remplir(tousDes);
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
            
        }
    }
}
