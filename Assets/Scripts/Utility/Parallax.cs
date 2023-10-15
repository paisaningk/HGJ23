using UnityEngine;
using UnityEngine.Serialization;

namespace Utility
{
    public class Parallax : MonoBehaviour
    {
        private float startPosX;
        private float startPosY;
        public GameObject cameraGameObject;

        public float horizontalParallax;
        public float verticalParallax;

        void Start()
        {
            var position = transform.position;
            startPosX = position.x;
            startPosY = position.y;
        }

        // Update is called once per frame
        void LateUpdate()
        {
            var position = cameraGameObject.transform.position;
            float dist_y = (position.y * verticalParallax);
            float dist_x = (position.x * horizontalParallax);
            transform.position = new Vector3(startPosX + dist_x, startPosY + dist_y, transform.position.z);
        }
    }
}