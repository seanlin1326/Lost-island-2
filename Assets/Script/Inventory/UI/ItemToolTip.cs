using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Sean
{
    public class ItemToolTip : MonoBehaviour
    {
        public Text itemNameText;

        public void UpdateItemName(ItemName itemName)
        {
            itemNameText.text = itemName switch
            {
                ItemName.Key => "�H�c�_��",
                ItemName.Ticket => "�@�i�",
                _ => ""

            };
        }
    }
}
