using Turn_Based_Combat.Character;
using Unit;
using UnityEngine;

namespace Turn_Based_Combat.ActionCharacter
{
    [CreateAssetMenu]
    public class AttackAction : BaseAction
    {
        public string animName;
        public int damage;

        public override void DoAction(BaseUnit baseUnit)
        {
            baseUnit.TakeDamage(damage);
        }
    }
}