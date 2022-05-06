using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp2_oop
{
    internal class Journal
    {
        static string fichierEcriture = Directory.GetCurrentDirectory() + "\\Fichiers\\Journal.txt";

        private static StreamWriter writerFichier = new StreamWriter(fichierEcriture, true);

        public static void journaliserErreur(Exception ex)
        {
            Fichier.ecrireErreur("\n TP3-Livrable1; "+DateTime.Now+";"+ex.StackTrace);
            Console.WriteLine("Error found, wrote in Journal.txt");
        }
    }
}
