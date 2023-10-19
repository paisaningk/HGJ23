using System;
using DefaultNamespace;
using UI;
using UnityEngine;

namespace Interaction
{
    public class Item : BaseInteraction
    {
        public ItemData itemData;
        public ItemType itemType;
        
        public override void Interaction()
        {
            switch (itemType)
            {
                case ItemType.CatFood:
                    player.catFood = true;
                    break;
                case ItemType.RawRoti:
                    player.rawRoti = true;
                    break;
                case ItemType.GoldenDrugs:
                    player.goldenDrugs = true;
                    break;
                case ItemType.ForKidBro:
                    player.forKidBro = true;
                    break;
                case ItemType.Armor:
                    player.armor = true;
                    break;
            }

            ItemUI.Instance.OpenUI(itemData.text, itemData.sprite);
            gameObject.SetActive(false);
        }
    }

    public enum ItemType
    {
        CatFood,
        RawRoti,
        GoldenDrugs,
        ForKidBro,
        Armor,
    }
}