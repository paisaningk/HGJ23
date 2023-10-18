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
        public Sprite attackSprite2;
        public string actionText;
        public string action2Text;
        public int damage;
        

        private bool _isPlayer;
        private Sprite _attack;
        private string _text;

        public override void DoAction(BaseUnit self, BaseUnit other)
        {
            var transformPosition = other.transform.position;

            _isPlayer = true;
            _attack = attackSprite;
            _text = actionText;

            switch (self)
            {
                case Player:
                    transformPosition.x -= 5f;
                    break;
                case Enemy enemy:
                {
                    transformPosition.x += 5f;
                    _isPlayer = false;
                    if (enemy.haveStateTwo && enemy.isStateTwo)
                    {
                        _attack = attackSprite2;
                        _text = action2Text;
                    }

                    break;
                }
            }

            self.transform.DOMove(transformPosition, 1f).OnComplete((() =>
            {
                other.TakeDamage(damage);

                BattleHPUI.Instance.ShowAttack(_isPlayer, _attack);
                BattleHPUI.Instance.doingText.SetText(
                    $"{self.status.characterName} {_text} {other.status.characterName} ไป {damage} ความเสียหาย");
                BattleHPUI.Instance.UpdateHp();
            }));
        }
        
    }
}