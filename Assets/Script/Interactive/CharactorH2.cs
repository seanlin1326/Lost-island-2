using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sean
{
    [RequireComponent(typeof(DialogueController))]
    public class CharactorH2 : Interactive
    {
        [SerializeField]private DialogueController dialogueController;

        public override void EmptyClicked()
        {
            if (isDone)
            {
                dialogueController.ShowDialogueFinish();
            }
            else
            {
                dialogueController.ShowDialogueEmpty();
            }
        }
        protected override void OnClickedAction()
        {
            //��ܤ��eB
            dialogueController.ShowDialogueFinish();
        }
    }
}