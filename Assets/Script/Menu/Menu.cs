using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Sean
{
    public class Menu : MonoBehaviour
    {
        public void QuitGame()
        {

        } 
        public void ContinueGame()
        {
            //加載遊戲進度
        }
        public void GoBackToMenu()
        {
            var currentScene = SceneManager.GetActiveScene().name;
            TransitionManager.Instance.Transition(currentScene,"Menu");
            //保存遊戲進度
        }
    }
}