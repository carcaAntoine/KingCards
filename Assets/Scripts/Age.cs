using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGame
{
    [System.Serializable]
    public class Age
    {
        public string ageName; //Nom de la nouvelle ère (Clan/Village/Cité/Cité-État/Royaume/Empire)

        [TextArea(1, 3)]
        public string annonce; //Message d'annonce du changement d'ère

        [TextArea(1, 3)]
        public string effectsDescription; //Description des effets de cette nouvelle ère
        public int indexMinCard; //Index de la première Card à pouvoir être tirée
        public int indexMaxCard; //Index de la dernière Card à pouvoir être tirée
        public bool AddEvolution; //Indique si on ajoute ou non la stat d'évolution (apparition à l'ère du Royaume)
        public int peopleAddValue = 5; //Nombre de personne en + tous les 10 tours
        public int ArmyCostValue = 1; //Coût d'entretien des armées
    }
}