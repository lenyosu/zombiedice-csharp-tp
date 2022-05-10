using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp2_oop
{
    internal class Journal
    {
        private static string fichierEcriture = Directory.GetCurrentDirectory() + "\\Fichiers\\Journal.txt";

        public static void journaliserErreur(Exception ex)
        {
            Fichier.EcrireErreur($"\n{AppDomain.CurrentDomain.FriendlyName};{DateTime.Now};{ex.StackTrace}");
            Console.WriteLine("Erreur, logged in Fichiers/Journal.txt");
        }
    }
}
