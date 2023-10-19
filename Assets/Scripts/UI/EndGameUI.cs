using System;
using Unit;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class EndGameUI : MonoBehaviour
    {
        public Enemy enemy;
        public Button restartGame;
        public Button exitGame;
        public GameObject p;

        public void Start()
        {
            exitGame.onClick.AddListener(Exit);
            restartGame.onClick.AddListener(Restart);
        }

        public void OpenUI()
        {
            p.SetActive(true);
        }

        public void Restart()
        {
            SceneManager.LoadScene("SampleScene");
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}