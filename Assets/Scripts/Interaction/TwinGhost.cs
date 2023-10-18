using System.Collections;
using UI;
using UnityEngine;

namespace Interaction
{
    public class TwinGhost : BaseInteraction
    {
        public Animator animator;

        public override void Interaction()
        {
            WinUI.Instance.OpenEndBattle();
            WinUI.Instance.onCloseUI += (() =>
            {
                animator.Play("fade");
                StartCoroutine(Close());
            });
        }


        private IEnumerator Close()
        {
            yield return new WaitForSecondsRealtime(1.3f);
            gameObject.SetActive(false);
        }
    }
}