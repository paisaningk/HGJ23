using System;
using System.Collections;
using Turn_Based_Combat.ActionCharacter;
using Turn_Based_Combat.Character;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Unit
{
    public class Enemy : BaseUnit
    {
        public new Rigidbody2D rigidbody2D;
        public BaseAction currentAction;

        private void Update()
        {
            if (isDead)
            {
                animator.Play("Die");
                rigidbody2D.simulated = true;
            }
        }

        public void DoSomething(BaseUnit player, UnityAction action = null)
        {
            var enemyStatus = (EnemyStatus)status;
            currentAction = enemyStatus.behaviour[Random.Range(0, enemyStatus.behaviour.Count)];
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