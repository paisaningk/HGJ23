using System;
using Turn_Based_Combat.Character;
using UI;
using UnityEngine;

namespace Unit
{
    public class BaseUnit : MonoBehaviour
    {
        public BaseStatus status;
        public float maxHp;
        public int maxFear;
        public float hp;
        public int fear;
        public bool isDead;
        public bool isDef;
        
        public Animator animator;
        public TalkUI talkUI;
        

        private void OnValidate()
        {
            if (status)
            {
                maxHp = status.hp;
                maxFear = status.fear;
                hp = status.hp;
                fear = status.fear;
            }
        }

        public void ResetDef()
        {
            isDef = false;
        }

        public void Heal(int i)
        {
            hp += i;
            if (hp > maxHp)
            {
                hp = maxHp;
            }
        }

        public void HealAfterBattle()
        {
            hp = maxHp;
            fear = 0;
        }

        /// <summary>
        /// Return is Dead
        /// </summary>
        /// <param name="damage"></param>
        /// <returns></returns>
        public bool TakeDamage(int damage)
        {
            if (isDef)
            {
                hp -= (damage * 0.5f);
            }
            else
            {
                hp -= damage;
            }
            
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