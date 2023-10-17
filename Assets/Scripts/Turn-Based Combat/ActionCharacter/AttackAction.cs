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
            var transformPosition = other.transform.position;
            if (self is Player)
            {
                transformPosition.x -= 3f;
            }
            else
            {
                transformPosition.x += 3f;
            }

            self.transform.DOMove(transformPosition, 1f).OnComplete((() =>
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