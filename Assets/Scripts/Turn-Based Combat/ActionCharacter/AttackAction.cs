using System.Collections;
using DG.Tweening;
using Turn_Based_Combat.Character;
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
            var realDmg = damage;

            _isPlayer = true;
            _attack = attackSprite;
            _text = actionText;

            switch (self)
            {
                case Player player:
                    transformPosition.x -= 5f;
                    if (player.goldenDrugs)
                    {
                        realDmg *= 2;
                    }

                    if (player.catFriend)
                    {
                        realDmg += 50;
                    }
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

                    if (enemy.status is EnemyStatus { enemyType: EnemyType.Father } && other is Player { armor: true })
                    {
                        realDmg -= 20;
                    }

                    break;
                }
            }

            self.transform.DOMove(transformPosition, 1f).OnComplete((() =>
            {
                other.TakeDamage(realDmg);

                BattleHPUI.Instance.ShowAttack(_isPlayer, _attack);
                BattleHPUI.Instance.doingText.SetText(
                    $"{self.status.characterName}{_text}{other.status.characterName}ไป {realDmg} ความเสียหาย");
                BattleHPUI.Instance.UpdateHp();
            }));
        }
        
    }
}