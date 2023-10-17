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
        public List<string> vfxText;

        public override void DoAction(BaseUnit self, BaseUnit other)
        {
            self.talkUI.OpenUI($"{vfxText[Random.Range(0, vfxText.Count)]}แฮร่ แฮร่ แฮร่", timeInAction);
            var status = (EnemyStatus)other.status;
            var talkEnemy = talkEnemyList.FirstOrDefault(enemy => enemy.enemyType == status.enemyType);

            if (talkEnemy != null)
            {
                other.talkUI.OpenUI(talkEnemy.textInGame[Random.Range(0, talkEnemy.textInGame.Count)].th,
                    timeInAction);
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