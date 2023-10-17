using System;
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

        public void Start()
        {
            closeUI.onClick.AddListener(CloseUi);
            closeUI.onClick.AddListener(onCloseUI);
        }

        public void OpenUI(Player player, bool shouldMove = true)
        {
            this.player = player;
            panel.SetActive(true);

            _move = shouldMove;
        }

        public void CloseUi()
        {
            panel.SetActive(false);

            if (_move)
            {
                player.movement.StartMove();
            }
        }
    }
}