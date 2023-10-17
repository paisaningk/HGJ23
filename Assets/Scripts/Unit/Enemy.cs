using System.Collections;
using Turn_Based_Combat.ActionCharacter;
using Turn_Based_Combat.Character;
using UnityEngine;
using UnityEngine.Events;

namespace Unit
{
    public class Enemy : BaseUnit
    {
        public BaseAction currentAction;
        public void DoSomething(BaseUnit player, UnityAction action = null)
        {
            var enemyStatus = (EnemyStatus)status;
            currentAction = enemyStatus.behaviour[0];
            currentAction.DoAction(this, player);

            StartCoroutine(EnemyTurnEnd(action));
        }


        private IEnumerator EnemyTurnEnd(UnityAction action)
        {
            yield return new WaitForSeconds(currentAction.timeInAction);
            action.Invoke();
            animator.Play("idle");
        }
    }
}