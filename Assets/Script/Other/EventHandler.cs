using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace Sean
{
    public static class EventHandler
    {
        public static event Action<ItemDetails, int> OnUpdateUIEvent;
        public static void CallUpdateUIEvent(ItemDetails itemDetails, int index)
        {
            OnUpdateUIEvent?.Invoke(itemDetails, index);
        }
        public static event Action OnBeforeSceneUnloadEvent;

        public static void CallBeforeSceneUnloadEvent()
        {
            OnBeforeSceneUnloadEvent?.Invoke();
        }
        public static event Action OnAfterSceneLoadedEvent;
        public static void CallAfterSceneLoadedEvent()
        {
            OnAfterSceneLoadedEvent?.Invoke(); 
        }
        public static event Action<ItemDetails, bool> ItemSelectedEvent;
        public static void CallItemSelectedEvent(ItemDetails itemDetails,bool isSelected)
        {
            ItemSelectedEvent?.Invoke(itemDetails,isSelected);
        }
        public static event Action<ItemName> ItemUsedEvent;
        public static void CallItemUsedEvent(ItemName itemName)
        {
            ItemUsedEvent?.Invoke(itemName);
        }

        public static event Action<int> ChangeItemEvent;
        public static void CallChangeItemEvent(int index)
        {
            ChangeItemEvent?.Invoke(index);
        }

        public static event Action<string> ShowDialogueEvent;

        public static void CallShowDialogueEvent(string dialogue)
        {
            ShowDialogueEvent?.Invoke(dialogue);
        }
        public static event Action<GameState> GameStateChangeEvent;
        public static void CallGameStateChangeEvent(GameState gameState)
        {
            GameStateChangeEvent?.Invoke(gameState);
        }
        public static event Action CheckGameStateEvent;
        public static void CallCheckGameStateEvent()
        {
            CheckGameStateEvent?.Invoke();
        }
    }
}