using Turn_Based_Combat.Battle;
using Unit;

namespace Interaction
{
    public class Cat : BaseInteraction
    {
        public Enemy enemy;
        public BattleRoom battleRoom;
        private bool _isInteraction;

        public override void Update()
        {
            if (enemy.isDead)
            {
                gameObject.SetActive(false);
            }

            base.Update();
        }

        public override void Interaction()
        {
            if (_isInteraction) return;
            _isInteraction = true;
            battleRoom.SetUpBattleRoom();
        }
    }
}