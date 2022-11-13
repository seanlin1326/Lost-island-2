using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace Sean
{
    public class MiniGame : MonoBehaviour
    {
        [SerializeField]public UnityEvent OnGameFinish;
        public bool isPass;
        [SerializeField] private Collider2D miniGameEnterCollider;
        [SerializeField] private SpriteRenderer miniGameEnterSpriteRenderer;
        [SceneName] public string gameName;
        public void UpdateMiniGameState()
        {
            if (isPass)
            {
                miniGameEnterCollider.enabled = false;
                miniGameEnterSpriteRenderer.color = new Color(1,1,1,0);
                OnGameFinish?.Invoke();
            }
        }
    }
}