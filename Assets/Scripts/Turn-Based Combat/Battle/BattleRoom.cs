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

            PlayerTurn();
        }

        private void PlayerTurn()
        {
            gameState = GameState.PlayerTurn;
            BattleUI.Instance.OpenUI();
        }

        private void EnemyTurn()
        {
            gameState = GameState.EnemyTurn;
            enemy.DoSomething(player);
            BattleUI.Instance.OpenUI();
        }
    }
}