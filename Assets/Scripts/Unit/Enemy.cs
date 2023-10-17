using System.Collections;
using Turn_Based_Combat.Character;
using UnityEngine;
using UnityEngine.Events;

namespace Unit
{
    public class Enemy : BaseUnit
    {
        public void DoSomething(BaseUnit player, UnityAction action = null)
        {
            var enemyStatus = (EnemyStatus)status;
            enemyStatus.behaviour[0].DoAction(this, player);

            StartCoroutine(EnemyTurnEnd(action));
        }


        private IEnumerator EnemyTurnEnd(UnityAction action)
        {
            yield return new WaitForSeconds(0.3f);
            action.Invoke();
        }
    }
}