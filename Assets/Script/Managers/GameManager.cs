using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sean
{
    public class GameManager : MonoBehaviour
    {
        private Dictionary<string, bool> miniGameStateDictionary = new Dictionary<string, bool>();
        private void OnEnable()
        {
            EventHandler.OnAfterSceneLoadedEvent += OnAfterSceneLoadedEvent;
            EventHandler.GamePassEvent += OnGamePassEvent;
        }

       

        private void OnDisable()
        {
            EventHandler.OnAfterSceneLoadedEvent -= OnAfterSceneLoadedEvent;
            EventHandler.GamePassEvent -= OnGamePassEvent;
        }
        private void OnGamePassEvent(string gameName)
        {
            miniGameStateDictionary[gameName] = true;
        }
        private void OnAfterSceneLoadedEvent()
        {
            foreach (var miniGame in FindObjectsOfType<MiniGame>())
            {
                if(miniGameStateDictionary.TryGetValue(miniGame.gameName,out bool isPass))
                {
                    miniGame.isPass = isPass;
                    miniGame.UpdateMiniGameState();
                }
            }
        }
        // Start is called before the first frame update
        void Start()
        {
            EventHandler.CallGameStateChangeEvent(GameState.GamePlay);
        }

      
    }
}