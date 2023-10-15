using System;
using Turn_Based_Combat.Character;
using UnityEngine;

namespace Unit
{
    public class BaseUnit : MonoBehaviour
    {
        public BaseStatus status;
        public int hp;
        public int fear;
        public bool isDead;
        public Animator animator;

        private void OnValidate()
        {
            if (status)
            {
                hp = status.hp;
                fear = status.fear;
            }
        }

        /// <summary>
        /// Return is Dead
        /// </summary>
        /// <param name="damage"></param>
        /// <returns></returns>
        public bool TakeDamage(int damage)
        {
            hp -= damage;
            if (hp <= 0)
            {
                isDead = true;
            }

            return hp <= 0;
        }

        public void TakeFear(int damage)
        {
            fear += damage;
        }
    }
}