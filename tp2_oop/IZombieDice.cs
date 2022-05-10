using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp2_oop
{
    internal interface IZombieDice
    {
        Gobelet Gobelet { get; }
        
        Guid IdPartie { get; }
        
        Joueur JoueurActif { get; set; }
        
        Joueur[] Joueurs { get; }
        
        bool PartieTermine { get; set; }

        Joueur ChangerJoueurActif(int numeroJoueur);

        void EcrireInfosPartie();
        
        List<Joueur> LireInfosParties(Guid idPartie);

        List<Guid> LireIdParties();


    }
}
