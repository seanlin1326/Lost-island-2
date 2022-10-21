using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sean
{
    public class Item : MonoBehaviour
    {
        public ItemName itemName;

        public void ItemClicked()
        {
            //添加到背包後隱藏物體
            InventoryManager.Instance.AddItem(itemName);
            this.gameObject.SetActive(false);
        }
    }
}