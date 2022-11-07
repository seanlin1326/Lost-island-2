using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sean
{
[CreateAssetMenu(fileName = "DialogueData_SO",menuName = "Dialog/DialogueData_SO")]
    public class DialogueData_SO : ScriptableObject
    {
        public List<string> dialogList;
    }
}