using UI;
using Unit;
using UnityEngine;

namespace Turn_Based_Combat.ActionCharacter
{
    [CreateAssetMenu(menuName = "Action/Talk")]
    public class TalkAction : BaseAction
    {
        public TextInGame textInGame;

        public override void DoAction(BaseUnit self, BaseUnit other)
        {
            self.talkUI.OpenUI(textInGame.th, 5);
            Debug.Log(name);
        }
    }
}