using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        public Button startGame;
        public Button exitGame;

        public void Start()
        {
            startGame.onClick.AddListener(StarGame);
            exitGame.onClick.AddListener(ExitGame);
        }

        public void StarGame()
        {
            WinUI.Instance.endOpening.onClick.AddListener((() => gameObject.SetActive(false)));
            WinUI.Instance.OpenCutSceneOpening();
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}