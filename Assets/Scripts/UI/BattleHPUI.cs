using System;
using TMPro;
using Unit;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace UI
{
    public class BattleHPUI : Singleton<BattleHPUI>
    {
        public Player player;
        public Enemy enemy;

        public GameObject panel;

        public TMP_Text doingText;
        public TMP_Text turnText;
        public Image playerHp;
        public Image enemyHp;

        public void Start()
        {
            panel.SetActive(false);
        }

        public void OpenUI(Enemy enemy)
        {
            this.enemy = enemy;
            panel.SetActive(true);

            playerHp.fillAmount = player.hp / player.maxHp;
            enemyHp.fillAmount = enemy.hp / enemy.maxHp;
        }

        public void UpdateHp()
        {
            playerHp.fillAmount = player.hp / player.maxHp;
            enemyHp.fillAmount = enemy.hp / enemy.maxHp;
        }

        public void SetTurn(bool isPlayerTurn)
        {
            turnText.SetText(
                isPlayerTurn ? $"ตาของ {player.status.characterName}" : $"ตาของ {enemy.status.characterName} ");
        }

        public void CloseUI()
        {
            panel.SetActive(false);
        }
    }
}