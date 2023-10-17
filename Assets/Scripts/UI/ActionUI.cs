using System.Collections;
using Turn_Based_Combat.Character;
using Unit;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utility;

namespace UI
{
    public class ActionUI : Singleton<ActionUI>
    {
        public GameObject panel;
        public Player player;
        public Button attackButton;
        public Button defButton;
        public Button talkButton;
        public Button itemButton;
        public UnityAction onUseAction;

        public void Start()
        {
            panel.SetActive(false);
            var playerStatus = (PlayerStatus)player.status;
            attackButton.onClick.AddListener(() =>
            {
                playerStatus.attack.DoAction(player, player.enemyToFight);
                StartCoroutine(PlayerEndTurn());
            });

            defButton.onClick.AddListener(() =>
            {
                playerStatus.def.DoAction(player, player.enemyToFight);
                StartCoroutine(PlayerEndTurn());
            });

            talkButton.onClick.AddListener(() =>
            {
                playerStatus.talk.DoAction(player, player.enemyToFight);
                StartCoroutine(PlayerEndTurn());
            });
        }

        private IEnumerator PlayerEndTurn()
        {
            CloseUI();
            BattleHPUI.Instance.SetTurn(false);
            yield return new WaitForSeconds(0.5f);
            onUseAction.Invoke();
        }
        

        public void OpenUI()
        {
            panel.SetActive(true);
        }

        public void CloseUI()
        {
            panel.SetActive(false);
        }
    }
}