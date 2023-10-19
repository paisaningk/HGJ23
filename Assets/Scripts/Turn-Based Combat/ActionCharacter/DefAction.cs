using UI;
using Unit;
using UnityEngine;

namespace Turn_Based_Combat.ActionCharacter
{
    [CreateAssetMenu(menuName = "Action/Def")]
    public class DefAction : BaseAction
    {
        public string defAnimName;

        public override void DoAction(BaseUnit self, BaseUnit other)
        {
            self.isDef = true;
            self.animator.Play(defAnimName);

            BattleHPUI.Instance.doingText.SetText($"{self.status.characterName}ป้องกัน");
        }
    }
}