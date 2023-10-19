using System;
using System.Collections;
using Cinemachine;
using DG.Tweening;
using Turn_Based_Combat.Character;
using UI;
using Unit;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Turn_Based_Combat.Battle
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class BattleRoom : MonoBehaviour
    {
        [Header("Player and Enemy")] public Player player;
        public Enemy enemy;

        [Header("Spawn Point")] public Transform spawnPlayerPoint;
        public Transform spawnEnemyPoint;

        [Header("For Debug")] public bool isBattle;

        public CinemachineVirtualCamera cameraBattleRoom;
        public bool isSetupEnemy;

        public bool isCat;

        public void OnValidate()
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }

        public void OnTriggerEnter2D(Collider2D col)
        {
            if (isCat) return;
            if (!col.CompareTag("Player")) return;
            if (enemy.isDead) return;
            if (isBattle) return;

            if (col.TryGetComponent(out Player component))
            {
                player = component;
            }
            else
            {
                Debug.Log("หา player ไม่เจอออออ");
            }

            SetUpBattleRoom();
        }

        public void SetUpBattleRoom()
        {
            isBattle = true;
            player.movement.StopMove();
            player.transform.DOMove(spawnPlayerPoint.position, 1f);
            enemy.transform.DOMove(spawnEnemyPoint.position, 1f);

            cameraBattleRoom.enabled = true;
            player.enemyToFight = enemy;
            player.animator.Play("PlayerIdle");
            player.movement.sprite.flipX = false;
            
            ActionUI.Instance.onUseAction += EnemyTurn;
            BattleHPUI.Instance.OpenUI(enemy);

            if (isSetupEnemy)
            {
                StartCoroutine(PlayAnimator());
            }

            PlayerTurn();
        }

        private void CloseBattleRoom()
        {
            ActionUI.Instance.CloseUI();
            ActionUI.Instance.onUseAction = null;
            cameraBattleRoom.enabled = false;
            BattleHPUI.Instance.CloseUI();
            player.HealAfterBattle();
            player.useHeal = 0;

            WinUI.Instance.OpenEndBattle(enemy, player);

            var enemyStatus = (EnemyStatus)enemy.status;

            switch (enemyStatus.enemyType)
            {
                case EnemyType.Dog:
                    WinUI.Instance.textWin = "คุณหลอกหมาได้แล้ว เก่งมากเจ้าหมาตัวใหม่";
                    break;
                case EnemyType.YoungChild:
                    WinUI.Instance.textWin = "ไอ้เด็กนี้ โดนเราหลอกคืนแล้ว 55555";
                    break;
                case EnemyType.Cat:
                    WinUI.Instance.textWin = player.catFriend
                        ? "<rainb>คุณได้แมวเป็นเพื่อนแล้ว"
                        : "แมวไม่ชอบคุณ แมวจะจดจำสิ่งนี้ไว้จนตาย";
                    break;
                case EnemyType.Grandmother:
                    WinUI.Instance.textWin = "คุณได้ทำยายที่น่าสงสาร นอนตาหลับแล้ว";
                    break;
                case EnemyType.Father:
                    WinUI.Instance.textWin = "<wave>หลวงพ่อก็ไม่เท่าไหร่";
                    break;
            }
        }

        private bool CheckDead()
        {
            if (player.isDead)
            {
                WinUI.Instance.losePanel.SetActive(true);
                return true;
            }

            if (enemy.isDead)
            {
                CloseBattleRoom();
                return true;
            }

            return false;
        }

        private void PlayerTurn()
        {
            enemy.transform.DOMove(spawnEnemyPoint.position, 1f).OnComplete((() =>
            {
                if (CheckDead())
                {
                    return;
                }

                player.ResetDef();
                BattleHPUI.Instance.SetTurn(true);
                ActionUI.Instance.OpenUI();
            }));
            
        }

        private IEnumerator PlayAnimator()
        {
            yield return new WaitForSecondsRealtime(1f);
            enemy.animator.Play("infight_1");
        }
        private void EnemyTurn()
        {
            player.transform.DOMove(spawnPlayerPoint.position, 1f).OnComplete((() =>
            {
                if (CheckDead())
                {
                    return;
                }
                
                enemy.ResetDef();
                enemy.DoSomething(player, PlayerTurn);
            }));
        }
    }
}