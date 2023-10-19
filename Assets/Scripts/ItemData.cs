using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "ItemData", order = 0)]
    public class ItemData : ScriptableObject
    {
        public Sprite sprite;

        [TextArea(3, 8)] public string text;
    }
}