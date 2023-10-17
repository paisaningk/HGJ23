using System.Collections.Generic;
using Turn_Based_Combat.ActionCharacter;
using UnityEngine;

namespace Turn_Based_Combat.Character
{
    [CreateAssetMenu(fileName = "Player Status", menuName = "Status/Player Status")]
    public class PlayerStatus : BaseStatus
    {
        public BaseAction attack;
        public BaseAction talk;
        public BaseAction def;
        public BaseAction heal;
    }
}