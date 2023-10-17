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
        public int damage;

        public override void DoAction(BaseUnit self, BaseUnit other)
        {
            other.TakeDamage(damage);

            BattleHPUI.Instance.doingText.SetText(
                $"{self.status.characterName} ต่อย {other.status.characterName} ไป {damage} ความเสียหาย");
            BattleHPUI.Instance.UpdateHp();
        }
    }
}