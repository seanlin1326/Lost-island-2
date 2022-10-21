using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sean
{
   
    public class CursorManager : MonoBehaviour
    {
        private Vector3 MouseWorldPos => Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        private bool canClick;

        private void Update()
        {
            canClick = ObjectAtMousePosition();
            if (canClick && Input.GetMouseButtonDown(0))
            {
                //檢測鼠標互動情況
                ClickAction(ObjectAtMousePosition().gameObject);
            }
        }
        private void ClickAction(GameObject clickObject)
        {
            switch (clickObject.tag)
            {
                case "Teleport":
                    var teleport = clickObject.GetComponent<Teleport>();
                    if (teleport != null)
                    {
                        teleport.TeleportToScene();
                    }
                    break;
                case "Item":
                    var item = clickObject.GetComponent<Item>();
                    if (item != null)
                    {
                        item.ItemClicked();
                    }
                    break;
                    
            }
        }
        /// <summary>
        /// 檢測鼠標點擊範圍的碰撞體
        /// </summary>
        private Collider2D ObjectAtMousePosition()
        {
            return Physics2D.OverlapPoint(MouseWorldPos);
        }
    }
}