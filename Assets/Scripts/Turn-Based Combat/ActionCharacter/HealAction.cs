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
            if (self is Player player)
            {
                if (player.CanUseHeal())
                {
                    player.Heal(heal);
                }
            }
            

            BattleHPUI.Instance.doingText.SetText($"{self.status.characterName} ได้ Heal ตัวเอง {heal} หน่วย");
        }
    }
}