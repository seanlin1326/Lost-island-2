using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sean
{
    public class GameManager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            EventHandler.CallGameStateChangeEvent(GameState.GamePlay);
        }

      
    }
}