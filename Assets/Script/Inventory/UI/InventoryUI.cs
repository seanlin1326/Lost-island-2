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

                if(index > 0)
                {
                    leftButton.interactable = true;
;               }
                else if(index == -1)
                {
                    leftButton.interactable = false;
                    rightButton.interactable = false;
                }
            }

        }
        /// <summary>
        /// 左右按鈕Event事件
        /// </summary>
        /// <param name="amount"></param>
        public void SwitchItem(int amount)
        {
            var index = currentIndex + amount;
            if(index < currentIndex)
            {
                leftButton.interactable = false;
                rightButton.interactable = true;
            }
            else if(index > currentIndex)
            {
                leftButton.interactable = true;
                rightButton.interactable = false;
            }
            else //多於2個物品的情況
            {
                leftButton.interactable = true;
                rightButton.interactable = true;
            }
            EventHandler.CallChangeItemEvent(index);
        }
    }
}