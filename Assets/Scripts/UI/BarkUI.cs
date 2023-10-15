using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace UI
{
    public class BarkUI : MonoBehaviour
    {
        public TextInGame textInGame;
        public TMP_Text text;

        [Button]
        public void ShowUI()
        {
            text.SetText(textInGame.th);
        }
    }
}