using System;
using Cinemachine;
using DG.Tweening;
using UI;
using Unit;
using UnityEngine;

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
        public GameState gameState;

        public CinemachineVirtualCamera cameraBattleRoom;

        public void OnValidate()
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }

        public void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.CompareTag("Player")) return;
            if (enemy.isDead) return;
            if (isBattle) return;

            gameState = GameState.Start;
            isBattle = true;

            if (col.TryGetComponent(out Player component))
            {
                player = component;
                player.movement.StopMove();
            }
            else
            {
                Debug.Log("หา player ไม่เจอออออ");
            }

            SetUpBattleRoom();
        }

        private void SetUpBattleRoom()
        {
            player.transform.DOMove(spawnPlayerPoint.position, 1f);
            enemy.transform.DOMove(spawnEnemyPoint.position, 1f);

            cameraBattleRoom.enabled = true;
            player.enemyToFight = enemy;

            ActionUI.Instance.OpenUI();
            ActionUI.Instance.onUseAction += EnemyTurn;

            BattleHPUI.Instance.OpenUI(enemy);

            PlayerTurn();
        }

        private void CloseBattleRoom()
        {
            ActionUI.Instance.onUseAction = null;
        }

        private void PlayerTurn()
        {
            player.ResetDef();
            BattleHPUI.Instance.SetTurn(true);
            ActionUI.Instance.OpenUI();

            Debug.Log("Player");
        }

        private void PlayerAttack()
        {
            player.ResetDef();
        }

        private void EnemyTurn()
        {
            BattleHPUI.Instance.SetTurn(false);

            enemy.ResetDef();
            enemy.DoSomething(player, PlayerTurn);

            ActionUI.Instance.CloseUI();

            Debug.Log("Enemy Player");
        }
    }
}