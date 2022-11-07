using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Sean
{
    public class DialogueController : MonoBehaviour
    {
        public DialogueData_SO dialogueEmpty;
        public DialogueData_SO dialogueFinish;

        private Stack<string> dialogueEmptyStack = new Stack<string>();
        private Stack<string> dialogueFinishStack = new Stack<string>();

        private bool isTalking;
        private void Awake()
        {
            FillDialogueStack();
        }

        private void FillDialogueStack()
        {
            dialogueEmptyStack.Clear();
            dialogueFinishStack.Clear();
            for (int i = dialogueEmpty.dialogList.Count - 1; i >=0; i--)
            {
                dialogueEmptyStack.Push(dialogueEmpty.dialogList[i]);
            }
            for (int i = dialogueFinish.dialogList.Count-1; i >= 0; i--)
            {
                dialogueFinishStack.Push(dialogueFinish.dialogList[i]);
            }
        }
        public void ShowDialogueEmpty()
        {
            if (!isTalking)
            {
                StartCoroutine(DialogueCoroutine(dialogueEmptyStack));
            }
        }
        public void ShowDialogueFinish()
        {
            if (!isTalking)
            {
                StartCoroutine(DialogueCoroutine(dialogueFinishStack));
            }
        }
        private IEnumerator DialogueCoroutine(Stack<string> data)
        {
            isTalking = true;
            if (data.Count > 0)
            {
                EventHandler.CallShowDialogueEvent(data.Pop());
                yield return null;
                isTalking = false;
                EventHandler.CallGameStateChangeEvent(GameState.Pause);
            }
            else
            {
                EventHandler.CallShowDialogueEvent(string.Empty);
                FillDialogueStack();
                isTalking = false;
                EventHandler.CallGameStateChangeEvent(GameState.GamePlay);
            }
        }
    }
}
