﻿using System;
using TMPro;
using Turn_Based_Combat.Character;
using Unit;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
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
        public string textWin;
        public TMP_Text textWinTMPText;
        private bool _move;

        public GameObject endBattleGameObject;
        public Animator animator;
        public Button endButton;
        public Button endOpening;

        public GameObject losePanel;
        public Button restart;

        public void Start()
        {
            endButton.onClick.AddListener(() => OpenUI(player));
            closeUI.onClick.AddListener(CloseUi);
            endOpening.onClick.AddListener((() =>
            {
                endBattleGameObject.SetActive(false);
                endOpening.gameObject.SetActive(false);
                player.movement.StartMove();
            }));

            restart.onClick.AddListener((() => SceneManager.LoadScene("SampleScene")));
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

        public void OpenTwinCutscenes()
        {
            endBattleGameObject.SetActive(true);
            player.movement.canMove = false;
            animator.Play("Twin");
        }

        public void OpenEnd()
        {
            endBattleGameObject.SetActive(true);
            player.movement.canMove = false;
            animator.Play("ED");
        }

        public void OpenCutSceneOpening()
        {
            endBattleGameObject.SetActive(true);
            player.movement.canMove = false;
            animator.Play("OP");
        }

        public void OpenUI(Player player, bool shouldMove = true)
        {
            this.player = player;
            panel.SetActive(true);

            _move = shouldMove;

            endBattleGameObject.SetActive(false);
            textWinTMPText.SetText(textWin);
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