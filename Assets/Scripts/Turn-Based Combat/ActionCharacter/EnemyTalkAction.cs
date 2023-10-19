using System;
using System.Collections.Generic;
using UI;
using Unit;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Turn_Based_Combat.ActionCharacter
{
    [CreateAssetMenu(menuName = "Action/EnemyTalkAction")]
    public class EnemyTalkAction : BaseAction
    {
        public List<EnemyTalk> talks;

        public override void DoAction(BaseUnit self, BaseUnit other)
        {
            var talk = talks[Random.Range(0, talks.Count)];
            self.talkUI.OpenUI(talk.enemyTalk.th, timeInAction);
            other.talkUI.OpenUI(talk.playerReaction.th, timeInAction);

            BattleHPUI.Instance.doingText.SetText($"{self.status.characterName}พูดกับ{other.status.characterName}");
        }
    }
}

[Serializable]
public class EnemyTalk
{
    public TextInGame enemyTalk;
    public TextInGame playerReaction;
}