using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Sean
{
    public class InventoryUI : MonoBehaviour
    {
        public Button leftButton, rightButton;

        public SlotUI slotUI;

        public int currentIndex; //顯示UI當前物品序號
        private void OnEnable()
        {
            EventHandler.OnUpdateUIEvent += OnUpdateUIEvent;
        }
        private void OnDisable()
        {
            EventHandler.OnUpdateUIEvent -= OnUpdateUIEvent;
        }
        private void OnUpdateUIEvent(ItemDetails itemDetails,int index)
        {
            if(itemDetails == null)
            {
                slotUI.SetEmpty();
                currentIndex = -1;
                leftButton.interactable = false;
                rightButton.interactable = false;
            }
            else
            {
                currentIndex = index;
                slotUI.SetItem(itemDetails);
            }
        }
    }
}