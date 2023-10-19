using System;
using System.Collections;
using Sirenix.OdinInspector;
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
        
        public int maxUseHeal = 1;
        public int useHeal;
        
        public Animator animator;
        public TalkUI talkUI;

        public GameObject healVfx;

        public void Start()
        {
            healVfx.SetActive(false);
        }

        public bool CanUseHeal()
        {
            return useHeal > maxUseHeal;
        }
        
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

        [Button]
        public void Heal(int i)
        {
            useHeal++;
            hp += i;
            healVfx.SetActive(true);
           
            if (hp > maxHp)
            {
                hp = maxHp;
            }

            StartCoroutine(CloseHealVFX());
        }

        private IEnumerator CloseHealVFX()
        {
            yield return new WaitForSeconds(2f);
            healVfx.SetActive(false);
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
        public virtual void TakeDamage(int damage)
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
        }

        public void StartDelayHeal()
        {
            StartCoroutine(DelayHeal());
        }

        private IEnumerator DelayHeal()
        {
            yield return new WaitForSecondsRealtime(3f);
            TakeDamage(999);
        }

        public void TakeFear(int damage)
        {
            fear += damage;
        }
    }
}