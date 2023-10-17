using System;
using System.Collections.Generic;
using System.Linq;
using Turn_Based_Combat.Character;
using UI;
using Unit;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Turn_Based_Combat.ActionCharacter
{
    [CreateAssetMenu(menuName = "Action/Player Talk")]
    public class PlayerTalkAction : BaseAction
    {
        public List<EnemyReactionTalk> talkEnemyList;

        public override void DoAction(BaseUnit self, BaseUnit other)
        {
            self.talkUI.OpenUI("แฮร่ แฮร่ แฮร่", 5);
            var status = (EnemyStatus)other.status;
            var talkEnemy = talkEnemyList.FirstOrDefault(enemy => enemy.enemyType == status.enemyType);

            if (talkEnemy != null)
            {
                other.talkUI.OpenUI(talkEnemy.textInGame[Random.Range(0, talkEnemy.textInGame.Count - 1)].th, 5);
            }

            BattleHPUI.Instance.doingText.SetText($"{self.status.characterName} พูดกับ {other.status.characterName}");
        }
    }

    [Serializable]
    public class EnemyReactionTalk
    {
        public EnemyType enemyType;
        public List<TextInGame> textInGame;
    }
}