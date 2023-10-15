using System.Collections;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace UI
{
    public class TalkUI : MonoBehaviour
    {
        public TextInGame textInGame;
        public TMP_Text text;
        public GameObject panel;

        public void Start()
        {
            CloseUI();
        }

        public void OpenUI(string s, int time)
        {
            OpenUI(s);
            StartCoroutine(CloseUIByTime(time));
        }

        private IEnumerator CloseUIByTime(int time)
        {
            yield return new WaitForSeconds(time);
            CloseUI();
        }

        public void OpenUI(string s)
        {
            panel.SetActive(true);
            text.SetText(s);
        }

        public void CloseUI()
        {
            panel.SetActive(false);
        }

        [Button]
        public void ShowUI()
        {
            text.SetText(textInGame.th);
        }
    }
}