using System.Collections;
using DG.Tweening;
using UI;
using Unit;
using UnityEngine;

namespace Turn_Based_Combat.ActionCharacter
{
    [CreateAssetMenu(menuName = "Action/Attack")]
    public class AttackAction : BaseAction
    {
        public string actionText;
        public int damage;

        public override void DoAction(BaseUnit self, BaseUnit other)
        {
            self.transform.DOMove(other.transform.position, 1f).OnComplete((() =>
            {
                self.animator.Play("Attack");
                other.TakeDamage(damage);

                BattleHPUI.Instance.doingText.SetText(
                    $"{self.status.characterName} {actionText} {other.status.characterName} ไป {damage} ความเสียหาย");
                BattleHPUI.Instance.UpdateHp();
            }));
        }
        
    }
}