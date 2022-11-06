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
    }
}