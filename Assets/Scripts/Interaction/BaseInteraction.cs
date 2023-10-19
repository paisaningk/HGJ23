using System;
using Unit;
using UnityEngine;

namespace Interaction
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class BaseInteraction : MonoBehaviour
    {
        public Player player;
        public GameObject icon;

        public bool canInteraction;

        public void OnValidate()
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<BoxCollider2D>().isTrigger = true;
        }

        public void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.CompareTag("Player")) return;
            player = col.GetComponent<Player>();
            canInteraction = true;
            icon.SetActive(canInteraction);
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            canInteraction = false;
            icon.SetActive(canInteraction);
        }

        public virtual void Update()
        {
            if (!canInteraction) return;

            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                Interaction();
            }
        }

        public virtual void Interaction()
        {
        }
    }
}