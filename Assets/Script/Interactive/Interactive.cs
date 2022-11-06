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
                //�ϥγo�Ӫ��~�A�����o�Ӫ��~
                OnClickedAction();
            }
        }
        /// <summary>
        /// �q�{�O���T�����~�ɰ���
        /// </summary>
        protected virtual void OnClickedAction()
        {

        }
        public virtual void EmptyClicked()
        {
            Debug.Log("���I");
        }
    }
}