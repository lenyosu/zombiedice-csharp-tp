using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp2_oop
{
    internal class Fichier
    {
        private static string fichierHistorique = Directory.GetCurrentDirectory() + "\\Fichiers\\Historique.txt";


        public static void ecrireErreur(string ligne)
        {
            using StreamWriter writerJournal = new(path: "\\Fichiers\\Journal.txt", append: true);
            writerJournal.WriteLine(ligne);
            writerJournal.Flush();
            writerJournal.Close();
        }

        public void ecrireInfosFinPartie(string ligne)
        {
            
        }

        //public List<Guid> lireIdPartie()
        //{
            
        //}


        //public List<Joueur> lireInfosPartie(Guid idPartie)
        //{
            
        //}
    }
}
