using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sean
{
    public class ObjectManager : MonoBehaviour
    {
        private Dictionary<ItemName, bool> itemAvailableDictionary = new Dictionary<ItemName, bool>();
        private Dictionary<string, bool> interactiveStateDictionary = new Dictionary<string, bool>();
        private void OnEnable()
        {
            EventHandler.OnBeforeSceneUnloadEvent += OnBeforeSceneUnloadEvent;
            EventHandler.OnAfterSceneLoadedEvent += OnAfterSceneLoadedEvent;
            EventHandler.OnUpdateUIEvent += OnUpdateUIEvent;
        }
        private void OnDisable()
        {
            EventHandler.OnBeforeSceneUnloadEvent -= OnBeforeSceneUnloadEvent;
            EventHandler.OnAfterSceneLoadedEvent -= OnAfterSceneLoadedEvent;
            EventHandler.OnUpdateUIEvent -= OnUpdateUIEvent;
        }
     
        private void OnBeforeSceneUnloadEvent()
        {
            foreach (var item in FindObjectsOfType<Item>())
            {
                if (!itemAvailableDictionary.ContainsKey(item.itemName))
                {
                    itemAvailableDictionary.Add(item.itemName,true);
                }
            }

            foreach (var item in FindObjectsOfType<Interactive>())
            {
                if (interactiveStateDictionary.ContainsKey(item.name))
                {
                    interactiveStateDictionary[item.name] = item.isDone;
                }
                else
                {
                    interactiveStateDictionary.Add(item.name,item.isDone);
                }
            }
        }
        private void OnAfterSceneLoadedEvent()
        {
            foreach (var item in FindObjectsOfType<Item>())
            {
                //如果已經再字典中則更新顯示狀態，不在則添加
                if (!itemAvailableDictionary.ContainsKey(item.itemName))
                {
                    itemAvailableDictionary.Add(item.itemName, true);
                }
                else
                {
                    item.gameObject.SetActive(itemAvailableDictionary[item.itemName]);
                }
            }
            foreach (var item in FindObjectsOfType<Interactive>())
            {
                if (interactiveStateDictionary.ContainsKey(item.name))
                {
                   item.isDone = interactiveStateDictionary[item.name];
                }
                else
                {
                    interactiveStateDictionary.Add(item.name, item.isDone);
                }
            }
        }
        private void OnUpdateUIEvent(ItemDetails itemDetails, int itemIndex)
        {
            if(itemDetails != null)
            {
                itemAvailableDictionary[itemDetails.itemName] = false;
            }
        }
    }
}