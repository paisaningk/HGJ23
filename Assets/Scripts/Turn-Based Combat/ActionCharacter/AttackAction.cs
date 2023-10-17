using Turn_Based_Combat.Character;
using UI;
using Unit;
using UnityEditor;
using UnityEngine;

namespace Turn_Based_Combat.ActionCharacter
{
    [CreateAssetMenu(menuName = "Action/Attack")]
    public class AttackAction : BaseAction
    {
        public string animName;
        public string actionText;
        public int damage;

        public override void DoAction(BaseUnit self, BaseUnit other)
        {
            self.animator.Play(animName);
            
            other.TakeDamage(damage);

            BattleHPUI.Instance.doingText.SetText(
                $"{self.status.characterName} {actionText} {other.status.characterName} ไป {damage} ความเสียหาย");
            BattleHPUI.Instance.UpdateHp();
        }
    }
}