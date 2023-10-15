using Turn_Based_Combat.Character;
using UI;
using Unit;
using UnityEngine;

namespace Turn_Based_Combat.ActionCharacter
{
    [CreateAssetMenu(menuName = "Action/Attack")]
    public class AttackAction : BaseAction
    {
        public string animName;
        public int damage;

        public override void DoAction(BaseUnit self, BaseUnit other)
        {
            other.TakeDamage(damage);
            // other.animator.Play(animName);
            Debug.Log(name);

            BattleHPUI.Instance.UpdateHp();
        }
    }
}