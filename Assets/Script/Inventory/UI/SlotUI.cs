using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Sean
{
    public class SlotUI : MonoBehaviour
    {
        public Image itemImage;
        private ItemDetails currentItem;
        private bool isSelected;

        public void SetItem(ItemDetails itemDetails)
        {
            currentItem = itemDetails;
            gameObject.SetActive(true);
            itemImage.sprite = itemDetails.itemSprite;
            itemImage.SetNativeSize();
        }
        public void SetEmpty()
        {
            gameObject.SetActive(false);
        }
    }
}