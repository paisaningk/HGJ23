using System.Collections;
using Turn_Based_Combat.ActionCharacter;
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
        public Button healButton;
        public UnityAction onUseAction;

        public void Start()
        {
            panel.SetActive(false);
            var playerStatus = (PlayerStatus)player.status;
            attackButton.onClick.AddListener(() =>
            {
                playerStatus.attack.DoAction(player, player.enemyToFight);
                StartCoroutine(PlayerEndTurn(playerStatus.attack));
            });

            defButton.onClick.AddListener(() =>
            {
                playerStatus.def.DoAction(player, player.enemyToFight);
                StartCoroutine(PlayerEndTurn(playerStatus.def));
            });

            talkButton.onClick.AddListener(() =>
            {
                playerStatus.talk.DoAction(player, player.enemyToFight);
                StartCoroutine(PlayerEndTurn(playerStatus.talk));
            });
        }

        private IEnumerator PlayerEndTurn(BaseAction baseAction)
        {
            CloseUI();
            BattleHPUI.Instance.SetTurn(false);
            yield return new WaitForSeconds(baseAction.timeInAction);
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