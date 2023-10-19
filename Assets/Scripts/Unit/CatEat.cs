using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Unit
{
    public class CatEat : MonoBehaviour
    {
        public Animator animator;
        public Player player;


        public void Update()
        {
            if (player.catFriend)
            {
                animator.Play("idle2");
            }
        }
    }
}