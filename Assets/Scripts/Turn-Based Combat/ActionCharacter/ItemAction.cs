using UI;
using Unit;
using UnityEngine;

namespace Turn_Based_Combat.ActionCharacter
{
    public class ItemAction : BaseAction
    {
        public override void DoAction(BaseUnit self, BaseUnit other)
        {
            BattleHPUI.Instance.doingText.SetText($"{self.status.characterName} ใช้สิ่งของ");
        }
    }
}