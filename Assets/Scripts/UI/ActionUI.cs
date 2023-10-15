using System;
using Turn_Based_Combat.Character;
using Unit;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
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
                onUseAction.Invoke();
            });

            defButton.onClick.AddListener(() =>
            {
                playerStatus.def.DoAction(player, player.enemyToFight);
                onUseAction.Invoke();
            });

            talkButton.onClick.AddListener(() =>
            {
                playerStatus.talk.DoAction(player, player.enemyToFight);
                onUseAction.Invoke();
            });
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