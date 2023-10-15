using System.Collections.Generic;
using Turn_Based_Combat.ActionCharacter;
using UnityEngine;

namespace Turn_Based_Combat.Character
{
    [CreateAssetMenu(fileName = "Enemy Status", menuName = "Status/Enemy Status")]
    public class EnemyStatus : BaseStatus
    {
        public EnemyType enemyType;
        public List<BaseAction> behaviour;
    }
}