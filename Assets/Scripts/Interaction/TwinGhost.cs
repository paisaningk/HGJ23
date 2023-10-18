using System.Collections;
using UI;
using UnityEngine;

namespace Interaction
{
    public class TwinGhost : BaseInteraction
    {
        public Animator animator;
        public bool isInteraction;

        public override void Interaction()
        {
            if (!isInteraction)
            {
                WinUI.Instance.textWin = "<rainb>เกิดไรขึ้น";
                WinUI.Instance.OpenTwinCutscenes();
                WinUI.Instance.onCloseUI += (() =>
                {
                    animator.Play("fade");
                    StartCoroutine(Close());
                });
                isInteraction = true;
            }
        }


        private IEnumerator Close()
        {
            yield return new WaitForSecondsRealtime(1.3f);
            gameObject.SetActive(false);
        }
    }
}