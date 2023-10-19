using Sirenix.OdinInspector;
using UI;
using Unit;
using UnityEngine;

namespace Interaction
{
    public class EndGame : BaseInteraction
    {
        public GameObject panel;
        public GameObject iconnew;
        public Enemy enemy;
        public EndGameUI endGameUI;

        public override void Update()
        {
            if (!enemy.isDead)
            {
                iconnew.SetActive(false);
                panel.SetActive(false);
                return;
            }

            panel.SetActive(true);
            iconnew.SetActive(true);

            if (!canInteraction) return;

            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                Interaction();
                canInteraction = true;
            }
        }

        [Button]
        public override void Interaction()
        {
            WinUI.Instance.endButton.onClick.RemoveAllListeners();
            WinUI.Instance.endButton.onClick.AddListener((() => WinUI.Instance.endBattleGameObject.SetActive(true)));
            WinUI.Instance.endButton.onClick.AddListener(endGameUI.OpenUI);
            WinUI.Instance.OpenEnd();
        }
    }
}