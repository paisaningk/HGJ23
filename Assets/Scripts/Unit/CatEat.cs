using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Unit
{
    public class CatEat : MonoBehaviour
    {
        public Animator animator;
        public Player player;
        public Enemy enemy;


        public void Update()
        {
            if (player.catFriend && enemy.isDead)
            {
                animator.Play("idle2");
            }
        }
    }
}