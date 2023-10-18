using System;
using Turn_Based_Combat.Character;
using Unit;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utility;

namespace UI
{
    public class WinUI : Singleton<WinUI>
    {
        public GameObject panel;
        public Button closeUI;
        public UnityAction onCloseUI;
        public Player player;
        private bool _move;

        public GameObject endBattleGameObject;
        public Animator animator;
        public Button endButton;

        public void Start()
        {
            endButton.onClick.AddListener(() => OpenUI(player));
            closeUI.onClick.AddListener(CloseUi);
            // closeUI.onClick.AddListener(onCloseUI);
        }

        public void OpenEndBattle(Enemy enemy, Player player)
        {
            endBattleGameObject.SetActive(true);
            this.player = player;
            var status = (EnemyStatus)enemy.status;
            switch (status.enemyType)
            {
                case EnemyType.Dog:
                    animator.Play("Dog Win");
                    break;
                case EnemyType.YoungChild:
                    animator.Play("Kid Win");
                    break;
                case EnemyType.Cat:
                    animator.Play("Cat Win");
                    break;
                case EnemyType.Twin:
                    animator.Play("Twin");
                    break;
                case EnemyType.Grandmother:
                    animator.Play("Granma Win");
                    break;
                case EnemyType.Father:
                    animator.Play("Father Win");
                    break;
            }
        }

        public void OpenEndBattle()
        {
            endBattleGameObject.SetActive(true);
            player.movement.canMove = false;
            animator.Play("Twin");
        }

        public void OpenUI(Player player, bool shouldMove = true)
        {
            this.player = player;
            panel.SetActive(true);

            _move = shouldMove;

            endBattleGameObject.SetActive(false);
        }

        public void CloseUi()
        {
            panel.SetActive(false);
            
            if (onCloseUI != null)
            {
                onCloseUI.Invoke();
                onCloseUI = null;
            }
            
            if (_move)
            {
                player.movement.StartMove();
            }
        }
    }
}