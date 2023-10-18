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
        public Sprite attackSprite;
        public string actionText;
        public int damage;

        public override void DoAction(BaseUnit self, BaseUnit other)
        {
            var transformPosition = other.transform.position;
            var isplayer = true;
            if (self is Player)
            {
                transformPosition.x -= 5f;
            }
            else
            {
                transformPosition.x += 5f;
                isplayer = false;
            }

            self.transform.DOMove(transformPosition, 1f).OnComplete((() =>
            {
                other.TakeDamage(damage);

                BattleHPUI.Instance.ShowAttack(isplayer, attackSprite);
                BattleHPUI.Instance.doingText.SetText(
                    $"{self.status.characterName} {actionText} {other.status.characterName} ไป {damage} ความเสียหาย");
                BattleHPUI.Instance.UpdateHp();
            }));
        }
        
    }
}