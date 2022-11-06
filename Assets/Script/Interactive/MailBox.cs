using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sean
{
    public class MailBox : Interactive    
    {
        [SerializeField]private SpriteRenderer spriteRenderer;
        [SerializeField]private BoxCollider2D mailBoxCollider;
        [SerializeField]private GameObject ticket;
        public  Sprite openSprite;

        private void OnEnable()
        {
            EventHandler.OnAfterSceneLoadedEvent += OnAfterSceneLoadedEvent;
        }
        private void OnDisable()
        {
            EventHandler.OnAfterSceneLoadedEvent -= OnAfterSceneLoadedEvent;
        }

        private void OnAfterSceneLoadedEvent()
        {
            if (!isDone)
            {
                Debug.Log("haha");
                ticket.SetActive(false);
            }
            else
            {
                spriteRenderer.sprite = openSprite;
                mailBoxCollider.enabled = false;
              
            }
        }

        protected override void OnClickedAction()
        {
            spriteRenderer.sprite = openSprite;
            ticket.SetActive(true);
        }
    }
}