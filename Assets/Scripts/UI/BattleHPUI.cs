using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Turn_Based_Combat.Character;
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
        public TMP_Text playerHpText;
        public TMP_Text enemyHpText;

        public VersusImage playerVersusImage;
        public List<EnemyVersusImage> enemyVersusImage;

        public Image playerVs;
        public Image enemyVs;

        public GameObject attackPlayer;
        public GameObject attackEnemy;

        public CanvasGroup playerCanvas;
        public CanvasGroup enemyCanvas;

        public Image playerAttackImage;
        public Image enemyAttackImage;

        public void Start()
        {
            panel.SetActive(false);
            attackPlayer.SetActive(false);
            attackEnemy.SetActive(false);
        }

        public void OpenUI(Enemy enemy)
        {
            this.enemy = enemy;
            panel.SetActive(true);

            UpdateHp();
        }

        public void ShowAttack(bool isPlayer, Sprite sprite)
        {
            if (isPlayer)
            {
                attackPlayer.SetActive(true);
                playerAttackImage.sprite = sprite;
                playerCanvas.alpha = 1;
                StartCoroutine(CloseAttack(attackPlayer));
            }
            else
            {
                attackEnemy.SetActive(true);
                enemyAttackImage.sprite = sprite;
                enemyAttackImage.SetNativeSize();
                enemyCanvas.alpha = 1;
                StartCoroutine(CloseAttack(attackEnemy));
            }
        }

        private IEnumerator CloseAttack(GameObject close)
        {
            yield return new WaitForSecondsRealtime(1.1f);
            close.SetActive(false);
        }
        
        

        public void UpdateHp()
        {
            playerHp.fillAmount = player.hp / player.maxHp;
            enemyHp.fillAmount = enemy.hp / enemy.maxHp;

            playerHpText.SetText($"{player.hp} / {player.maxHp}");
            enemyHpText.SetText($"{enemy.hp} / {enemy.maxHp}");

            playerVs.sprite = player.isDead ? playerVersusImage.die : playerVersusImage.alive;
            var status = (EnemyStatus)enemy.status;
            var versusImage = enemyVersusImage.FirstOrDefault(T => T.enemyType == status.enemyType);

            if (versusImage != null)
            {
                enemyVs.sprite = enemy.isDead ? versusImage.versusImage.die : versusImage.versusImage.alive;
            }
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

[Serializable]
public class EnemyVersusImage
{
    public EnemyType enemyType;
    public VersusImage versusImage;
}


[Serializable]
public class VersusImage
{
    public Sprite alive;
    public Sprite die;
}