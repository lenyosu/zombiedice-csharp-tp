using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp2_oop
{
    internal class Fichier
    {

        private static readonly string DirPath = Directory.GetCurrentDirectory() + "/Fichiers/";
        private static readonly string HistoriquePath = DirPath + "Historique.txt";
        private static readonly string JournalPath = DirPath + "Journal.txt";
        public static void EcrireErreur(string ligne)
        {
            using StreamWriter writerJournal = new StreamWriter(JournalPath,true);
            writerJournal.AutoFlush = true;
            writerJournal.Write(ligne);

        }

        public static void EcrireInfosFinPartie(string ligne)
        {
            using StreamWriter writerInfos = new(HistoriquePath,true);
            writerInfos.AutoFlush = true;
            writerInfos.Write(ligne);
        }

        public static List<Guid> LireIdPartie()
        {
            using StreamReader readerId = new StreamReader(HistoriquePath);
            
            int nbLignes = 0;

            while (readerId.ReadLine() != null)
            {
                nbLignes++;
            }

            readerId.BaseStream.Position = 0;

            List<Guid> listeId = new List<Guid>();
            for (int i = 0; i <= nbLignes; i++)
            {
                string sections = readerId.ReadLine();
                if (sections != null)
                {
                    string[] sectionArray = sections.Split(";");
                    string id = sectionArray[0];
                    if (!Guid.TryParse(id, out Guid guid)) continue;
                    if (!listeId.Contains(guid))
                    {
                        listeId.Add(guid);
                    }
                }
                
            }
            return listeId;
        }


        public static List<Joueur> LireInfosPartie(Guid idPartie, ZombieDice partie)
        {
            List<Joueur> listeJoueur = new List<Joueur>();

            using StreamReader readerInfos = new StreamReader(HistoriquePath);
            
            int nbLignes = 0;

            while (readerInfos.ReadLine() != null)
            {
                nbLignes++;
            }

            readerInfos.BaseStream.Position = 0;

            for (int i = 0; i <= nbLignes; i++)
            {
                string sections = readerInfos.ReadLine();
                if (sections != null)
                {
                    string[] sectionArray = sections.Split(";");
                    string id = sectionArray[0];
                    if (!Guid.TryParse(id, out Guid guid)) continue;
                    if (guid == idPartie)
                    {
                        listeJoueur.Add(new Joueur(sectionArray[1],Convert.ToInt32(sectionArray[2])));
                    }
                }
            }

            return listeJoueur;
        }
    }
}
