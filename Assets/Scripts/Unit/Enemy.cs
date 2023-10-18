using System;
using System.Collections;
using DG.Tweening;
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
        public bool haveStateTwo;
        public bool isStateTwo;
        public bool changAnim;
        public bool shouldMove;
        public GameObject moveIfDie;
        public bool isMove;

        private void Update()
        {
            if (!isDead) return;

            animator.Play("Die");
            rigidbody2D.simulated = true;

            if (!shouldMove || isMove)
                return;

            if (!moveIfDie) return;

            isMove = true;
            transform.DOMove(moveIfDie.transform.position, 1f);
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            var enemyStatus = (EnemyStatus)status;
            if (hp <= enemyStatus.hpEnterStateTwo)
            {
                isStateTwo = true;
            }

            if (!haveStateTwo || !isStateTwo || changAnim) return;
            changAnim = true;
            animator.Play(enemyStatus.enemyType == EnemyType.Father ? "muscle_to_gun" : "idle2");
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