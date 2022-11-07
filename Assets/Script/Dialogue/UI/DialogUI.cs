using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Sean
{
    public class DialogUI : MonoBehaviour
    {
        public GameObject panel;

        public Text dialogText;

        private void OnEnable()
        {
            EventHandler.ShowDialogueEvent += ShowDialog;
        }
        private void OnDisable()
        {
            EventHandler.ShowDialogueEvent -= ShowDialog;
        }
        private void ShowDialog(string dialogue)
        {
            if (dialogue != string.Empty)
            {
                panel.SetActive(true);
            }
            else
            {
                panel.SetActive(false);
            }
            dialogText.text = dialogue;
        }
    }
}