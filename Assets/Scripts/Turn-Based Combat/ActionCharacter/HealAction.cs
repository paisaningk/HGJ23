using UI;
using Unit;
using UnityEngine;

namespace Turn_Based_Combat.ActionCharacter
{
    [CreateAssetMenu(menuName = "Action/Heal")]
    public class HealAction : BaseAction
    {
        public int heal;

        public override void DoAction(BaseUnit self, BaseUnit other)
        {
            var realHeal = this.heal;
            if (self is Player { rawRoti: true })
            {
                realHeal *= 2;
            }

            self.Heal(realHeal);

            BattleHPUI.Instance.doingText.SetText($"{self.status.characterName} ได้ Heal ตัวเอง {heal} หน่วย");
            BattleHPUI.Instance.UpdateHp();
        }
    }
}