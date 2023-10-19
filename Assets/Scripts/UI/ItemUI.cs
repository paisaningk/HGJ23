using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace UI
{
    public class ItemUI : Singleton<ItemUI>
    {
        public TMP_Text text;
        public Image image;
        public Button button;
        public GameObject panel;

        public void Start()
        {
            button.onClick.AddListener((CloseUI));
        }

        public void OpenUI(string s, Sprite sprite)
        {
            panel.SetActive(true);
            text.SetText(s);
            image.sprite = sprite;
        }

        private void CloseUI()
        {
            panel.SetActive(false);
        }
    }
}