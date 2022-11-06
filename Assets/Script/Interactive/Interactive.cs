using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sean
{
  
    public class Interactive : MonoBehaviour
    {
        public ItemName requireItem;
        public bool isDone;
        public void CheckItem(ItemName itemName)
        {
            if(itemName == requireItem && !isDone)
            {
                isDone = true;
                //使用這個物品，移除這個物品
                OnClickedAction();
            }
        }
        /// <summary>
        /// 默認是正確的物品時執行
        /// </summary>
        protected virtual void OnClickedAction()
        {

        }
        public virtual void EmptyClicked()
        {
            Debug.Log("空點");
        }
    }
}